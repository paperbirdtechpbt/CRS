using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CRS.Web
{
    public static class EFExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="storedProcName"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static DbCommand LoadStoredProc(this DbContext context, string storedProcName, int timeout = 20)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = timeout;
            return cmd;
        }

        /// <summary>
        /// Creates a DbParameter object and adds it to a DbCommand
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, object paramValue, DbType paramType = DbType.String, ParameterDirection paramDirection = System.Data.ParameterDirection.Input, Action<DbParameter> configureParam = null)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.DbType = paramType;
            param.ParameterName = paramName;
            param.Value = paramValue;
            param.Direction = paramDirection;
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }

        public static DbCommand WithSqlParam(this DbCommand cmd, string paramName, Action<DbParameter> configureParam = null)
        {
            if (string.IsNullOrEmpty(cmd.CommandText) && cmd.CommandType != System.Data.CommandType.StoredProcedure)
                throw new InvalidOperationException("Call LoadStoredProc before using this method");

            var param = cmd.CreateParameter();
            param.ParameterName = paramName;
            configureParam?.Invoke(param);
            cmd.Parameters.Add(param);
            return cmd;
        }

        public class SprocResults
        {

            //  private DbCommand _command;
            private DbDataReader _reader;

            public SprocResults(DbDataReader reader)
            {
                // _command = command;
                _reader = reader;
            }

            public IList<T> ReadToList<T>()
            {
                return MapToList<T>(_reader);
            }

            public Task<bool> NextResultAsync()
            {
                return _reader.NextResultAsync();
            }

            public Task<bool> NextResultAsync(CancellationToken ct)
            {
                return _reader.NextResultAsync(ct);
            }

            public bool NextResult()
            {
                return _reader.NextResult();
            }

            /// <summary>
            /// Retrieves the column values from the stored procedure and maps them to <typeparamref name="T"/>'s properties
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="dr"></param>
            /// <returns>IList<<typeparamref name="T"/>></returns>
            private IList<T> MapToList<T>(DbDataReader dr)
            {
                var objList = new List<T>();
                var props = typeof(T).GetRuntimeProperties();

                var colMapping = dr.GetColumnSchema()
                    .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                    .ToDictionary(key => key.ColumnName.ToLower());

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        T obj = Activator.CreateInstance<T>();
                        foreach (var prop in props)
                        {
                            if (colMapping.ContainsKey(prop.Name.ToLower()))
                            {
                                var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : val);
                            }
                        }
                        objList.Add(obj);
                    }
                }
                return objList;
            }


        }

        public class SprocOutParams
        {
            private DbCommand _command;

            public SprocOutParams(DbCommand command)
            {
                _command = command;
            }

            public object GetValue(string paramName)
            {
                return _command.Parameters[paramName].Value;
            }
            
        }
        /// <summary>
        /// Executes a DbDataReader and returns a list of mapped column values to the properties of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int ExecuteStoredProc(this DbCommand command, Action<SprocResults> handleResults, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default)
        {
            int retVal = 0;

            if (handleResults == null)
            {
                throw new ArgumentNullException(nameof(handleResults));
            }

            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var sprocResults = new SprocResults(reader);
                        // return new SprocResults();
                        handleResults(sprocResults);
                    }
                    foreach(DbParameter param in command.Parameters)
                    {
                        if (param.Direction == ParameterDirection.ReturnValue)
                            retVal = Convert.ToInt32("0" + param.Value);
                    }
                    
                }
                finally
                {
                    command.Connection.Close();
                }
            }

            return retVal;
        }

        /// <summary>
        /// Executes a non query stored proc
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static void ExecuteStoredProc(this DbCommand command, Action<SprocOutParams> handleResults, System.Data.CommandBehavior commandBehaviour = System.Data.CommandBehavior.Default)
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                    var sprocOutParams = new SprocOutParams(command);
                    handleResults(sprocOutParams);
                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

    }
}

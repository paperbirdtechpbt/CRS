using CDL.Web.Models.CrimeViewModels;
using CRS.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using OfficeOpenXml;
using System.IO;

namespace CRS.Web.Controllers
{
    //[Authorize(Roles = "CaseApprover,CRSAdmin")]
    public class CrimeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CrimeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult AddCrimeHead()
        {
            return View();
        }

        public IActionResult CaseReport()
        {
            return View();
        }
        public IActionResult ViewCrimeHead()
        {
            return View();
        }
        public IActionResult AddCrime()
        {
            return View();
        }
        public IActionResult AddCrimeType()
        {
            return View();
        }
        public IActionResult ViewCrimeType()
        {
            return View();
        }
        public IActionResult ViewCase()
        {
            return View();
        }
        public IActionResult ViewCaseDetails()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetCaseData()
        {
            try
            {
                IList<CaseSaveUpdate> CaseData = new List<CaseSaveUpdate>();

                _context.LoadStoredProc("dbo.GetCaseData")
                    // .WithSqlParam("@Name", name)
                    .ExecuteStoredProc((handler) =>
                    {
                        CaseData = handler.ReadToList<CaseSaveUpdate>();
                    });

                return Json(CaseData);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }


        [HttpPost]
        public JsonResult GetCrimeTypeReports(CrimeReports model)
        {
            try
            {
                IList<CrimeReports> CaseData = new List<CrimeReports>();

                _context.LoadStoredProc("dbo.GetCrimeTypeReports")
                     .WithSqlParam("@crimetype", model.crimetype)
                     .WithSqlParam("@startdate", model.startdate)
                     .WithSqlParam("@enddate", model.enddate)
                    .ExecuteStoredProc((handler) =>
                    {
                        CaseData = handler.ReadToList<CrimeReports>();
                    });

                return Json(CaseData);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult GETMSTCrimeHeadType()
        {
            try
            {
                IList<CrimeType> CrimeTypeName = new List<CrimeType>();

                _context.LoadStoredProc("dbo.GETMSTCrimeHeadType")
                    // .WithSqlParam("@Name", name)
                    .ExecuteStoredProc((handler) =>
                    {
                        CrimeTypeName = handler.ReadToList<CrimeType>();
                    });

                return Json(CrimeTypeName);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult GETMSTHeadTypeValueName(int id)
        {
            try
            {
                IList<CaseSaveUpdate> CrimeTypeName = new List<CaseSaveUpdate>();

                _context.LoadStoredProc("dbo.GETMSTHeadTypeValueName")
                     .WithSqlParam("@id", id)
                    .ExecuteStoredProc((handler) =>
                    {
                        CrimeTypeName = handler.ReadToList<CaseSaveUpdate>();
                    });

                return Json(CrimeTypeName);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }
        [HttpPost]
        public JsonResult GetMSTCrimeHeadLogHistoryByCaseId(int id)
        {
            try
            {
                IList<CaseSaveUpdate> CrimeTypeName = new List<CaseSaveUpdate>();

                _context.LoadStoredProc("dbo.GetMSTCrimeHeadLogHistoryByCaseId")
                     .WithSqlParam("@CaseId", id)
                    .ExecuteStoredProc((handler) =>
                    {
                        CrimeTypeName = handler.ReadToList<CaseSaveUpdate>();
                    });

                return Json(CrimeTypeName);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }
        [HttpPost]
        public JsonResult GetMSTCrimeHeadLogByCaseId(int id)
        {
            try
            {
                IList<CaseSaveUpdate> CrimeTypeName = new List<CaseSaveUpdate>();

                _context.LoadStoredProc("dbo.GetMSTCrimeHeadLogByCaseId")
                     .WithSqlParam("@CaseId", id)
                    .ExecuteStoredProc((handler) =>
                    {
                        CrimeTypeName = handler.ReadToList<CaseSaveUpdate>();
                    });

                return Json(CrimeTypeName);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult GetCrimeTypeData(int id)
        {
            try
            {
                IList<CrimeType> CrimeTypeName = new List<CrimeType>();

                _context.LoadStoredProc("dbo.GetCrimeTypeData")
                     .WithSqlParam("@id", id)
                    .ExecuteStoredProc((handler) =>
                    {
                        CrimeTypeName = handler.ReadToList<CrimeType>();
                    });

                return Json(CrimeTypeName);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }
        [HttpPost]
        public JsonResult GETMSTCrimeType()
        {
            IList<CrimeType> CrimeTypeName = new List<CrimeType>();

            _context.LoadStoredProc("dbo.GETMSTCrimeType")
                // .WithSqlParam("@Name", name)
                .ExecuteStoredProc((handler) =>
                {
                    CrimeTypeName = handler.ReadToList<CrimeType>();
                });

            return Json(CrimeTypeName);
        }

        [HttpPost]
        public JsonResult DeleteMSTCrimeType(int id)
        {
            try
            {
                int iSuccess = 1;
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.LoadStoredProc("dbo.DeleteMSTCrimeType")
                        .WithSqlParam("@id", id)

                        .WithSqlParam("@Success", 0, DbType.Int32, ParameterDirection.Output)
                            .ExecuteStoredProc((handler) =>
                            {
                                iSuccess = Convert.ToInt32(handler.GetValue("@Success"));
                            });

                    if (iSuccess > 0)
                        scope.Complete();
                }

                return Json(iSuccess);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult DeleteMSTCrimeHead(int id)
        {
            try
            {
                int iSuccess = 1;
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.LoadStoredProc("dbo.DeleteMSTCrimeHead")
                        .WithSqlParam("@id", id)

                        .WithSqlParam("@Success", 0, DbType.Int32, ParameterDirection.Output)
                            .ExecuteStoredProc((handler) =>
                            {
                                iSuccess = Convert.ToInt32(handler.GetValue("@Success"));
                            });

                    if (iSuccess > 0)
                        scope.Complete();
                }

                return Json(iSuccess);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }
        [HttpPost]
        public JsonResult DeleteMSTCase(int id)
        {
            try
            {
                int iSuccess = 1;
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.LoadStoredProc("dbo.DeleteMSTCase")
                        .WithSqlParam("@id", id)

                        .WithSqlParam("@Success", 0, DbType.Int32, ParameterDirection.Output)
                            .ExecuteStoredProc((handler) =>
                            {
                                iSuccess = Convert.ToInt32(handler.GetValue("@Success"));
                            });

                    if (iSuccess > 0)
                        scope.Complete();
                }

                return Json(iSuccess);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult GetMSTCrimeHeadAll(int id)
        {
            IList<CrimeHead> CrimeHeadName = new List<CrimeHead>();

            _context.LoadStoredProc("dbo.GetMSTCrimeHeadAll")
                .WithSqlParam("@id", id)
                .ExecuteStoredProc((handler) =>
                {
                    CrimeHeadName = handler.ReadToList<CrimeHead>();
                });

            return Json(CrimeHeadName);
        }
        [HttpPost]
        public JsonResult GetMSTCrimeHead(int id)
        {
            IList<CrimeHead> CrimeHeadName = new List<CrimeHead>();

            _context.LoadStoredProc("dbo.GetMSTCrimeHead")
                .WithSqlParam("@MSTCrimeTypeID", id)
                .ExecuteStoredProc((handler) =>
                {
                    CrimeHeadName = handler.ReadToList<CrimeHead>();
                });

            return Json(CrimeHeadName);
        }

        [HttpPost]
        public JsonResult InsertUpdateMSTCrimeHeadLog(CrimeHead model)
        {
            try
            {
                int iSuccess = 1;
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.LoadStoredProc("dbo.InsertUpdateMSTCrimeHeadLog")
                        .WithSqlParam("@MSTCaseID", model.MSTCaseID)
                        .WithSqlParam("@MSTCrimeTypeID", model.MSTCrimeTypeID)
                        .WithSqlParam("@Value", model.Value)
                        .WithSqlParam("@MSTCrimeHeadID", model.MSTCrimeHeadID)
                        .WithSqlParam("@createdBy", "Admin")
                        .WithSqlParam("@Success", 0, DbType.Int32, ParameterDirection.Output)
                            .ExecuteStoredProc((handler) =>
                            {
                                iSuccess = Convert.ToInt32(handler.GetValue("@Success"));
                            });

                    if (iSuccess > 0)
                        scope.Complete();
                }
                return Json(iSuccess);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult InsertMSTCrimeHeadType(CrimeHead model)
        {
            try
            {
                int iSuccess = 1;
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.LoadStoredProc("dbo.InsertMSTCrimeHeadType")
                        .WithSqlParam("@id", model.id)
                        .WithSqlParam("@MSTCrimeTypeID", model.MSTCrimeTypeID)
                        .WithSqlParam("@CrimeName", model.CrimeHeadName)
                        .WithSqlParam("@MSTCrimeHeadTypeID", model.MSTCrimeHeadTypeID)
                        .WithSqlParam("@createdBy", "Admin")
                        .WithSqlParam("@Success", 0, DbType.Int32, ParameterDirection.Output)
                            .ExecuteStoredProc((handler) =>
                            {
                                iSuccess = Convert.ToInt32(handler.GetValue("@Success"));
                            });

                    if (iSuccess > 0)
                        scope.Complete();
                }
                return Json(iSuccess);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }
        [HttpPost]
        public JsonResult InsertMSTCrimeType(CrimeType model)
        {
            try
            {
                int iSuccess = 1;
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.LoadStoredProc("dbo.InsertMSTCrimeType")
                        .WithSqlParam("@id", model.id)
                        .WithSqlParam("@CrimeName", model.CrimeName)
                        .WithSqlParam("@CreatedBy", "Admin")
                        .WithSqlParam("@Success", 0, DbType.Int32, ParameterDirection.Output)
                            .ExecuteStoredProc((handler) =>
                            {
                                iSuccess = Convert.ToInt32(handler.GetValue("@Success"));
                            });

                    if (iSuccess > 0)
                        scope.Complete();
                }
                return Json(iSuccess);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }
        [HttpPost]
        public JsonResult InsertMSTCase(CaseSaveUpdate model)
        {
            try
            {
                int iSuccess = 1;
                using (TransactionScope scope = new TransactionScope())
                {
                    _context.LoadStoredProc("dbo.InsertMSTCase")
                        .WithSqlParam("@MSTCrimeTypeID", model.MSTCrimeTypeID)
                        .WithSqlParam("@CaseNo", model.CaseNo)
                        .WithSqlParam("@ComplainerName", model.ComplainerName)
                        .WithSqlParam("@ComplainerContactNo", model.ComplainerContactNo)
                        .WithSqlParam("@ComplainerAddress", model.ComplainerAddress)
                        .WithSqlParam("@MSTStatusId", 1)
                        .WithSqlParam("@CreatedBy", "Admin")
                        //.WithSqlParam("@JsonData", model.JsonData)

                        .WithSqlParam("@Success", 0, DbType.Int32, ParameterDirection.Output)
                            .ExecuteStoredProc((handler) =>
                            {
                                iSuccess = Convert.ToInt32(handler.GetValue("@Success"));
                            });

                    if (iSuccess > 0)
                        scope.Complete();
                }

                return Json(iSuccess);
            }
            catch (Exception ex)
            {
                return Json("Fail: Exception" + ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetLeasingCommissionSchedule(int Id, string n, string c)
        {
            // For all crime data
            IEnumerable<LeasingCommissionSchedule> lcSchedule = new List<LeasingCommissionSchedule>();
            if (Id > 0)
            {
                _context.LoadStoredProc("dbo.ACALeasingCommissionScheduleGet")
                    .WithSqlParam("@PMSPropertyId", Id)
                        .ExecuteStoredProc((handler) =>
                        {
                            lcSchedule = handler.ReadToList<LeasingCommissionSchedule>();
                        });
            }

            using (ExcelPackage package = new ExcelPackage(new FileInfo(Path.Combine(_env.WebRootPath, "ExcelTemplates", "Leasing Commission Schedule Template.xltx"))))
            {
                if (lcSchedule.Count() > 0)
                {
                    // Unique crime type
                    IEnumerable<string> unitCodeList = lcSchedule.Select(lc => lc.UnitCode).Distinct();
                    foreach (string unitCode in unitCodeList)
                    {
                        // Data for a specific crime type
                        var lcScheduleList = lcSchedule.Where(lc => lc.UnitCode == unitCode);
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(unitCode, package.Workbook.Worksheets["Template"]);

                        worksheet.Cells[2, 1].Value = n;
                        worksheet.Cells[3, 1].Value = c;

                        int iColIndex = 14;

                        foreach (LeasingCommissionSchedule lcExcel in lcScheduleList)
                        {
                            worksheet.Cells[4, iColIndex + 2].Value = lcExcel.Amount;
                            worksheet.Cells[5, iColIndex + 2].Value = lcExcel.UnitCode;
                            worksheet.Cells[5, iColIndex + 3].Value = lcExcel.TenantName;
                            worksheet.Cells[6, iColIndex + 2].Value = lcExcel.ContractNo;
                            worksheet.Cells[7, iColIndex + 2].Value = lcExcel.AmortisationStartDate;
                            worksheet.Cells[8, iColIndex + 2].Value = lcExcel.AmortisationEndDate;
                            worksheet.Cells[9, iColIndex + 2].Value = Convert.ToInt32(lcExcel.FirstPostingPeriod.Replace("-", "0"));
                            worksheet.Cells[10, iColIndex + 2].Value = lcExcel.AmortisationWriteOffDate;

                            iColIndex += 11;
                        }

                    }

                }

                package.Workbook.Worksheets.Delete("Template");

                return File(package.GetAsByteArray(), "application/vnd.ms-excel", $"{n} (Leasing Commission Schedule) {DateTime.Now.ToString("yyyyMMddHHmm")}.xlsx");
            }
        }



        private object Json(string v, object allowGet)
        {
            throw new NotImplementedException();
        }
    }
}

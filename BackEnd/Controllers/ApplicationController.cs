using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationController : ControllerBase
    {
        [Authorize(Roles="StudentOnly")]
        [HttpGet("/getmyapplicationlist")]
        public ActionResult<DataTableResponse> getmyapplicationlist()
        {
            var currentUser = HttpContext.User;
            var userName = currentUser.Claims.First(x => x.Type == "UserName").Value;
            var list = AppUtil.mydb.Applications.Where(x=>x.username==userName).ToList();
            var _list = ApplicationResponseCast(list);
            return new DataTableResponse
            {
                RecordsTotal = _list.Count(),
                RecordsFiltered = 10,
                Data = _list.ToArray()
            };
        }       
        [Authorize(Roles = "CheckerOnly")]
        [HttpGet("/getapplyapplication")]
        public ActionResult<DataTableResponse> getapplyapplication()
        {
            var list = AppUtil.mydb.Applications.Where(rec => rec.status == (int)Enums.ApplicationStatus.Applied).ToList();
            var _list = ApplicationResponseCast(list);
            return new DataTableResponse
            {
                RecordsTotal = _list.Count(),
                RecordsFiltered = 10,
                Data = _list.ToArray()
            };
        }
        [Authorize(Roles = "DeciderOnly")]
        [HttpGet("/getevaluationapplication")]
        public ActionResult<DataTableResponse> getevaluationapplication()
        {
            var list = AppUtil.mydb.Applications.Where(rec => rec.status == (int)Enums.ApplicationStatus.Checked).ToList();
            var _list = ApplicationResponseCast(list);
            return new DataTableResponse
            {
                RecordsTotal = _list.Count(),
                RecordsFiltered = 10,
                Data = _list.ToArray()
            };
        }


        [Authorize(Roles = "StudentOnly")]
        [HttpPost("/applyprogram")]
        public IActionResult applyprogram(Applications application)
        {
            application.applicationDate = DateTime.Now.ToString();
            application.status = (int)Enums.ApplicationStatus.Applied;
            AppUtil.mydb.Applications.Add(application);
            AppUtil.mydb.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = "CheckerOnly")]
        [HttpPost("/checkapplyprogram")]
        public IActionResult checkapplyprogram(Applications application)
        {
            var app = AppUtil.mydb.Applications.First(x => x.id == application.id);
            app.status = application.status;
            AppUtil.mydb.Applications.Update(app);
            AppUtil.mydb.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = "DeciderOnly")]
        [HttpPost("/decisionapplyprogram")]
        public IActionResult decisionapplyprogram(int id, int status)
        {
            var app = AppUtil.mydb.Applications.First(x => x.id == id);
            app.status = status;
            AppUtil.mydb.Applications.Update(app);
            AppUtil.mydb.SaveChanges();
            return Ok();
        }

        [HttpGet("/getapplication")]
        public IEnumerable<Applications> getapplication([FromQuery] int id)
        {
            return AppUtil.mydb.Applications.Where(rec => rec.id == id).ToList();
        }
        private List<ApplicationResponse> ApplicationResponseCast(List<Applications> list)
        {
            List<ApplicationResponse> _list = new List<ApplicationResponse>();
            foreach (var item in list)
            {
                var _response = new ApplicationResponse
                {
                    status = item.status,
                    applicationDate = item.applicationDate,
                    id = item.id,
                    programId = item.programId,
                    programName = AppUtil.mydb.AcademicProgram.First(rec => rec.id == item.programId).programName,
                    statusName = getStatusName(item.status),
                    username = item.username,

                };
                _list.Add(_response);
            }
            return _list;
        }
        private string getStatusName(int applicationStatus)
        {
            switch (applicationStatus)
            {
                case (int)Enums.ApplicationStatus.Applied:
                    return "Başvuru Yapıldı";
                case (int)Enums.ApplicationStatus.Checked:
                    return "Kontrol Onaylandı";
                case (int)Enums.ApplicationStatus.NotAvailable:
                    return "Kontrol Onaylanmadı";
                case (int)Enums.ApplicationStatus.Approved:
                    return "Onaylandı";
                case (int)Enums.ApplicationStatus.Rejected:
                    return "Reddedildi";
                default: return "";
            }
        }
    }
}

using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "AdminOnly")]
    public class UsersController : ControllerBase
    {
        public UsersController() { }

        [HttpGet("/getuserlist")]
        public ActionResult<DataTableResponse> getuserlist()
        {
            var list = AppUtil.mydb.SiteUsers.ToList();
            return new DataTableResponse
            {
                RecordsTotal = list.Count(),
                RecordsFiltered = 10,
                Data = list.ToArray()
            };
        }
        [HttpPost("/updateuser")]
        public IActionResult updateuser(SiteUser user)
        {
            var userData = AppUtil.mydb.SiteUsers.First(x => x.userName == user.userName);
            userData.permControl = user.permControl;
            userData.permApply = user.permApply;
            userData.permAdmin = user.permAdmin;
            userData.permDecision = user.permDecision;
            userData.name = user.name;
            userData.family = user.family;
            AppUtil.mydb.SiteUsers.Update(userData);
            AppUtil.mydb.SaveChanges();
            return Ok();
        }
        [HttpGet("/getuser")]
        public IEnumerable<SiteUser> getuser([FromQuery] string userName)
        {
            return AppUtil.mydb.SiteUsers.Where(rec => rec.userName == userName).ToList();
        }
    }
}

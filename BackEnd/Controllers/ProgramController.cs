using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ProgramController : ControllerBase
    {

        [Authorize(Roles = "AdminOnly,StudentOnly")]
        [HttpGet("/getprogramlist")]
        public ActionResult<DataTableResponse> getprogramlist()
        {
            try
            {
                var currentUser = HttpContext.User;
                var userName = currentUser.Claims.First(x => x.Type == "UserName").Value;
                var list = AppUtil.mydb.AcademicProgram.ToList();
                return new DataTableResponse
                {
                    RecordsTotal = list.Count(),
                    RecordsFiltered = 10,
                    Data = list.ToArray()
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            
        }     
        [Authorize(Roles = "AdminOnly")]
        [HttpPost("/addprogram")]
        public IActionResult addprogram(AcademicProgram program)
        {
            AppUtil.mydb.AcademicProgram.Add(program);
            AppUtil.mydb.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = "AdminOnly")]
        [HttpGet("/getprogram")]
        public IEnumerable<AcademicProgram> getuser([FromQuery] int id)
        {
            return AppUtil.mydb.AcademicProgram.Where(rec => rec.id == id).ToList();
        }
    }
}

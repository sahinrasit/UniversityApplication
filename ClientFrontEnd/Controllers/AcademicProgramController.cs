using ClientFrontEnd.Models;
using ClientFrontEnd.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace ClientFrontEnd.Controllers
{
    public class AcademicProgramController : Controller
    {
        ApiService apiService = new ApiService();
        public IActionResult AddProgram()
        {
            return View();
        }
        public IActionResult ApplyProgram()
        {

            return View();
        }
        public IActionResult ReviewProgram()
        {
            return View();
        }
        public IActionResult EvaluationProgram()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        #region ApiCall
        public Object ListUser()
        {
            var result = apiService.getuserlist();
            return result != null ? Ok(result) : BadRequest();
        }
        public Object UpdateUser([FromBody] SiteUser user)
        {
            var result = apiService.updateuser(user);
            return result != null ? Ok(result) : BadRequest();
        }
        public Object GetUser([FromQuery] string userName)
        {
            var result = apiService.getuser(userName);
            return result != null ? Ok(result) : BadRequest();
        }
        public Object Login([FromBody] SiteUser user)
        {
            var result = apiService.login(user);
            HttpContext.Response.Cookies.Append("UserInfo", JsonConvert.SerializeObject(result));
            return result != null ? Ok(result) : BadRequest();
        }
        public Object Logout()
        {
            var result = apiService.logout();
            return result != null ? Ok(result) : BadRequest();
        }
        public Object Register([FromBody] SiteUser user)
        {
            var result = apiService.register(user);
            return result != null ? Ok(result) : BadRequest();
        }
        public Object MyApplicationList()
        {
            var result = apiService.getmyapplicationlist();
            return result != null ? Ok(result) : BadRequest();
        }
        public Object GetProgramList()
        {
            var result = apiService.getprogramlist();
            return result != null ? Ok(result) : BadRequest();
        }
        public Object GetApplyApplication()
        {
            var result = apiService.getapplyapplication();
            return result != null ? Ok(result) : BadRequest();
        }
        public Object ProgramAdd([FromBody] AcademicProgram program)
        {
            var result = apiService.addprogram(program);
            return result != null ? Ok(result) : BadRequest();
        }
        public Object ProgramApply([FromBody] Applications applications)
        {
            var result = apiService.applyprogram(applications);
            return result != null ? Ok(result) : BadRequest();
        }
        public Object GetEvaluationApplication()
        {
            var result = apiService.getevaluationapplication();
            return result != null ? Ok(result) : BadRequest();
        }
        public Object CheckApplications([FromBody] Applications applications)
        {
            var result = apiService.checkapplyprogram(applications);
            return result != null ? Ok(result) : BadRequest();
        }
        #endregion
    }
}


using BackEnd.Data;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        [HttpPost("/login")]
        public IActionResult login(SiteUser user)
        {
            var _user = AppUtil.mydb.SiteUsers.Where(rec => rec.userName == user.userName && rec.password == user.password).FirstOrDefault();
            if (_user != null)
            {
                string jwt = GenerateJsonWebToken(_user);
                Response.Cookies.Append("X-Access-Token", jwt);
                var userModel = new UserModel
                {
                    birthDate = _user.birthDate,
                    family = _user.family,
                    gender = _user.gender,
                    name = _user.name,
                    permAdmin = _user.permAdmin,
                    permApply = _user.permApply,
                    permControl = _user.permControl,
                    permDecision = _user.permDecision,
                    regDate = _user.regDate,
                    tcNumber = _user.tcNumber,
                    token = jwt,
                    userName = _user.userName
                };
                return Ok(userModel);

            }
            return Unauthorized();
        }
        [HttpPost("/logout")]
        public IActionResult logout()
        {
            Response.Cookies.Delete("X-Access-Token");
            return Ok();
        }
        [HttpPost("/register")]
        public IActionResult register(SiteUser user)
        {
            user.regDate = DateTime.Now.ToString();
            AppUtil.mydb.SiteUsers.Add(user);
            AppUtil.mydb.SaveChanges();
            return Ok();
        }
        private string GenerateJsonWebToken(SiteUser user)
        {
            List<Claim> claimList = new List<Claim>();
            string myKey = "hfıdhhrfghreugfy";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(myKey));
            var crt = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            claimList.Add(new Claim("UserName", user.userName));
            if (user.permDecision)
                claimList.Add(new Claim(ClaimTypes.Role, "DeciderOnly"));
            if (user.permControl)
                claimList.Add(new Claim(ClaimTypes.Role, "CheckerOnly"));
            if (user.permApply)
                claimList.Add(new Claim(ClaimTypes.Role, "StudentOnly"));
            if (user.permAdmin)
                claimList.Add(new Claim(ClaimTypes.Role, "AdminOnly"));

            var token = new JwtSecurityToken("localhost", "localhost", claimList,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: crt);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

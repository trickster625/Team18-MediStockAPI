using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediStockAPI.Models;
using MediStockAPI.Models.Login;

namespace MediStockAPI.Controllers.Login
{
    public class LoginController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();
        [HttpGet]
        [Route("getToken")]
        public Object GetToken(Employee employee)
        {
            string key = "my_secret_key_12345"; // secret key (not so secret yet)
            var issuer = "http://localhost:4200";


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userClaim = new List<Claim>();
            userClaim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaim.Add(new Claim("valid", "1"));
            userClaim.Add(new Claim("Employee_ID",  employee.Employee_ID.ToString()));
            userClaim.Add(new Claim("CurrentVehicle_ID","1"));
            userClaim.Add(new Claim("CurrentCall_ID", "1"));


            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            userClaim,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return  jwt_token;
        }
        
        [HttpPost]
        [Route("UserLogin")]
        public IHttpActionResult Login(toLogin LoggingInUser)
        {
            var username = LoggingInUser.username;
            var password = LoggingInUser.password;
            var user = db.Employees.Where(m => m.Employee_EmailAddress == username && m.Employee_HashedPassword == password).FirstOrDefault();
            if (user != null)
            {
                
               var token = GetToken(user);
               LoginVM test = new LoginVM(user, token.ToString());
                return Ok(test);
               
            }
            else
            {
                return BadRequest("username and password incorrect to check: " + username+"  " + password) ;
            }
        }
    }

   
}

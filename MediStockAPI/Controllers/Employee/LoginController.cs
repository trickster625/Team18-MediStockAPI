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
using System.Security.Cryptography;
using System.IO;

namespace MediStockAPI.Controllers
{
    public class LoginController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();
        [HttpGet]
        [Route("getToken")]
        public Object GetToken(Models.Employee employee)
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
            var password =  Encrypt(LoggingInUser.password);

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

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }

   
}

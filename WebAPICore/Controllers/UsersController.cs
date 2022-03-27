using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private ITokenHelper _tokenHelper;


        public UsersController(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;

        }

        [HttpGet("getuser")]
        public IActionResult GetUser()
        {
            try
            {
                var email = string.Empty;
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    email = identity.FindFirst(ClaimTypes.Name).Value;
                }

                var token2 = Request.Headers["Authorization"].ToString();
                token2 = token2.ToString().Replace("Bearer","").Trim();
                var jwt = Request.Cookies["jwt"];

                /*var token = new JwtHelper.Verify(jwt);*/
                //var token = new JwtHelper.Verify(jwt);
                var token = _tokenHelper.Verify(token2);
                //var tokenBase = _tokenHelper.Verify(token2);

                int userId = int.Parse(token.Issuer);

                var user = _userService.GetById(userId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //var result = new User();
            var result = _userService.GetAll();
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("getuserdetailbymail")]
        public IActionResult GetUserDetailByMail(string userMail)
        {
            //var _test = userMail.IndexOf('"');
            //var _test2 = Regex.Replace(userMail, "[\\\"'\\\\]", string.Empty);
            //userMail = userMail.Replace("'\'", "");
            userMail = Regex.Replace(userMail, "[\"\\\\]", string.Empty);


            var result = _userService.GetUserDetailByMail(userMail);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("updateuserdetails")]
        public IActionResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
        {
            var result = _userService.UpdateUserDetails(userDetailForUpdate);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
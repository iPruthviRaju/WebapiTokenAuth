using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace WebapiTokenAuth.Controllers
{
    public class UserController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/user/forall")]
        public IHttpActionResult Get()
        {
            return Ok($"Hi, time now: {DateTime.Now.ToString()}");
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok($"Hello {identity.Name}!, time now: {DateTime.Now.ToString()}");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/user/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok($"Hello {identity.Name}!, time now: {DateTime.Now.ToString()}");
        }
    }
}

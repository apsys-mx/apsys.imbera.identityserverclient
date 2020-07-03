using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace apsys.imbera.identityserverclient.webapi.Controllers
{
    public class HomeController : ApiController
    {

        [HttpGet, Route("hello")]
        [Authorize]
        public IHttpActionResult Hello()
        {
            string username = this.User.GetUserName();
            return Json($"Hello {username}");
        }

    }
}

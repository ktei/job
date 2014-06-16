using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;

namespace mPortAssessment.Controllers.Api
{
    public class DataController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("GetMemberSize")]
        public HttpResponseMessage GetMemberSize([FromBody]FormDataCollection input)
        {
            HttpResponseMessage response = null;
            string email = input.Get("email");

            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new ApplicationException("Server internal error"));
                // TODO: We should log exception
            }
            return response;
        }
    }
}

﻿using System.Web.Http;
using System.Net;
using System.Net.Http;
using DotNetNuke.Web.Api;
using DotNetNuke.Services.Exceptions;

namespace starter_web_api.Services
{
    public class MyController : ControllerBase
    {
        #region "API Endpoints"
        [DnnAuthorize()]
        [HttpGet()]
        public HttpResponseMessage DnnHello()
        {
            try
            {
                string dnnHello = "Hello from Dnn!";
                return Request.CreateResponse(HttpStatusCode.OK, dnnHello);
            }
            catch (System.Exception ex)
            {
                //Log exception and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [DnnAuthorize()]
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public HttpResponseMessage DnnGoodbye(DetailsDTO data)
        {
            try
            {
                string dnnMessage = "Hello from Dnn!";
                if (data.goodbye)
                {
                    dnnMessage = "Goodbye from Dnn!";
                }
                return Request.CreateResponse(HttpStatusCode.OK, dnnMessage);
            }
            catch (System.Exception ex)
            {
                //Log exception and reply with Error
                Exceptions.LogException(ex);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region "DTO Classes"
        public class DetailsDTO
        {
            public bool goodbye { get; set; }
        }
        #endregion
    }
}
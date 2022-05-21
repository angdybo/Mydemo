﻿using logic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wouse.Controllers
{
    public class BaseController : Controller
    {

        protected ActionResult SuccessResult(string message = "操作成功", object data = null)
        {
            return Content(new JsonRes(ResultType.Success, message, data).ToJsonCon());
        }
        protected ActionResult ErrorResult(string message = "操作失败！", object data = null)
        {
            return Content(new JsonRes(ResultType.Error, message, data).ToJsonCon());
        }
        public class JsonRes
        {
            public JsonRes(ResultType resultType,string message,object data=null)
            {
                this.resultType = resultType;
                this.message = message;
                this.data = data;
            }
            public object resultType { get; set; }
            public string message { get; set; }
            public object data { get; set; } 
        }
        public enum ResultType
        {
            Success = 1,
            Error = 2
        }
    }
}
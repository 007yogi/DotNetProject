﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCustomFilter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[SampleActionFilter("controller")]
    //[LogAttributeFilter]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok("product method");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOOC_Server.MySettings;

namespace MOOC_Server.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class getCoursesController : ControllerBase
    {
        //
        // GET: api/getCourses
        public IServerRepository ServerItem {get;}
        public getCoursesController(IServerRepository item)
       => ServerItem = item;
        [HttpGet("getCourses")]
        public List<Course> GetByKeyWord(string keyword)
            => ServerItem.GetByKeyWord(keyword);
    }
}

﻿using AngleSharp.Html.Parser;
using CourseLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stepik
{
    public class StepikCourseDetails : CourseDetails
    {
        public StepikCourseDetails(string summary, string workload, string target_audience, string course_format, string description)
            : base(summary, DescriptionFix(description), string.IsNullOrEmpty(target_audience) ? "Не требуется дополнительных знаний! (No additional knowledge required)" : target_audience,
                  string.IsNullOrEmpty(course_format) ? "Онлайн-курс (Online-Course)" : course_format,
                  string.IsNullOrEmpty(workload) ? "Свободный график (Your own schedule)" : workload)
        { }
        
        private static string DescriptionFix(string description)
        {
            HtmlParser domparser = new HtmlParser();
            var document = domparser.ParseDocument($"<html> {description} </html>");
             return document.QuerySelector("html").TextContent.Replace("\n","");
        }
    }
}

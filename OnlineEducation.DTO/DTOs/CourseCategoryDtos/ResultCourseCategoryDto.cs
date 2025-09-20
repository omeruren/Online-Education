﻿using OnlineEducation.DTO.DTOs.CourseDtos;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DTO.DTOs.CourseCategoryDtos
{
    public class ResultCourseCategoryDto
    {
        public int CourseCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsShown { get; set; }
        public List<ResultCourseDto> Courses { get; set; }
    }
}

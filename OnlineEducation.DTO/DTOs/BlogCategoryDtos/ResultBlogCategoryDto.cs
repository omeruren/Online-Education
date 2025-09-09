using OnlineEducation.DTO.DTOs.BlogDtos;
using OnlineEducation.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducation.DTO.DTOs.BlogCategoryDtos
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }
        public List<ResultBlogDto> Blogs { get; set; }
    }
}

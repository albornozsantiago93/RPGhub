using LMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Logic
{
    public class CourseCfgLogic
    {
        private SqlContext _context;

        public CourseCfgLogic(SqlContext context)
        {
            _context = context;
        }

        public string GetCourseInfo()
        {
            return "Course information retrieved successfully.";
        }


    }
}

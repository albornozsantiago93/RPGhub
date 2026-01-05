using LMS.Domain;
using LMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Logic
{
    public class StuffLogic
    {
        private SqlContext _context;

        public StuffLogic(SqlContext context)
        {
            _context = context;
        }

        public List<Country> GetCountries()
        {
            return _context.Country.OrderBy(x => x.Name).ToList();
        }

    }
}

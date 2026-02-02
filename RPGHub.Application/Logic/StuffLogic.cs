using RPGHub.Common.Logic;
using RPGHub.Domain;
using RPGHub.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace RPGHub.Application.Logic
{
    public class StuffLogic : IStuffLogic
    {
        private SqlContext _context;

        public StuffLogic(SqlContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _context.Country.OrderBy(x => x).ToListAsync();
        }

        public async Task<Country> GetCountryById(int id)
        {
            return await _context.Country.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}

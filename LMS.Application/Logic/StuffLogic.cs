using LMS.Common.Logic;
using LMS.Domain;
using LMS.Infrastructure;


namespace LMS.Application.Logic
{
    public class StuffLogic : IStuffLogic
    {
        private SqlContext _context;

        public StuffLogic(SqlContext context)
        {
            _context = context;
        }

        public List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();

            Country aux = new Country() { Id = 1, Name = "Argentina" };
            countries.Add(aux);
            return countries;
            //return _context.Country.OrderBy(x => x.Name).ToList();
        }

    }
}

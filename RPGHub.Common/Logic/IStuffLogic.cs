using RPGHub.Domain;

namespace RPGHub.Common.Logic
{
    public interface IStuffLogic
    {
        Task<List<Country>> GetCountries();
        Task<Country> GetCountryById(int id);


    }
}

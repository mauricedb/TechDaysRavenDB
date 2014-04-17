using System.Linq;
using Raven.Client.Indexes;
using RavenDBConsole.Models;

namespace RavenDBConsole.Indexes
{
    public class Company_ByCityCountry : AbstractIndexCreationTask<Company>
    {
        public Company_ByCityCountry()
        {
            Map = companies => from company in companies
                               select new
                               {
                                   company.Address.City,
                                   company.Address.Country
                               };

        }
    }
}
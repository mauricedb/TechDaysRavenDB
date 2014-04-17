using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Linq;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Raven.Database.Server.Responders;
using Raven.Storage.Esent.SchemaUpdates.Updates;
using RavenDBConsole.Models;

namespace RavenDBConsole
{
    class Program
    {
        static void Main()
        {
            using (IDocumentStore store = new DocumentStore()
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "TestDB"
            }.Initialize())
            {
                IndexCreation.CreateIndexes(Assembly.GetExecutingAssembly(), store);

                DoStuff(store);
            }

            Console.ReadLine();
        }
        private static void DoStuff(IDocumentStore store)
        {
            using (IDocumentSession session = store.OpenSession())
            {

                //var company = session.Load<Company>("companies/1");
                //Console.WriteLine(company);
                //company.Name = "ABL";

                //var p = new Person()
                //{
                //    FirstName = "Maurice"
                //};

                //Console.WriteLine(p.Id);
                //session.Store(p);
                //Console.WriteLine(p.Id);

                //session.SaveChanges();

                //var orders = session.Query<Order>()
                //    .Customize(x => x.WaitForNonStaleResultsAsOfNow())
                //                    .Where(o => o.ShipTo.Country == "UK")
                //                    .ToList();

                var orders = session.Query<Order>()
                    .Include<Order>(o=> o.Company)
                    //.Take(10)
                    .ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine(order.Company);
                    var c = session.Load<Company>(order.Company);
                    Console.WriteLine(c.Name);
                }

                Console.WriteLine(orders.Count);
            }
        }
    }
}

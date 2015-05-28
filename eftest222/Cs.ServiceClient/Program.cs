using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs.ServiceClient
{
    class Program
    {
        static void ListAllStudents(Default.Container container)
        {
            foreach (var p in container.Students)
            {
                Console.WriteLine("{0} {1} {2}", p.FirstMidName, p.LastName, p.EnrollmentDate);
            }
        }

        static void Main(string[] args)
        {
            const string serviceUri = "http://localhost:11919/";
            var container = new Default.Container(new Uri(serviceUri));
            ListAllStudents(container);
        }
    }
}

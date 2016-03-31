using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigALoanConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();

            var colleges = svc.GetColleges();

            foreach( var obj in colleges)
            {
                Console.WriteLine(string.Format("{0} - {1}", obj.CollegeID, obj.CollegeName));
            }
            

            Console.ReadKey();

        }
    }
}

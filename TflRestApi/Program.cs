using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TflRestApi.Logic;

namespace TflRestApi
{
    class Program
    {
        private static readonly ITflApiServices apiServices = new TflApiServices();
        static void Main(string[] args)
        {
            Console.Beep();
            Console.WriteLine("*************Welcome to Tfl Api Services*****************");
            Console.WriteLine("Please provide the road id here :");
            Console.Beep();
            var roadId = Console.ReadLine();
            var displayName = apiServices.GetDisplayName(roadId);
            Console.Beep();
            Console.WriteLine(displayName);
            Console.Beep();
            var errorMessage = apiServices.GetMessage(roadId);
            Console.WriteLine(errorMessage);
            Console.Beep();
            var statusSeverity = apiServices.GetStatusSeverity(roadId);
            Console.WriteLine(statusSeverity);
            Console.Beep();
            var httpStatusCode = apiServices.GetHttpStatusCode(roadId);
            Console.WriteLine(httpStatusCode);
            Console.Beep();
            var statusSeverityDescription = apiServices.GetStatusSeverityDescription(roadId);
            Console.WriteLine(statusSeverityDescription);
            Console.ReadLine();
        }
    }
}

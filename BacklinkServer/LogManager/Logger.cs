using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BacklinkServer.LogManager
{
    public class Logger
    {
        public static void Log(ELogTypes types, string log)
        {
            switch (types)
            {
                case ELogTypes.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ELogTypes.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case ELogTypes.Information:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case ELogTypes.Succesfully:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
            Console.WriteLine(log);
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}

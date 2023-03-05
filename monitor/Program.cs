using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace monitor
{
    internal class Program
    {
        static void Main(string[] args )
        {
            string name = "";
            Console.WriteLine("Write the name of process you wish to track: ");
            name = Console.ReadLine();
            while(name == "" )
            {
                Console.WriteLine("No input, try again");
                name = Console.ReadLine();
            }
            Console.WriteLine("Type how long can one instace of the process live in minutes");
            int lifeSpan = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Press enter to exit the program, it will end after the current cycle");
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();
                Process[] process = Process.GetProcessesByName(name);

                Thread.Sleep(1000*60*lifeSpan);
                int counter = 0;
                foreach (Process p in process)
                {
                    p.Kill();
                    counter++;
                }
                if (counter > 0)
                    Console.WriteLine("Number of instancs of '{0}' terminated: '{1}'", name, counter);

                Thread.Sleep(1000*60);

            } while (cki.Key != ConsoleKey.Enter);






        }
    }

}
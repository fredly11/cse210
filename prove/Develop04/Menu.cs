using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    public class Menu
    {
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Enter choice: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        new BreathingActivity("Breathing", GetDuration()).Start();
                        break;
                    case "2":
                        new ReflectionActivity("Reflection", GetDuration()).Start();
                        break;
                    case "3":
                        new ListingActivity("Listing", GetDuration()).Start();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        private int GetDuration()
        {
            Console.Write("Enter duration in seconds: ");
            return int.Parse(Console.ReadLine());
        }
    }
}

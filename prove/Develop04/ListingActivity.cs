using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    internal class ListingActivity : Activity
    {
        public ListingActivity(string name, int time) : base(name, time) {
            _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        private static readonly List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        private List<string> UserResponses = new List<string>();
    
        public override void Start()
        {
            base.Start();
            Activity();
            WriteList();
            End();
        }


        private void Activity() 
        {
            Random random = new Random();
            int promptIndex = random.Next(Prompts.Count);
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {Prompts[promptIndex]} ---");

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < _time * 1000)
            {
                Console.Write("> ");
                string response = Console.ReadLine();
                if (!string.IsNullOrEmpty(response))
                {
                    UserResponses.Add(response);
                }
            }
            stopwatch.Stop();
            return;
        }

        private void WriteList()
        {
            for (int i = 0; i < UserResponses.Count; i++)
            {
                Console.WriteLine(UserResponses[i]);
            }
        }
    }

}

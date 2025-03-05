using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    internal class ReflectionActivity : Activity
    {
        public ReflectionActivity(string name, int time) : base(name, time) {
            _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        private static readonly List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
        private static readonly List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"};
        public override void Start()
        {
            base.Start();
            Activity();
            End();
        }


        private void Activity()
        {
            Random rand = new Random();
            Console.WriteLine(Prompts[rand.Next(Prompts.Count)]);
            Thread.Sleep(2000);
            int elapsedTime = 0;
            while (elapsedTime < _time)
            {
                Console.WriteLine(Questions[rand.Next(Questions.Count)]);
                RunSpinner(8);
                elapsedTime += 8;
            }
        }

        private void RunSpinner(int seconds)
        {
            char[] spinner = { '/', '-', '\\', '|' };
            for (int i = 0; i < seconds * 2; i++)
            {
                Console.Write($"{spinner[i % 4]}\r");
                Thread.Sleep(500);
            }
        }
    }

}

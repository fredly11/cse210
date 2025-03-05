using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop04
{
    internal class BreathingActivity : Activity
    {
        public BreathingActivity(string name, int time) : base(name, time) {
            _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }
        public override void Start()
        {
            base.Start();
            Activity();
            End();
        }
        

        private void Activity()
        {
            int elapsedTime = 0;
            while (elapsedTime < _time)
            {
                Console.WriteLine("Breathe in...");
                Thread.Sleep(5000);
                elapsedTime += 5;

                Console.WriteLine("Breathe out...");
                Thread.Sleep(5000);
                elapsedTime += 5;
            }
        }
    }

}

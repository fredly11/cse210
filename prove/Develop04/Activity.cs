using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Develop04
{
    internal class Activity
    {
        protected int _time;
        protected string _name;
        protected string _description;
        public Activity(string name, int time) {
            _name = name; 
            _time = time;
        }
        public virtual void Start()
        {
            Console.WriteLine($"Starting {_name} activity for {_time} seconds! {_description}");
            Thread.Sleep(2000);
        }

        public virtual void End()
        {
            Console.WriteLine($"{_name} completed with a time of {_time} seconds.");
            Thread.Sleep(5000);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning04
{
    internal class Assignment
    {
        protected string _studentName;
        
        private string _topic { get; }

        public Assignment(string name, string topic)
        {
            _studentName = name;
            _topic = topic;
        }

        public string GetSummary()
        {
            return $"Student: {_studentName} Topic: {_topic}";
        }
    }
}

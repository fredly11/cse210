using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning03
{
    internal class Fraction
    {
        private int _topNumber { get; set; }
        private int _bottomNumber { get; set; }

        public Fraction()
        {
            _topNumber = 1;
            _bottomNumber = 1;
        }

        public Fraction(int TopNumber)
        {
            _topNumber = TopNumber;
            _bottomNumber = 1;
        }

        public Fraction(int TopNumber, int BottomNumber)
        {
            _topNumber = TopNumber;
            _bottomNumber = BottomNumber;
        }

        public string GetFractionString()
        {
            return $"{_topNumber}/{_bottomNumber}";
        }

        public float GetDecimalValue()
        {
            return (float)_topNumber / (float)_bottomNumber;
        }
    }
}

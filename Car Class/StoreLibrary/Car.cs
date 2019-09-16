using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClass
{
    public class Car
    {
        private int _year;
        private string _make;
        private int _speed;

        public Car()
        {
            Year = 0;
            Make = "";
            Speed = 0;
        }

        public Car(int year, string make)
        {
            Year = year;
            Make = make;
            Speed = 0;
        }

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
            }
        }

        public string Make
        {
            get
            {
                return _make;
            }

            set
            {
                _make = value;
            }
        }

        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public void Accelerate()
        {
            _speed += 5;
        }

        public void Brake()
        {
            if (_speed != 0)
            {
                _speed -= 5;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class TireFactory
    {
        public Tire addTires(double pressure,int age)
        {
            return new Tire(pressure,age);
        }
    }
}

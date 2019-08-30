using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        private int speed;

        public Engine(int engineSpeed, int enginePower)
        {
            this.speed = engineSpeed;
            this.Power = enginePower;

        }

        public int Power { get; private set; }
    }
}

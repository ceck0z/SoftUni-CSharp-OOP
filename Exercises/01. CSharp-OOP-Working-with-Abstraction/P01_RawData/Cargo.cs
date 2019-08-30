using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        private int weight;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.weight = cargoWeight;
            this.Type = cargoType;
        }

        public string Type { get; private set; }
        
    }
}

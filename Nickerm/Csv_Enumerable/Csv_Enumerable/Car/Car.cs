using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Csv_Enumerable
{
    public class Car
    {
        [Name("model")]
        public string Model { get; set; }
        [Name("miles per gallon")]
        public double MilesPerGalon { get; set; }
        [Name("cylinder")]
        public int Cylinder { get; set; }
        [Name("horsepower")]
        public int HorsePower { get; set; }
        [Name("rear axle ratio")]
        public double RearAxleRatio { get; set; }
        [Name("weight")]
        public double Weight { get; set; }
        [Name("acceleration")]
        public double Acceleration { get; set; }
        [Name("engine cylinder configuration")]
        public int EngineCylinderConfig { get; set; }
        [Name("reg date")]
        public DateTime RegDate { get; set; }
    }
}

using BusinessLayer.Operation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class CalculeteRequest
    {
        public int MaxPointX { get; set; }
        public int MaxPointY { get; set; }
        public List<Rovers> Rovers { get; set; }
    }
    public class Rovers
    {
        public string RoverName { get; set; }
        public int RoverXCordinate { get; set; }
        public int RoverYCordinate { get; set; }
        public string RoverMove { get; set; }
        public Directions Directions { get; set; }
    }

}

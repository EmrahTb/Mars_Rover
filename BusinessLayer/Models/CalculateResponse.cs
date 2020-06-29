using BusinessLayer.Operation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class CalculateResponse
    {
        public string RoverName { get; set; }
        public int RoverXCordinate { get; set; }
        public int RoverYCordinate { get; set; }
        public bool Error { get; set; }
        public Directions RoverDirection { get; set; }

    }
}

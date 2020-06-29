using BusinessLayer.Operation;
using BusinessLayer.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRoverTest
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Calculate calculate = new Calculate();
            CalculeteRequest calculeteRequest = new CalculeteRequest();
            calculeteRequest.MaxPointX = 10;
            calculeteRequest.MaxPointY = 9;
            List<Rovers> rover = new List<Rovers>();

            rover.Add(new Rovers { RoverName = "First Rover" , RoverXCordinate = 2, RoverYCordinate = 3, Directions = Directions.W, RoverMove = "RM"   });
            calculeteRequest.Rovers = rover;

            var result = calculate.Moving(calculeteRequest);

            var actualOutput = $"{result[0].RoverXCordinate} {result[0].RoverYCordinate} {result[0].RoverDirection.ToString()} {result[0].Error}";
            var expectedOutput = "2 4 N False";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Test2()
        {
            Calculate calculate = new Calculate();
            CalculeteRequest calculeteRequest = new CalculeteRequest();
            calculeteRequest.MaxPointX = 14;
            calculeteRequest.MaxPointY = 12;

            List<Rovers> rover = new List<Rovers>();
            rover.Add(new Rovers { RoverName = "First Rover", RoverXCordinate = 6, RoverYCordinate = 9, Directions = Directions.W, RoverMove = "RMLM" });
            calculeteRequest.Rovers = rover;

            var result = calculate.Moving(calculeteRequest);

            var actualOutput = $"{result[0].RoverXCordinate} {result[0].RoverYCordinate} {result[0].RoverDirection.ToString()} {result[0].Error}";
            var expectedOutput = "5 10 W False";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

    }
}
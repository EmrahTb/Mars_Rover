using BusinessLayer.Models;
using BusinessLayer.Operation;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Operation
{
    public enum Directions
    {
        N = 1,
        S = 2,
        E = 3,
        W = 4
    }
    public class Calculate : ICalculate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Calculate()
        {
            X = Y = 0;
            Direction = Directions.N;
        }

        private void Rotate90Left()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void Rotate90Right()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Y += 1;
                    break;
                case Directions.S:
                    this.Y -= 1;
                    break;
                case Directions.E:
                    this.X += 1;
                    break;
                case Directions.W:
                    this.X -= 1;
                    break;
                default:
                    break;
            }
        }

        public List<CalculateResponse> Moving(CalculeteRequest calculateRequest)
        {
            List<CalculateResponse> calculateResponse = new List<CalculateResponse>();
            foreach (var rovers in calculateRequest.Rovers)
            {
                X = rovers.RoverXCordinate;
                Y = rovers.RoverYCordinate;
                Direction = rovers.Directions;
                foreach (var move in rovers.RoverMove)
                {
                    switch (move)
                    {
                        case 'M':
                            this.MoveInSameDirection();
                            break;
                        case 'L':
                            this.Rotate90Left();
                            break;
                        case 'R':
                            this.Rotate90Right();
                            break;
                        default:
                            Console.WriteLine($"Invalid Character {move}");
                            break;
                    }
                }

                bool error = false;
                if (this.X < 0 || this.X > calculateRequest.MaxPointX || this.Y < 0 || this.Y > calculateRequest.MaxPointY)
                {
                    error = true;
                }
                calculateResponse.Add(new CalculateResponse { RoverName = rovers.RoverName, RoverXCordinate = X, RoverYCordinate = Y, RoverDirection = Direction, Error = error });
            }
            return calculateResponse;
        }
    }
}

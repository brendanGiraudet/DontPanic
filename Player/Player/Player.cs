using System;
using System.Collections.Generic;

namespace DontPanic
{
    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    public class Player
    {
        static void Main(string[] args)
        {
            var elevators = GetElevetors();
            elevators.ForEach(Console.Error.WriteLine);

            // game loop
            while (true)
            {
                var inputs = Console.ReadLine().Split(' ');
                int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
                int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
                string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT

                var currentElevator = elevators.Find(e => e.Floor.Equals(cloneFloor));

                if (currentElevator != null && NeedBlock(currentElevator, clonePos, direction))
                {
                    Console.WriteLine("BLOCK");
                    continue;
                }
                else
                {
                    Console.WriteLine("WAIT");
                }
            }
        }

        public static bool NeedBlock(Elevator currentElevator, int clonePos, string direction)
        {
            return (currentElevator.Pos < clonePos && direction.Equals("RIGHT"))
                || (currentElevator.Pos > clonePos && direction.Equals("LEFT"));
        }

        private static List<Elevator> GetElevetors()
        {
            var inputs = Console.ReadLine().Split(' ');
            int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
            int exitPos = int.Parse(inputs[4]); // position of the exit on its floor

            List<Elevator> elevators = new List<Elevator>();
            int nbElevators = int.Parse(inputs[7]); // number of elevators
            for (int i = 0; i < nbElevators; i++)
            {
                inputs = Console.ReadLine().Split(' ');

                var elevator = new Elevator
                {
                    Floor = int.Parse(inputs[0]), // floor on which this elevator is found
                    Pos = int.Parse(inputs[1]) // position of the elevator on its floor
                };
                elevators.Add(elevator);
            }
            elevators.Add(new Elevator
            {
                Floor = exitFloor,
                Pos = exitPos
            });

            return elevators;
        }
    }

    public class Elevator
    {
        public int Floor { get; set; }
        public int Pos { get; set; }

        public override string ToString()
        {
            return $"Floor : {Floor} Pos : {Pos}";
        }
    }
}
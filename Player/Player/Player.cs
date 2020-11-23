using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace DontPanic
{
    /**
     * Auto-generated code below aims at helping you parse
     * the standard input according to the problem statement.
     **/
    class Player
    {
        static void Main(string[] args)
        {
            string[] inputs;
            inputs = Console.ReadLine().Split(' ');
            int nbFloors = int.Parse(inputs[0]); // number of floors
            int width = int.Parse(inputs[1]); // width of the area
            int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
            int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
            int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
            int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
            int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)

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
            for (int i = 1; i < elevators.Count; i++)
            {
                var oldElevator = elevators[i - 1];
                var currentElevator = elevators[i];
                currentElevator.NeedBlock = (oldElevator.Pos - currentElevator.Pos) > 0;
            }
            elevators.ForEach(Console.Error.WriteLine);

            var index = 0;
            // game loop
            while (true)
            {
                inputs = Console.ReadLine().Split(' ');
                int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
                int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
                string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");

                if (index != cloneFloor)
                {
                    cloneFloor = index;
                    var currentElevator = elevators[index];
                    if (currentElevator.NeedBlock)
                    {
                        Console.WriteLine("BLOCK");
                        continue;
                    }
                }

                Console.WriteLine("WAIT");
            }
        }
    }

    class Elevator
    {
        public int Floor { get; set; }
        public int Pos { get; set; }
        public bool NeedBlock { get; set; }

        public override string ToString()
        {
            return $"Floor : {Floor} Pos : {Pos} NeedBlock : {NeedBlock}";
        }
    }
    class Clone
    {

    }
    class Floor
    {
        public bool NeedBlock { get; set; }
    }
}
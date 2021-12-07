// See https://aka.ms/new-console-template for more information

public partial class Program {

    private static readonly string InputFileName = "input.txt";

    private const string FORWARD = "forward";
    private const string UP = "up";
    private const string DOWN = "down";

    private static int horizontal = 0, vertical = 0, aim = 0;

    public static void Main(string[] args)
    {
        PartOne();

        ResetVariables();

        PartTwo();
    }

    private static void ResetVariables()
    {
        horizontal = 0;
        vertical = 0; 
        aim = 0;
    }

    //Follow the plot and calculate the depth and horizontal, multiply the result together
    private static void PartOne()
    {
        int horizontal = 0, vertical = 0;

        using(var fsr = new StreamReader(new FileStream(InputFileName, FileMode.Open)))
        {
            //Read the first part of the route in
            var command = fsr.ReadLine();

            //read until there is no more
            while(!string.IsNullOrEmpty(command))
            {
                //Split into command and value
                string[] cmdParts = command.Split(" ");
                string cmd = cmdParts[0];
                int value = Convert.ToInt32(cmdParts[1]);

                if(cmd == FORWARD){
                    horizontal += value;
                } else if (cmd == UP || cmd == DOWN)
                {
                    vertical += ((cmd == UP ? -1 : 1) * value);
                }

                command = fsr.ReadLine();
            }
        }

        //Mulitply the resultants
        Console.WriteLine($"Result {horizontal} x {vertical} is {horizontal * vertical}");
    }

    //Now factor in the aim moving up and down instead of moving up and down
    private static void PartTwo()
    {
        using(var fsr = new StreamReader(new FileStream(InputFileName, FileMode.Open)))
        {
            //Read the first part of the route in
            var command = fsr.ReadLine();

            //read until there is no more
            while(!string.IsNullOrEmpty(command))
            {
                //Split into command and value
                string[] cmdParts = command.Split(" ");
                string cmd = cmdParts[0];
                int value = Convert.ToInt32(cmdParts[1]);

                if(cmd == FORWARD)
                {
                    horizontal += value;
                    vertical += (aim * value);
                } else if (cmd == UP || cmd == DOWN)
                {    
                    aim += ((cmd == UP ? -1 : 1) * value);
                }

                command = fsr.ReadLine();
            }
        }

        //Mulitply the resultants
        Console.WriteLine($"Result with aim {horizontal} x {vertical} is {horizontal * vertical}");
    }

}


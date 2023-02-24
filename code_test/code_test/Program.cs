class Program
{
    private static int roomSizeWidth; //Width (x-axel)
    private static int roomSizeLength; //Length (y-axel)
    private static int carPositionWidth; //Width (x-axel)
    private static int carPositionLength; //Length (y-axel)
    private static string? carPositionDirection; //direction

    public static void Main()
    {
        Console.WriteLine("Ange rumsstorlek");
        SetRoomSize();

        Console.WriteLine("Ange bilens startposition");
        SetCarPosition();

        Console.WriteLine("Ange testkommando för simulering");
        TryCarCommands();
    }

    private static void SetRoomSize()
    {
        string? line = Console.ReadLine();
        if (line is not null)
        {
            string[]? array = line.Split();
            roomSizeWidth = Convert.ToInt32(array[0]);
            roomSizeLength = Convert.ToInt32(array[1]);
        }
    }

    private static void SetCarPosition()
    {
        string? line = Console.ReadLine();
        if (line is not null)
        {
            string[]? array = line.Split();
            carPositionWidth = Convert.ToInt32(array[0]);
            carPositionLength = Convert.ToInt32(array[1]);
            carPositionDirection = array[2].ToUpper();
        }
        if (IsCarCrash())
        {
            Console.WriteLine("Bilens startposition ligger utanför rummets storlek.");
            Console.WriteLine("Ange ny startposition.");
            SetCarPosition();
        }
    }

    private static void TryCarCommands()
    {
        string line = Console.ReadLine().ToUpper();

        if (line is not null)
        {
            int result = 0;

            foreach (char c in line)
            {
                result++;

                if (c.Equals('F') || c.Equals('B'))
                    MoveCar(c);
                else if (c.Equals('R') || c.Equals('L'))
                    ChangeCarDirection(c);

                if (IsCarCrash())
                {
                    Console.WriteLine("Bilen har crashat på kommando " + result + " (" + c + ")");
                    break;
                }
            }
            if (!IsCarCrash())
            {
                Console.WriteLine("Simuleringen lyckades! Bilens slutposition är: " + Convert.ToString(carPositionWidth) +
                                    " " + Convert.ToString(carPositionLength) + " " + carPositionDirection);
            }
        }
    }

    private static void MoveCar(char direction)
    {
        if (direction.Equals('F'))
        {
            if (carPositionDirection == "N")
                carPositionLength = carPositionLength + 1;

            else if (carPositionDirection == "E")
                carPositionWidth = carPositionWidth + 1;

            else if (carPositionDirection == "S")
                carPositionLength = carPositionLength - 1;

            else if (carPositionDirection == "W")
                carPositionWidth = carPositionWidth - 1;
        }

        else if (direction.Equals('B'))
        {
            if (carPositionDirection == "N")
                carPositionLength = carPositionLength - 1;

            else if (carPositionDirection == "E")
                carPositionWidth = carPositionWidth - 1;

            else if (carPositionDirection == "S")
                carPositionLength = carPositionLength + 1;

            else if (carPositionDirection == "W")
                carPositionWidth = carPositionWidth + 1;
        }
    }

    private static void ChangeCarDirection(char direction)
    {
        if (direction.Equals('R'))
        {
            if (carPositionDirection == "N")
                carPositionDirection = "E";

            else if (carPositionDirection == "E")
                carPositionDirection = "S";

            else if (carPositionDirection == "S")
                carPositionDirection = "W";

            else if (carPositionDirection == "W")
                carPositionDirection = "N";
        }
        if (direction.Equals('L'))
        {
            if (carPositionDirection == "N")
                carPositionDirection = "W";

            else if (carPositionDirection == "W")
                carPositionDirection = "S";

            else if (carPositionDirection == "S")
                carPositionDirection = "E";

            else if (carPositionDirection == "E")
                carPositionDirection = "N";
        }
    }

    private static Boolean IsCarCrash()
    {
        if (carPositionWidth < 1 || carPositionWidth > roomSizeWidth ||
        carPositionLength < 1 || carPositionLength > roomSizeLength)
        {
            return true;
        }

        return false;
    }
}
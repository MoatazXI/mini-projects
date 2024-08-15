
using System.Text;

[Flags]
enum CharacterType
{
    None = 0,
    SmallChars = 1,
    CapitalChars = 2,
    SpecialChars = 4,
    Numbers = 8
}

/// <summary>
/// Represents the entry point of the program.
/// </summary>
internal class Program
{
    private const string smallAlphabet = "abcdefghijklmnopqrstuvwxyz";
    private const string capitalAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string specialChars = "!@#$%^&*({})<>:'?~+_-";
    private const string numbers = "123456789";
    static Random rnd = new Random();



    private static void generateRandomString(int length, CharacterType options)
    {


        string CharacterSet = "";
        if ((options & CharacterType.CapitalChars) == CharacterType.CapitalChars) CharacterSet += capitalAlphabet;
        if ((options & CharacterType.SmallChars) == CharacterType.SmallChars) CharacterSet += smallAlphabet;
        if ((options & CharacterType.Numbers) == CharacterType.Numbers) CharacterSet += numbers;
        if ((options & CharacterType.SpecialChars) == CharacterType.SpecialChars) CharacterSet += specialChars;


        var randomString = new StringBuilder();

        while (randomString.Length < length)
        {
            randomString.Append(CharacterSet[rnd.Next(0, CharacterSet.Length)]);
        }

        Console.WriteLine($"Your Random String : {randomString}");
        Console.WriteLine("------------------------------------------------");

    }

    private static void generateRandomNumber(int min, int max)
    {

        int randomInt = rnd.Next(min, max + 1);
        Console.WriteLine($"Your Random Number Is : {randomInt}");
        Console.WriteLine("------------------------------------------------");
    }

    private static bool getYesOrNoResponse(string message)
    {
        Console.Write(message);
        var response = Console.ReadLine().ToLower().Trim();
        return response == "yes";
    }
    private static int getIntInput(string message)
    {
        Console.Write(message);
        var response = Console.ReadLine();

        if (int.TryParse(response, out int value))
        {
            return value;
        }
        else
        {
            Console.WriteLine("Enter a Valid Number");
            return getIntInput(message);
        }
    }
    private static CharacterType getUserStringPreferences()
    {
        CharacterType userOptions = CharacterType.None;

        if (getYesOrNoResponse("do you want capital letters? (yes\\no) ")) userOptions |= CharacterType.CapitalChars;
        if (getYesOrNoResponse("do you want small letters? (yes\\no) ")) userOptions |= CharacterType.SmallChars;
        if (getYesOrNoResponse("do you want special characters? (yes\\no) ")) userOptions |= CharacterType.SpecialChars;
        if (getYesOrNoResponse("do you want numbers? (yes\\no) ")) userOptions |= CharacterType.Numbers;

        return userOptions;
    }

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1.Generate a Random Number \n2.Generate a Random String \n3.Exit");
            var selectedOption = Console.ReadLine();

            if (selectedOption == "1")
            {
                var min = getIntInput("Enter Minimum Value : ");
                var max = getIntInput("Enter Maximum Value : ");

                if (min > max)
                {
                    Console.WriteLine("Invalid range. Minimum value cannot be greater than maximum value.\nTry Again!");
                    continue;
                }
                generateRandomNumber(min, max);
            }
            else if (selectedOption == "2")
            {
                Console.Write("Enter String Length : ");
                var stringLength = int.Parse(Console.ReadLine());

                if (stringLength <= 0)
                {
                    Console.WriteLine("String length must be greater than 0.\nTry Again!");
                    continue;
                }

                CharacterType userOptions = getUserStringPreferences();

                if (userOptions == CharacterType.None)
                {
                    Console.WriteLine("No character types selected. Cannot generate a string.\nTry Again!");
                    continue;
                }

                generateRandomString(stringLength, userOptions);
            }

            else if (selectedOption == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Enter a Valid Option");
            }

        }
    }


}
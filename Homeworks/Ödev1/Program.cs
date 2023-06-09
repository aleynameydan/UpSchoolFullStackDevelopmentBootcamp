using PasswordGenerator.Domain;

var choosingCharacters = new ChoosingCharacters();

Console.Write("Include numbers?");
string answer4Numbers = Console.ReadLine();

switch (answer4Numbers)
{
    case "Y":
        ChoosingCharacters.AddNumbers();
        break;
    case "y":
        ChoosingCharacters.AddNumbers();
        break;
    default:
        break;
}
Console.Write("Include lowercase?");
string answer4Lcase = Console.ReadLine();

switch (answer4Lcase)
{
    case "Y":
        ChoosingCharacters.AddLower();
        break;
    case "y":
        ChoosingCharacters.AddLower();
        break;
    default:
        break;
}

Console.Write("Include uppercase?");
string answer4Ucase = Console.ReadLine();

switch (answer4Ucase)
{
    case "Y":
        ChoosingCharacters.AddUpper();
        break;
    case "y":
        ChoosingCharacters.AddUpper();
        break;
    default:
        break;
}

Console.Write("Include special characters?");
string answer4Special = Console.ReadLine();

switch (answer4Special)
{
    case "Y":
        ChoosingCharacters.AddSpecialCharacters();
        break;
    case "y":
        ChoosingCharacters.AddSpecialCharacters();
        break;
    default:
        break;
}

Console.Write("What is the length of the password?");
int passwordLength = Convert.ToInt32(Console.ReadLine());


Console.WriteLine(choosingCharacters.GetRandomPassword(passwordLength));
Console.ReadLine();


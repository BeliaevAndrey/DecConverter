string DecToBinOct(int num, int Base)
{
    string result = string.Empty;

    while(num > 0)
    {
        result = Convert.ToString(num % Base) + result;
        num /= Base;
    }
    return result;
}

// 0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15
// 0 1 2 3 4 5 6 7 8 9 A  B  C  D  E  F

string DecToHex(int num, int Base)
{
    string result = string.Empty;
    while(num > 0)
    {
        int digit = num % Base;

        switch(digit)
        {
            case 15:
                result = "F" + result;
                break;
            case 14:
                result = "E" + result;
                break;
            case 13:
                result = "D" + result;
                break;
            case 12:
                result = "C" + result;
                break;
            case 11:
                result = "B" + result;
                break;
            case 10:
                result = "A" + result;
                break;
            default:
                result = Convert.ToString(digit) + result;
                break;
        }
        num /= Base;
    }
    return result;
}

double ToDecimal(string num, int Base)
{
    double result = 0;
    int degrees = num.Length - 1;
    if(Base == 2 || Base == 8)
    {
        for(int i = 0; i < num.Length; i++)
        {
            result += char.GetNumericValue(num[i]) * Math.Pow(Base, degrees);
            degrees--;
        }
    }
    else
    {
        for(int i = 0; i < num.Length; i++)
        switch(num[i].ToString().ToUpper())
        {
            case ("F"):
                result += 15 * Math.Pow(Base, degrees);
                degrees--;
                break;
            case "E":
                result += 14 * Math.Pow(Base, degrees);
                degrees--;
                break;
            case "D":
                result += 13 * Math.Pow(Base, degrees);
                degrees--;
                break;
            case "C":
                result += 12 * Math.Pow(Base, degrees);
                degrees--;
                break;
            case "B":
                result += 11 * Math.Pow(Base, degrees);
                degrees--;
                break;
            case "A":
                result += 10 * Math.Pow(Base, degrees);
                degrees--;
                break;
            default:
                result += char.GetNumericValue(num[i]) * Math.Pow(Base, degrees);
                degrees--;
                break;
        }
        
    }

    return result;
}

void fromDecChoice()
{
    Console.Write("Input a number to convert: ");
    int number = Convert.ToInt32(Console.ReadLine());
    Console.Write("Input a base (2, 8, 16): ");
    int basement = Convert.ToInt32(Console.ReadLine());

    if(basement == 2 || basement == 8)
        Console.WriteLine($"{DecToBinOct(number, basement)}");
    else 
        if(basement == 16)
            Console.WriteLine($"{DecToHex(number, basement)}");
    else
        Console.WriteLine("Wrong base");
}

void toDecChoice()
{
    Console.Write("Input a base (2, 8, 16): ");
    int basement = Convert.ToInt32(Console.ReadLine());
    Console.Write("Input a number to convert: ");
    string number = Console.ReadLine();
    if(basement == 2 || basement == 8 || basement == 16)
        Console.WriteLine($"{ToDecimal(number, basement)}");
    else
        Console.WriteLine("Wrong base");
}



string way = string.Empty;
Console.Write("Choose a way fromDec/toDec: ");
way = Console.ReadLine().ToLower();
if(way == "fromdec")
    fromDecChoice();
else
    if(way == "todec")
        toDecChoice();
else
    Console.WriteLine("No such way available");

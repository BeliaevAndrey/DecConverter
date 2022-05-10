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

string DecToHex(int num, int Base)
{
    string result = string.Empty;
    string[] hexAlphabet = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
    while(num > 0)
    {
        int digit = num % Base;
        result = hexAlphabet[digit] + result;
        
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
        string[] hexAlphabet = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
        for(int i = 0; i < num.Length; i++)
        {
            for(int j = 0; j < 16; j++)
            {
                if(num[i].ToString().ToUpper() == hexAlphabet[j])
                {
                    result += j * Math.Pow(Base, degrees);
                    degrees--;
                }
            }
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


Console.WriteLine("Greetings!\nThis is a connverter from Decimal to Binary/Octal/Hexadecimal and back.\n");

string way = string.Empty;
while(way != "fromdec" || way != "todec")
{
    Console.Write("Choose a direction fromDec/toDec (or 'q' to exit): ");
    way = Console.ReadLine().ToLower();
    if(way == "fromdec")
        fromDecChoice();
    else
        if(way == "todec")
            toDecChoice();
    else
        if(way == "q") break;
    else
        Console.WriteLine("No such direction available. Try again please.");
}
string DecToBinOct(int num, int Base)   // Method to convert a number from decimal to binary or octal
{
    string result = string.Empty;   // Initialize result string

    while(num > 0)
    {
        result = Convert.ToString(num % Base) + result; // Forming a result string
        num /= Base;    // Eliminating a lesser digit
    }
    return result;
}

string DecToHex(int num, int Base)  // Method to convert a number from decimal to hexadcimal
{
    string result = string.Empty;
    // An array contents hexadecimal digit set (0 -- F):
    string[] hexAlphabet = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
    while(num > 0)
    {
        int digit = num % Base;     // Taking a lesser digit
        result = hexAlphabet[digit] + result;   // Forming a result string
        
        num /= Base;    // Eliminating a lesser digit
    }
    return result;
}

double ToDecimal(string num, int Base)  // Method to convert a number to decimal from binary, octal or hexadcimal
{
    double result = 0;
    int degrees = num.Length - 1;
    if(Base == 2 || Base == 8)
    {
        for(int i = 0; i < num.Length; i++)
        {
            result += char.GetNumericValue(num[i]) * Math.Pow(Base, degrees);   // Forming a result string
            degrees--;  // decrement degree
        }
    }
    else
    {
        // An array contents hexadecimal digit set (0 -- F):
        string[] hexAlphabet = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
        for(int i = 0; i < num.Length; i++)
            for(int j = 0; j < 16; j++)
                if(num[i].ToString().ToUpper() == hexAlphabet[j])   // Index of value in array equals to coefficient at 16^degree
                {
                    result += j * Math.Pow(Base, degrees);  // Forming a result string
                    degrees--;  // decrement degree
                }
        
    }

    return result;
}

void fromDecChoice()    // Method to get and show result of convertion from decimal
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

void toDecChoice()  // Method to get and show result of convertion to decimal
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

// Greeting line
Console.WriteLine("Greetings!\nThis is a connverter from Decimal to Binary/Octal/Hexadecimal and back.\n");

// Direction choice block, also contents cycle and exit option
string direction = string.Empty;
while(direction != "fromdec" || direction != "todec")
{
    Console.Write("Choose a direction fromDec/toDec (or 'q' to exit): ");
    direction = Console.ReadLine().ToLower();
    if(direction == "fromdec")
        fromDecChoice();
    else
        if(direction == "todec")
            toDecChoice();
    else
        if(direction == "q") break;
    else
        Console.WriteLine("No such direction available. Try again please.");
}
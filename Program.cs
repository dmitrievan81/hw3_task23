// The program calculates the table of cubes.

using System;

public class Point3d
{
    public double x=0;
    public double y=0;
    public double z=0;
    
    public Point3d(double X, double Y, double Z)
    {
        x = X;
        y = Y;
        z = Z;
    }
}

class Program
{
    public void DisplayTableOfPow3(int n) {
        string str_tmpl = "{0} -> {1}";
        string str_tbl = "";
        bool is_first_str = true;
        for (int i = 1; i < n+1; i++) {
            int res = i*i*i;
            if (is_first_str) {
                str_tbl = res.ToString();
                is_first_str = false;
                continue;
            }
            str_tbl = str_tbl + "," + res.ToString();
        }
        Console.WriteLine(String.Format(str_tmpl, n, str_tbl));
    }

    public double GetDistance(Point3d p1, Point3d p2)
    {
        return Math.Sqrt(Math.Pow(p2.x-p1.x,2) + Math.Pow(p2.y-p1.y,2) + Math.Pow(p2.z-p1.z,2));
    }

    public Point3d GetPoint3d(String VarName) {
        string prompt = "Enter coordinates of point {0}:";
        Console.WriteLine(String.Format(prompt, VarName));
        double x =  Get1Coordinate("x");
        double y =  Get1Coordinate("y");
        double z =  Get1Coordinate("z");
        
        return new Point3d(x, y, z);;
    }
   public double Get1Coordinate(string VarName)
    {
        double res;
        string input;
        bool is_number = false;
        do
        {
            Console.WriteLine(String.Format("Enter a double number: {0} = ", VarName));
            input = Console.ReadLine();
            
            is_number = double.TryParse(input, out res);
            if(!is_number) {
                Console.WriteLine(String.Format("The {0} is not a double number!", res));
            }
            
        } while (!is_number);

        return res;
    }

   public int GetNumber(string VarName)
    {
        int res;
        string input;
        bool is_number = false;
        do
        {
            Console.WriteLine(String.Format("Enter a number: {0} = ", VarName));
            input = Console.ReadLine();
            
            is_number = int.TryParse(input, out res);
            
            if(!is_number) {
                Console.WriteLine(String.Format("The {0} is not a number!", res));
            }

        } while (!is_number);

        return res;
    }
    
    public bool TestNumber_3c(int num) {
        
        if (num >= 100 && num < 1000) {
            return true;
        } else {
            return false;
        }
    }
    public bool TestNumber_5d(int num) {
        
        if (num >= 10000 && num < 100000) {
            return true;
        } else {
            return false;
        }
    }
    public bool TestOnPalindrome(int num) {
        
        List<int> digits = ConvertNumberToArrayOfDigit(num);
        bool res = true;
        int count = digits.Count();
        int mid = digits.Count() / 2;
        for(int i = 0; i <= mid; i++){
            if (digits[i] != digits[count-i-1]) {
                res = false;
                break;
            }
        }
        return res;
    }
    public List<int> ConvertNumberToArrayOfDigit(int num)
    {
        List<int> DigitOfNumber = new List<int>();
        int Rest = 0;
        int LastNumber = num;
        int Base = 10;
        while(LastNumber != 0)
        {
            Rest = LastNumber % Base;
            DigitOfNumber.Add(Rest);
            LastNumber = (LastNumber - Rest) / Base;
        }
        return DigitOfNumber;
    }
    public void PrintNumberInDecimalNotation(int Number, List<int> NumberInDecimalNotation)
    {
        string Result = GetStringToPrintNumberInDecimalNotation(NumberInDecimalNotation);
        Console.WriteLine(String.Format("{0} = {1}", Number, Result));
    }

    public string GetStringToPrintNumberInDecimalNotation(List<int> NumberInDecimalNotation)
    {
        string Result = "";
        bool is_first_row = true;
        int MaxPower = 0;
        foreach(int digit in NumberInDecimalNotation) {
            
            if(is_first_row) {
                Result = Result + String.Format("{0}", digit, MaxPower);
                is_first_row = false;
                MaxPower = MaxPower + 1;
                continue;
            }
            string text_format = "{0}*10^{1} + ";
            if (MaxPower == 1) {
                text_format = "{0}*10 + ";
            }
            Result = String.Format(text_format, digit, MaxPower) + Result;
            MaxPower = MaxPower + 1;
        }
        return Result;
    }

    public static void Main(string[] args)
    {
        Program pr = new Program(); // Creating a class Object  
        Console.WriteLine("The program calculates the table of cubes.");

        int N = pr.GetNumber("N");
        pr.DisplayTableOfPow3(N);
        
    }
}
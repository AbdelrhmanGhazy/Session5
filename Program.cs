using System;

class Program
{
    static void SquareVal(int x)
    {
        x = x * x;
    }

    static void SquareRef(ref int x)
    {
        x = x * x;
    }

    class Sample
    {
        public int Data = 10;
    }

    static void ModifyByVal(Sample s)
    {
        s.Data = 20;
        s = new Sample { Data = 100 };
    }

    static void ModifyByRef(ref Sample s)
    {
        s.Data = 30;
        s = new Sample { Data = 200 };
    }

    static void CalculateSumSub(double a, double b, out double sum, out double sub)
    {
        sum = a + b;
        sub = a - b;
    }

    static int SumOfDigits(int n)
    {
        int sum = 0;
        n = Math.Abs(n);
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static void MinMaxArray(int[] arr, ref int min, ref int max)
    {
        if (arr == null || arr.Length == 0) return;
        min = arr[0];
        max = arr[0];
        foreach (int val in arr)
        {
            if (val < min) min = val;
            if (val > max) max = val;
        }
    }

    static long Factorial(int n)
    {
        if (n < 0) return -1;
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static string ChangeChar(string str, int index, char newChar)
    {
        if (string.IsNullOrEmpty(str) || index < 0 || index >= str.Length) return str;
        char[] chars = str.ToCharArray();
        chars[index] = newChar;
        return new string(chars);
    }

    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    struct Person
    {
        public string Name;
        public int Age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    [Flags]
    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        Execute = 8
    }

    enum Colors
    {
        Red,
        Green,
        Blue
    }

    struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanceTo(Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - X, 2) + Math.Pow(p2.Y - Y, 2));
        }
    }

    static void Main()
    {
        int v = 5;
        SquareVal(v);
        SquareRef(ref v);

        Sample obj1 = new Sample();
        ModifyByVal(obj1);
        ModifyByRef(ref obj1);

        CalculateSumSub(10, 5, out double sum, out double sub);

        Console.Write("Enter a number: ");
        if (int.TryParse(Console.ReadLine(), out int inputNum))
        {
            Console.WriteLine($"The sum of the digits of the number {inputNum} is: {SumOfDigits(inputNum)}");
        }

        bool primeResult = IsPrime(7);

        int[] numbers = { 5, 2, 9, 1, 7 };
        int minVal = 0, maxVal = 0;
        MinMaxArray(numbers, ref minVal, ref maxVal);

        long factResult = Factorial(5);

        string modifiedStr = ChangeChar("Hello", 1, 'a');

        foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
        {
            Console.WriteLine(day);
        }

        Person[] persons = new Person[3];
        persons[0] = new Person("Alice", 25);
        persons[1] = new Person("Bob", 30);
        persons[2] = new Person("Charlie", 22);
        foreach (Person p in persons)
        {
            Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
        }

        Console.Write("Enter season name: ");
        string seasonInput = Console.ReadLine();
        if (Enum.TryParse(seasonInput, true, out Season selectedSeason))
        {
            switch (selectedSeason)
            {
                case Season.Spring:
                    Console.WriteLine("Spring: March to May");
                    break;
                case Season.Summer:
                    Console.WriteLine("Summer: June to August");
                    break;
                case Season.Autumn:
                    Console.WriteLine("Autumn: September to November");
                    break;
                case Season.Winter:
                    Console.WriteLine("Winter: December to February");
                    break;
            }
        }

        Permissions myPerms = Permissions.Read | Permissions.Write;
        myPerms |= Permissions.Execute;
        myPerms &= ~Permissions.Write;
        bool hasDelete = (myPerms & Permissions.Delete) == Permissions.Delete;

        Console.Write("Enter color: ");
        string colorInput = Console.ReadLine();
        if (Enum.TryParse(colorInput, true, out Colors primaryColor))
        {
            Console.WriteLine($"{primaryColor} is a primary color.");
        }
        else
        {
            Console.WriteLine("Not a primary color.");
        }

        Point p1 = new Point(0, 0);
        Point p2 = new Point(3, 4);
        double distance = p1.DistanceTo(p2);

        Person[] userPersons = new Person[3];
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"Enter Person {i + 1} Name: ");
            string name = Console.ReadLine();
            Console.Write($"Enter Person {i + 1} Age: ");
            int age = int.Parse(Console.ReadLine());
            userPersons[i] = new Person(name, age);
        }
        Person oldest = userPersons[0];
        foreach (Person p in userPersons)
        {
            if (p.Age > oldest.Age) oldest = p;
        }
        Console.WriteLine($"Oldest Person: {oldest.Name}, Age: {oldest.Age}");
    }
}

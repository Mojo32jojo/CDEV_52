namespace Console_lern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Your name: ");
            var name = Console.ReadLine();

            Console.Write("Your age: ");
            var age = checked((byte)int.Parse(Console.ReadLine()));

            Console.WriteLine("Your name is {0} and age is {1} ", name, age);

            Console.Write("What is your favorite day of week? ");
            var day = (DayOfWeek)int.Parse(Console.ReadLine());
            Console.WriteLine("Your favorite day is {0}", day);

            Console.Write("Enter your birthdate: ");
            var b_date = Console.ReadLine();
            Console.WriteLine("Your birthdate is {0}", b_date);

            Console.ReadKey();
        }
    }
}

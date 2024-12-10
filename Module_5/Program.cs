using System;

class Program
{
    static void Main(string[] args)
    {
        var tuple = Anketa();

        ShowAnket(tuple);

        Console.ReadKey();
    }
    //метод запрашивает данные о пользователе и возвращает кортеж с данными. Отличается от того, что есть в подсказках к заданию. 
    static (string name, string surName, int age, bool havePet, int numberOfPets, string[] petsNames, int numberOfFavColors, string[] favColors) Anketa()
    {
        Console.WriteLine("Введите имя");
        string name = CheckStr();

        Console.WriteLine("Введите фамилию");
        string surName = CheckStr();

        Console.WriteLine("Введите ваш возраст (цифрами)");
        int age = CheckInt();
        if (age == 0)
        {
            Console.WriteLine("Ни кто не поверит что Вам 0 лет. Введите корректный возраст");
            age = CheckInt();
        }

        Console.WriteLine("У Вас есть домашнее животное? (да/нет)");
        string yesNoPet = CheckStr();
        bool havePet = false;
        int numberOfPets = 0;
        var petsNames = new string[0];
        if (yesNoPet == "да" || yesNoPet == "Да" || yesNoPet == "yes" || yesNoPet == "Yes")
        {
            havePet = true;
            Console.WriteLine("Сколько у Вас питомцев? (цифрами)");
            
            numberOfPets = CheckInt();

            petsNames = new string[numberOfPets];

            if (numberOfPets == 1)
                Console.WriteLine("Напишите его имя");
            else
                Console.WriteLine("Напишите их имена");

            for (int i = 0; i < numberOfPets; i++)
            {
                petsNames[i] = CheckStr(); 
            }
        }
                      
        Console.WriteLine("Сколько у Вас любимых цветов? (цифрами)");
        int numberOfFavColors = CheckInt();

        Console.WriteLine("Назовите ");
        string[] favColors = new string[numberOfFavColors];
        for (int j = 0; j < numberOfFavColors; j++)
        {
            Console.WriteLine($"Назовите цвет №{j + 1} ");
            favColors[j] = CheckStr();
        }

        return (name, surName, age, havePet, numberOfPets, petsNames, numberOfFavColors, favColors);
    }

    static int CheckInt() // Метод запрашивает текст и проверяет его на соответствие: число больше или равно нулю. По итогу возвращает число. 
    {
        int number;
        bool success = int.TryParse(Console.ReadLine(), out number);

        if (success == false || number < 0)
        {
            Console.WriteLine("Значение не верное. Введите его повторно.");
            return CheckInt();
        }
        else
        {
            return number;
        }
    }
        
    static string CheckStr() // Метод запрашивает текст и проверяет его на соответствие: введен текст, а не числа. По итогу возвращает текст
    {
        int number;
        string Str = Console.ReadLine();
        bool success = int.TryParse(Str, out number);

        if (success == true)
        {
            Console.WriteLine("Значение не верное. Введите его повторно.");
            return CheckStr();
        }
        else
        {
            return Str;
        }
    }
    // метож для вывода на экран данных кортежа Anketa()
    static void ShowAnket((string name, string surName, int age, bool havePet, int numberOfPets, string[] petsNames, int numberOfFavColors, string[] favColors)anc)
    {
        string endWord1 = "";
        string endWord2 = "";

        Console.Write($"Ваше имя: {anc.name},");
        Console.Write($" Ваша фамилия: {anc.surName},");
        Console.WriteLine($" Вам: {anc.age} лет");
        if (anc.havePet == true)
        {
            if (anc.numberOfPets > 1)
            {
                if (anc.numberOfPets < 5)
                {
                    endWord1 = "ца";         //условие для актуальных окончаний
                }
                else
                {
                    endWord1 = "цев";        //условие для актуальных окончаний
                }
                Console.Write($"У Вас есть {anc.numberOfPets} петом{endWord1} и их зовут: ");
                foreach (var elem in anc.petsNames)
                {
                    Console.Write($" {elem},");
                }
            }
            else if (anc.numberOfPets == 1)
            {
                Console.Write($"У Вас есть питомец по имени: {anc.petsNames[0]}");
            }

        }
        else if (anc.havePet == false)
        {
            Console.Write($"У Вас нет питомца");
        }

        if (anc.numberOfFavColors >= 1)          //условие для актуальных окончаний
        {
            endWord1 = "х";
            if (anc.numberOfFavColors < 5 || anc.numberOfFavColors == 10)
            {
                endWord2 = "а";
            }
            else if (anc.numberOfFavColors >= 5 || anc.numberOfFavColors == 0)
            {
                endWord2 = "ов";
            }
            else if (anc.numberOfFavColors == 1)
            {
                endWord1 = "й";
                endWord2 = "";
            }
            Console.Write($"\nУ Вас {anc.numberOfFavColors} любимы{endWord1} цвет{endWord2}: ");
            foreach (var elem in anc.favColors)
            {
                Console.Write($" {elem},");
            }
        }
        else if (anc.numberOfFavColors == 0)
        {
            Console.Write($"\nУ Вас нет любимого цвета.");
        }
    }
}
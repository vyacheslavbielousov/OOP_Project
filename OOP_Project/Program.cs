class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode; // Unicode is UTF-16LE
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("ПІБ студента: [Ваше ПІБ], курс: [Ваш курс], група: [Ваша група]");
        Console.WriteLine("Варіант завдання: Kyiv Smart City School");
        Console.WriteLine("Версія 4");
        Console.WriteLine("Старт імітації");
        Console.WriteLine("======================================================================");

        // Ініціалізація
        Teacher teacher = new Teacher("Олег Іванович", "Програмування C#");
        TrainingCourse csharpCourse = new TrainingCourse("C# Basic", teacher);

        Student student1 = new Student("Антон", 15);
        Student student2 = new Student("Вікторія", 16);

        // Демонстрація методів 2-го пріоритету
        Console.WriteLine("--- Методи 2-го пріоритету ---");
        teacher.AssignHomework(student1);

        // Демонстрація перевантажених бінарних операторів (+, -) для Курсу
        Console.WriteLine("\n--- Бінарні оператори (+, -) для взаємодії ---");
        csharpCourse += student1; // Еквівалент: csharpCourse = csharpCourse + student1;
        csharpCourse += student2;
        csharpCourse -= student1; // Відрахування

        // Демонстрація унарних операторів (++, --, +, -, !)
        Console.WriteLine("\n--- Унарні оператори ---");
        Console.WriteLine($"До (++): {student2}");
        student2++; // Підвищуємо рівень логіки на 10
        Console.WriteLine($"Після (++): {student2}");

        student2--; // Знижуємо на 5
        Console.WriteLine($"Після (--): {student2}");

        // Демонстрація true / false (наприклад, умовні оператори використовують перевантаження true/false)
        if (student2)
        {
            Console.WriteLine($"{student2.FullName} є успішним учнем (оператор true).");
        }

        // Унарний мінус (штраф) і оператор !
        student2 = -student2; // Обнулення знань
        Console.WriteLine($"Після штрафу (-): {student2}");
        if (!student2)
        {
            Console.WriteLine($"Знання {student2.FullName} дорівнюють нулю (оператор !).");
        }

        // Демонстрація бінарних математичних (*, /)
        Console.WriteLine("\n--- Бінарні арифметичні оператори (*, /) ---");
        student1++; // Підвищуємо до 25
        Console.WriteLine($"Початковий Антон: {student1}");
        student1 = student1 * 2; // Множення знань
        Console.WriteLine($"Після інтенсиву (* 2): {student1}");
        student1 = student1 / 2;
        Console.WriteLine($"Після відпочинку (/ 2): {student1}");

        // Демонстрація операторів порівняння (>, <, >=, <=, ==, !=)
        Console.WriteLine("\n--- Оператори порівняння ---");
        Student sA = new Student("Максим", 14);
        Student sB = new Student("Ірина", 15);
        sA.StudyProgramming(5); // Збільшуємо знання

        Console.WriteLine(sA);
        Console.WriteLine(sB);

        Console.WriteLine($"Максим > Ірина: {sA > sB}");
        Console.WriteLine($"Максим == Ірина: {sA == sB}");
        Console.WriteLine($"Максим != Ірина: {sA != sB}");

        Console.WriteLine("======================================================================");
        Console.WriteLine("Фініш імітації");
        Console.ReadLine();
    }
}
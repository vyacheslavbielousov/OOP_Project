class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode; // Unicode is UTF-16LE
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("ПІБ студента: [Ваше ПІБ], курс: [Ваш курс], група: [Ваша група]");
        Console.WriteLine("Варіант завдання: Kyiv Smart City School");
        Console.WriteLine("Версія 5");
        Console.WriteLine("Старт імітації");
        Console.WriteLine("======================================================================\n");

        // 1. Створення школи та перегляд контенту (Поліморфізм)
        SmartSchool school = new SmartSchool("Kyiv Smart City Hub");
        school.ShowAllContent();

        // 2. Створення учасників
        Console.WriteLine("\n--- Створення об'єктів (робота конструкторів base) ---");
        Student student1 = new Student("Іван Коваленко", 14);
        Student student2 = new Student("Марія Ткачук", 15);
        Teacher teacher = new Teacher("Олена Василівна", "Смарт-технології");
        Parent parent = new Parent("Петро Коваленко", student1);

        // 3. Формування курсу
        Console.WriteLine("\n--- Робота з курсом ---");
        TrainingCourse course = new TrainingCourse("Основи Smart City", teacher);
        course.AddStudent(student1);
        course.AddStudent(student2);

        // 4. Демонстрація Поліморфізму (Абстрактні класи)
        Console.WriteLine("\n--- Демонстрація Поліморфізму (Масив Person) ---");
        List<Person> platformUsers = new List<Person> { student1, student2, teacher, parent };
        foreach (Person user in platformUsers)
        {
            user.DisplayRole();
        }

        // 5. Демонстрація Інтерфейсів
        Console.WriteLine("\n--- Демонстрація Інтерфейсів (IActivityParticipant) ---");
        List<IActivityParticipant> activeUsers = new List<IActivityParticipant> { student1, teacher };
        foreach (IActivityParticipant participant in activeUsers)
        {
            participant.PerformActivity();
        }

        Console.WriteLine("\n======================================================================");
        Console.WriteLine("Фініш імітації");
        Console.ReadLine();
    }
}
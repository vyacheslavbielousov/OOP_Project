class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode; // Unicode is UTF-16LE
        Console.InputEncoding = System.Text.Encoding.Unicode;
        // Обов'язковий заголовок
        Console.WriteLine("ПІБ студента: [Ваше ПІБ], курс: [Ваш курс], група: [Ваша група]");
        Console.WriteLine("Варіант завдання: Kyiv Smart City School");
        Console.WriteLine("Версія 3");
        Console.WriteLine("Старт імітації");
        Console.WriteLine("======================================================================");

        // 1. Створення об'єктів
        SmartSchool school = new SmartSchool("Kyiv Smart City Hub");
        Teacher teacher = new Teacher("Олена Василівна", "Смарт Технології");

        // Створюємо курс з обмеженням у 2 учня для перевірки предикатної функції
        TrainingCourse itCourse = new TrainingCourse("IT Basics", teacher, 2);

        Student student1 = new Student("Олексій", 14);
        Student student2 = new Student("Марія", 15);
        Student student3 = new Student("Іван", 13); // Третій учень (зайвий для курсу)

        Parent parent = new Parent("Олександр", student1);

        // 2. Демонстрація роботи предикатних функцій (стан об'єктів)
        Console.WriteLine("\n--- Перевірка станів (Предикатні функції) ---");
        Console.WriteLine($"Чи є на платформі інтерактивні задачі? : {school.HasInteractiveContent()}");

        // Спроба додати учнів на курс
        itCourse.AddStudent(student1);
        itCourse.AddStudent(student2);
        itCourse.AddStudent(student3); // Тут спрацює предикат IsCourseFull() і видасть помилку

        // 3. Демонстрація пріоритетних методів (Дії)
        parent.CheckChildProgress(); // Перевірка до навчання

        // Проводимо заняття (впливає на характеристики учнів)
        itCourse.ConductLesson(5); // 5 годин навчання

        // Після заняття
        Console.WriteLine("--- Стан учнів після навчання ---");
        Console.WriteLine(student1);
        Console.WriteLine(student2);

        parent.CheckChildProgress(); // Перевірка після навчання (предикат IsReadyForAdvancedIT змінить результат)

        Console.WriteLine("======================================================================");
        Console.WriteLine("Фініш імітації");
        Console.ReadLine();
    }
}
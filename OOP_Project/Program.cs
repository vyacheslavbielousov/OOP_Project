class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode; // Unicode is UTF-16LE
        Console.InputEncoding = System.Text.Encoding.Unicode;
        // Вимоги до протоколу
        Console.WriteLine("ПІБ студента: [Ваше ПІБ], курс: [Ваш курс], група: [Ваша група]");
        Console.WriteLine("Варіант завдання: Kyiv Smart City School");
        Console.WriteLine("Версія 2");
        Console.WriteLine("Старт імітації");
        Console.WriteLine("======================================================================");

        // Демонстрація створення об'єктів та роботи конструкторів/аксесорів

        // 1. Учень (Конструктори та властивості)
        Student defaultStudent = new Student(); // Без параметрів

        Student mainStudent = new Student("Олексій Петренко", 14); // Виклик через this
        mainStudent.FullName = "Олексій О. Петренко"; // Робота set аксесора

        Student copiedStudent = new Student(mainStudent); // Конструктор копій

        Console.WriteLine("--- Студенти (Конструктори, Копіювання, Аксесори) ---");
        Console.WriteLine(defaultStudent);
        Console.WriteLine(mainStudent);
        Console.WriteLine("Копія студента: " + copiedStudent);

        // 2. Вчитель
        Teacher teacher1 = new Teacher("Олена Василівна", "Основи програмування та Смарт Технології");
        Console.WriteLine("\n--- Вчитель ---");
        Console.WriteLine(teacher1);

        // 3. Батьки (Асоціація)
        Parent parent1 = new Parent("Олександр Петренко", mainStudent);
        Console.WriteLine("\n--- Батьки (Демонстрація Асоціації) ---");
        Console.WriteLine(parent1);

        // 4. Навчальний курс (Агрегація)
        TrainingCourse itCourse = new TrainingCourse("IT Basics для школярів", teacher1);
        itCourse.AddStudent(mainStudent);
        itCourse.AddStudent(copiedStudent);
        Console.WriteLine("\n--- Навчальний курс (Демонстрація Агрегації) ---");
        Console.WriteLine($"Курс: {itCourse.CourseName}, Викладає: {itCourse.CourseTeacher.FullName}");
        Console.WriteLine($"Кількість учнів у групі: {itCourse.EnrolledStudents.Count}");

        // 5. Платформа (Статичний конструктор, Композиція, Закритий конструктор)
        Console.WriteLine("\n--- Платформа (Статичний конструктор та Композиція) ---");
        SmartSchool schoolBranch = new SmartSchool("Оболонська філія (Kyiv Smart City Hub)");
        Console.WriteLine($"Філія: {schoolBranch.BranchName}, Розташування: {SmartSchool.City}");
        Console.WriteLine("Контент платформи (Композиція):");
        foreach (var content in schoolBranch.Database)
        {
            Console.WriteLine(" - " + content);
        }

        Console.WriteLine("======================================================================");
        Console.WriteLine("Фініш імітації");
        Console.ReadLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode; // Unicode is UTF-16LE
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("ПІБ студента: Бєлоусов В'ячеслав, курс: 1, група: ІПЗ-12");
        Console.WriteLine("Варіант завдання: Kyiv Smart City School");
        Console.WriteLine("Версія 6");
        Console.WriteLine("Старт імітації");
        Console.WriteLine("======================================================================\n");

        SmartSchool school = new SmartSchool("Kyiv Hub");
        Teacher teacher = new Teacher("Олег Іванович", "Програмування");
        TrainingCourse course = new TrainingCourse("IT Basics", teacher, maxCapacity: 1);

        Console.WriteLine("--- 1. Сценарій: Обробка Користувацьких Винятків ---");

        try
        {
            Console.WriteLine("Спроба створити студента з віком 5 років...");
            Student tooYoung = new Student("Сашко", 5);
        }
        catch (InvalidStudentAgeException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nСпроба додати двох учнів на курс з 1 місцем...");
            Student student1 = new Student("Іван", 15);
            Student student2 = new Student("Марія", 14);

            course.AddStudent(student1);
            course.AddStudent(student2);
        }
        catch (CourseCapacityExceededException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: {ex.Message}");
        }

        Console.WriteLine("\n--- 2. Сценарій: Обробка Стандартних Винятків C# ---");

        try
        {
            Console.WriteLine("Спроба перевірити успішність дитини, коли її не додано до системи...");
            Parent parentWithoutChild = new Parent("Оксана Вікторівна", null); // Дитина null
            parentWithoutChild.CheckChildProgress();
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nСпроба запустити контент під номером 5 (якого немає)...");
            school.GetContentByIndex(5);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: Індекс поза межами масиву. {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nСпроба розрахувати статистику курсу, який ще не розпочався (0 уроків)...");
            course.CalculateAverageAttendance(totalVisits: 10, heldLessons: 0);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: Неможливо поділити на нуль. {ex.Message}");
        }

        try
        {
            Console.WriteLine("\nСпроба зберегти дані студента за неіснуючим шляхом...");
            Student tempStudent = new Student("Олексій", 16);
            tempStudent.SaveDataToFile(@"student_data.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[НЕОЧІКУВАНА ПОМИЛКА]: {ex.Message}");
        }

        Console.WriteLine("\n======================================================================");
        Console.WriteLine("Фініш імітації");
        Console.ReadLine();
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding  = System.Text.Encoding.UTF8;
 
        Console.WriteLine("ПІБ студента: Бєлоусов В'ячеслав, курс: 1, група: ІПЗ-12");
        Console.WriteLine("Варіант завдання: Kyiv Smart City School");
        Console.WriteLine("Версія 6");
        Console.WriteLine("======================================================================");
 
        // ══════════════════════════════════════════════════════════════════
        //  СЕСІЯ 1: SmartSchool завантажує все з файлів (або створює нуль).
        //  Потім реєструємо нові об'єкти — кожен запис одразу йде у файл.
        // ══════════════════════════════════════════════════════════════════
        Console.WriteLine("\n СЕСІЯ 1: перший запуск / реєстрація даних  ");
 
        SmartSchool school = new SmartSchool("Kyiv Hub");
 
        // ── Реєстрація викладача ─────────────────────────────────────────
        Teacher teacher = new Teacher("Олег Іванович", "Програмування");
        school.RegisterTeacher(teacher);
 
        // ── Реєстрація курсу ─────────────────────────────────────────────
        TrainingCourse course = new TrainingCourse("IT Basics", teacher, maxCapacity: 2);
        school.RegisterCourse(course);
 
        // ── Реєстрація студентів ─────────────────────────────────────────
        Student ivan  = new Student("Іван Коваль", 15);
        Student maria = new Student("Марія Бондар", 14);
        school.RegisterStudent(ivan);
        school.RegisterStudent(maria);
 
        // ── Зарахування на курс (зберігає courses.txt автоматично) ───────
        Console.WriteLine("\n--- Зарахування студентів на курс ---");
        course.AddStudent(ivan);
        course.AddStudent(maria);
 
        // ── Додавання нового контенту ────────────────────────────────────
        school.AddContent(new VideoLesson("Мережі та протоколи", 30));
        school.AddContent(new InteractiveTask("Алгоритм сортування", 20));
 
        // ── Активність студента (змінює LogicLevel) ───────────────────────
        Console.WriteLine("\n--- Активність студента ---");
        ivan.PerformActivity();
        school.RegisterStudent(ivan); // оновлюємо students.txt після зміни LogicLevel
 
        // ── Показ стану після сесії 1 ────────────────────────────────────
        school.PrintFullState();
 
        // ══════════════════════════════════════════════════════════════════
        //  СЕСІЯ 2: новий екземпляр SmartSchool — симулює перезапуск app.
        //  Усі дані мають відновитися повністю з txt-файлів.
        // ══════════════════════════════════════════════════════════════════
        Console.WriteLine("\n  СЕСІЯ 2: перезапуск — завантаження з файлів  ");
 
        SmartSchool school2 = new SmartSchool("Kyiv Hub");
        school2.PrintFullState();
 
        // ══════════════════════════════════════════════════════════════════
        //  СЦЕНАРІЇ ОБРОБКИ ВИНЯТКІВ (незмінні з оригіналу)
        // ══════════════════════════════════════════════════════════════════
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
            Console.WriteLine("\nСпроба додати третього учня на курс з 2 місцями (обидва вже зайняті)...");
            // Курс school2 вже має 2 студентів (відновлено з файлу)
            var fullCourse = school2.Courses.Find(c => c.CourseName == "IT Basics");
            if (fullCourse != null)
            {
                Student extra = new Student("Зайвий Студент", 16);
                fullCourse.AddStudent(extra);
            }
        }
        catch (CourseCapacityExceededException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: {ex.Message}");
        }
 
        Console.WriteLine("\n--- 2. Сценарій: Обробка Стандартних Винятків C# ---");
 
        try
        {
            Console.WriteLine("Спроба перевірити успішність дитини, коли її не додано до системи...");
            Parent parentWithoutChild = new Parent("Оксана Вікторівна", null);
            parentWithoutChild.CheckChildProgress();
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: {ex.Message}");
        }
 
        try
        {
            Console.WriteLine("\nСпроба запустити контент під номером 99 (якого немає)...");
            school2.GetContentByIndex(99);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: Індекс поза межами масиву. {ex.Message}");
        }
 
        try
        {
            Console.WriteLine("\nСпроба розрахувати статистику курсу, який ще не розпочався (0 уроків)...");
            var anyCourse = school2.Courses.Count > 0 ? school2.Courses[0] : null;
            anyCourse?.CalculateAverageAttendance(totalVisits: 10, heldLessons: 0);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"[ПЕРЕХОПЛЕНО]: Неможливо поділити на нуль. {ex.Message}");
        }
 
        try
        {
            Console.WriteLine("\nСпроба зберегти дані студента...");
            Student tempStudent = new Student("Олексій Тест", 16);
            school2.RegisterStudent(tempStudent); // реальний запис у students.txt
            Console.WriteLine("[Файл] Дані успішно збережено через DataStore.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[НЕОЧІКУВАНА ПОМИЛКА]: {ex.Message}");
        }
 
        Console.WriteLine("\n======================================================================");
        Console.WriteLine("Фініш імітації. Перевірте файли: students.txt, teachers.txt, courses.txt, content.txt");
        Console.ReadLine();
    }
}
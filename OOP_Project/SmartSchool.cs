using System;
using System.Collections.Generic;
using System.Text;

public class SmartSchool
{
    public string BranchName { get; set; }
 
    // ── Колекції (єдине джерело правди в пам'яті) ───────────
    public List<Student>         Students  { get; private set; }
    public List<Teacher>         Teachers  { get; private set; }
    public List<TrainingCourse>  Courses   { get; private set; }
    public List<PlatformContent> Database  { get; private set; }
 
    // ── Конструктор: завантажує дані з файлів ───────────────
    public SmartSchool(string branchName)
    {
        BranchName = branchName;
 
        Console.WriteLine($"\n[SmartSchool] Завантаження даних із файлів для '{BranchName}'...");
 
        // Порядок важливий: спочатку студенти та викладачі,
        // потім курси (посилаються на них), потім контент.
        Students = DataStore.LoadStudents();
        Teachers = DataStore.LoadTeachers();
        Courses  = DataStore.LoadCourses(Teachers, Students);
        Database = DataStore.LoadContent();
 
        // Якщо файли порожні / перший запуск — додаємо дефолтний контент.
        if (Database.Count == 0)
        {
            Console.WriteLine("[SmartSchool] Контент не знайдено — ініціалізую за замовчуванням.");
            Database.Add(new VideoLesson("Основи Smart City", 15));
            Database.Add(new InteractiveTask("Логічна задача", 10));
            DataStore.SaveContent(Database);
        }
 
        // Зв'язуємо курси зі спільним списком для каскадного збереження
        foreach (var c in Courses)
            c.AllCourses = Courses;
 
        Console.WriteLine($"[SmartSchool] Готово. " +
                          $"Студентів: {Students.Count}, " +
                          $"Викладачів: {Teachers.Count}, " +
                          $"Курсів: {Courses.Count}, " +
                          $"Контенту: {Database.Count}\n");
    }
 
    // ── Додавання нового студента (захист від дублів за іменем) ─
    public void RegisterStudent(Student student)
    {
        // Оновлюємо якщо вже є, додаємо якщо нема
        int idx = Students.FindIndex(s => s.FullName == student.FullName);
        if (idx >= 0)
            Students[idx] = student;  // оновлення (напр., після PerformActivity)
        else
            Students.Add(student);
 
        DataStore.SaveStudents(Students);
        Console.WriteLine($"[SmartSchool] Студента '{student.FullName}' збережено.");
    }
 
    // ── Додавання нового викладача (захист від дублів за іменем) ─
    public void RegisterTeacher(Teacher teacher)
    {
        if (Teachers.Exists(t => t.FullName == teacher.FullName))
        {
            Console.WriteLine($"[SmartSchool] Викладач '{teacher.FullName}' вже є в системі.");
            return;
        }
        Teachers.Add(teacher);
        DataStore.SaveTeachers(Teachers);
        Console.WriteLine($"[SmartSchool] Викладача '{teacher.FullName}' зареєстровано та збережено.");
    }
 
    // ── Додавання нового курсу (захист від дублів за назвою) ────
    public void RegisterCourse(TrainingCourse course)
    {
        if (Courses.Exists(c => c.CourseName == course.CourseName))
        {
            Console.WriteLine($"[SmartSchool] Курс '{course.CourseName}' вже є в системі.");
            return;
        }
        course.AllCourses = Courses;
        Courses.Add(course);
        DataStore.SaveCourses(Courses);
        Console.WriteLine($"[SmartSchool] Курс '{course.CourseName}' зареєстровано та збережено.");
    }
 
    // ── Додавання контенту (захист від дублів за назвою) ────
    public void AddContent(PlatformContent content)
    {
        if (Database.Exists(c => c.Title == content.Title))
        {
            Console.WriteLine($"[SmartSchool] Контент '{content.Title}' вже є в базі.");
            return;
        }
        Database.Add(content);
        DataStore.SaveContent(Database);
        Console.WriteLine($"[SmartSchool] Контент '{content.Title}' додано та збережено.");
    }
 
    // ── Відкриття контенту за індексом ───────────────────────
    public void GetContentByIndex(int index)
    {
        PlatformContent content = Database[index]; // кидає ArgumentOutOfRangeException
        content.OpenContent();
    }
 
    // ── Виведення повного стану ──────────────────────────────
    public void PrintFullState()
    {
        Console.WriteLine("\n========== ПОТОЧНИЙ СТАН СИСТЕМИ ==========");
 
        Console.WriteLine($"\n--- Студенти ({Students.Count}) ---");
        foreach (var s in Students) s.DisplayRole();
 
        Console.WriteLine($"\n--- Викладачі ({Teachers.Count}) ---");
        foreach (var t in Teachers) t.DisplayRole();
 
        Console.WriteLine($"\n--- Курси ({Courses.Count}) ---");
        foreach (var c in Courses)
            Console.WriteLine($"  '{c.CourseName}' | Вчитель: {c.CourseTeacher.FullName} | " +
                              $"Студентів: {c.EnrolledStudents.Count}/{c.MaxCapacity}");
 
        Console.WriteLine($"\n--- Платформний контент ({Database.Count}) ---");
        foreach (var pc in Database) pc.OpenContent();
 
        Console.WriteLine("===========================================\n");
    }
}
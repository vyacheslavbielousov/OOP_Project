using System;
using System.Collections.Generic;
using System.IO;

public static class DataStore
{
    // ── шляхи до файлів ─────────────────────────────────────
    private const string StudentsFile  = "students.txt";
    private const string TeachersFile  = "teachers.txt";
    private const string CoursesFile   = "courses.txt";
    private const string ContentFile   = "content.txt";

    private const char   Sep           = '|';   // роздільник полів
    private const char   ListSep       = ';';   // роздільник списків

    // ── ЗАПИС: студенти ─────────────────────────────────────
    public static void SaveStudents(IEnumerable<Student> students)
    {
        WriteFile(StudentsFile, writer =>
        {
            foreach (var s in students)
                writer.WriteLine($"{s.FullName}{Sep}{s.Age}{Sep}{s.LogicLevel}");
        });
        Console.WriteLine($"[DataStore] students.txt збережено.");
    }

    // ── ЧИТАННЯ: студенти ───────────────────────────────────
    public static List<Student> LoadStudents()
    {
        var list = new List<Student>();
        if (!File.Exists(StudentsFile)) return list;

        foreach (var line in ReadLines(StudentsFile))
        {
            var p = line.Split(Sep);
            if (p.Length < 3) continue;
            try
            {
                var s = new Student(p[0].Trim(), int.Parse(p[1].Trim()), int.Parse(p[2].Trim()));
                list.Add(s);
                Console.WriteLine($"[DataStore] Завантажено студента: {s.FullName} (вік {s.Age}, логіка {s.LogicLevel})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DataStore] Пропущено рядок студента '{line}': {ex.Message}");
            }
        }
        return list;
    }

    // ── ЗАПИС: викладачі ────────────────────────────────────
    public static void SaveTeachers(IEnumerable<Teacher> teachers)
    {
        WriteFile(TeachersFile, writer =>
        {
            foreach (var t in teachers)
                writer.WriteLine($"{t.FullName}{Sep}{t.Specialization}");
        });
        Console.WriteLine($"[DataStore] teachers.txt збережено.");
    }

    // ── ЧИТАННЯ: викладачі ──────────────────────────────────
    public static List<Teacher> LoadTeachers()
    {
        var list = new List<Teacher>();
        if (!File.Exists(TeachersFile)) return list;

        foreach (var line in ReadLines(TeachersFile))
        {
            var p = line.Split(Sep);
            if (p.Length < 2) continue;
            var t = new Teacher(p[0].Trim(), p[1].Trim());
            list.Add(t);
            Console.WriteLine($"[DataStore] Завантажено викладача: {t.FullName} ({t.Specialization})");
        }
        return list;
    }

    // ── ЗАПИС: курси ────────────────────────────────────────
    public static void SaveCourses(IEnumerable<TrainingCourse> courses)
    {
        WriteFile(CoursesFile, writer =>
        {
            foreach (var c in courses)
            {
                var studentNames = string.Join(ListSep.ToString(),
                    c.EnrolledStudents.ConvertAll(s => s.FullName));
                writer.WriteLine($"{c.CourseName}{Sep}{c.CourseTeacher.FullName}{Sep}{c.MaxCapacity}{Sep}{studentNames}");
            }
        });
        Console.WriteLine($"[DataStore] courses.txt збережено.");
    }

    // ── ЧИТАННЯ: курси ──────────────────────────────────────
    // Викладач та студенти беруться зі вже завантажених колекцій,
    // щоб уникнути дублювання об'єктів.
    public static List<TrainingCourse> LoadCourses(
        List<Teacher> teachers,
        List<Student> students)
    {
        var list = new List<TrainingCourse>();
        if (!File.Exists(CoursesFile)) return list;

        foreach (var line in ReadLines(CoursesFile))
        {
            var p = line.Split(Sep);
            if (p.Length < 3) continue;

            string courseName   = p[0].Trim();
            string teacherName  = p[1].Trim();
            int maxCap          = int.Parse(p[2].Trim());
            string studentsPart = p.Length > 3 ? p[3].Trim() : "";

            // Знаходимо або створюємо викладача
            var teacher = teachers.Find(t => t.FullName == teacherName)
                          ?? new Teacher(teacherName, "Невідомо");

            var course = new TrainingCourse(courseName, teacher, maxCap);

            // Відновлюємо зарахованих студентів
            if (!string.IsNullOrWhiteSpace(studentsPart))
            {
                foreach (var sName in studentsPart.Split(ListSep))
                {
                    var st = students.Find(s => s.FullName == sName.Trim());
                    if (st != null) course.EnrolledStudents.Add(st);
                }
            }

            list.Add(course);
            Console.WriteLine($"[DataStore] Завантажено курс: '{courseName}' " +
                              $"(вчитель: {teacherName}, місць: {maxCap}, " +
                              $"студентів: {course.EnrolledStudents.Count})");
        }
        return list;
    }

    // ── ЗАПИС: платформний контент ──────────────────────────
    public static void SaveContent(IEnumerable<PlatformContent> content)
    {
        WriteFile(ContentFile, writer =>
        {
            foreach (var c in content)
            {
                switch (c)
                {
                    case VideoLesson vl:
                        writer.WriteLine($"VideoLesson{Sep}{vl.Title}{Sep}{vl.DurationMinutes}");
                        break;
                    case InteractiveTask it:
                        writer.WriteLine($"InteractiveTask{Sep}{it.Title}{Sep}{it.MaxScore}");
                        break;
                }
            }
        });
        Console.WriteLine($"[DataStore] content.txt збережено.");
    }

    // ── ЧИТАННЯ: платформний контент ────────────────────────
    public static List<PlatformContent> LoadContent()
    {
        var list = new List<PlatformContent>();
        if (!File.Exists(ContentFile)) return list;

        foreach (var line in ReadLines(ContentFile))
        {
            var p = line.Split(Sep);
            if (p.Length < 3) continue;

            string type  = p[0].Trim();
            string title = p[1].Trim();

            PlatformContent? item = type switch
            {
                "VideoLesson"     => new VideoLesson(title, int.Parse(p[2].Trim())),
                "InteractiveTask" => new InteractiveTask(title, int.Parse(p[2].Trim())),
                _                 => null
            };

            if (item != null)
            {
                list.Add(item);
                Console.WriteLine($"[DataStore] Завантажено контент: [{type}] '{title}'");
            }
        }
        return list;
    }

    // ── ДОПОМІЖНІ МЕТОДИ ────────────────────────────────────

    /// <summary>Записує файл через StreamWriter з коректним закриттям.</summary>
    private static void WriteFile(string path, Action<StreamWriter> writeAction)
    {
        StreamWriter? writer = null;
        try
        {
            writer = new StreamWriter(path, append: false,
                         System.Text.Encoding.UTF8);
            writer.WriteLine($"# Оновлено: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            writeAction(writer);
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[DataStore] Помилка запису '{path}': {ex.Message}");
        }
        finally
        {
            writer?.Close();
        }
    }

    /// <summary>Читає рядки файлу, пропускаючи коментарі та порожні рядки.</summary>
    private static IEnumerable<string> ReadLines(string path)
    {
        StreamReader? reader = null;
        var lines = new List<string>();
        try
        {
            reader = new StreamReader(path, System.Text.Encoding.UTF8);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                    lines.Add(line);
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[DataStore] Помилка читання '{path}': {ex.Message}");
        }
        finally
        {
            reader?.Close();
        }
        return lines;
    }
}
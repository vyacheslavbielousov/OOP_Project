using System;
using System.Collections.Generic;
using System.IO;



public static class DataStore
{
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
}
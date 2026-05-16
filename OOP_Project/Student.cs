using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class Student : Person, IActivityParticipant
{
    private int _age;
    public int Age
    {
        get { return _age; }
        set
        {
            // ГЕНЕРАЦІЯ ВИНЯТКУ: Некоректність введення даних
            if (value < 6 || value > 18)
                throw new InvalidStudentAgeException($"Вік {value} є недопустимим. Школяр має бути віком від 6 до 18 років.");
            _age = value;
        }
    }

    public int LogicLevel { get; private set; }

    public Student(string fullName, int age) : base(fullName)
    {
        Age = age; // Може викликати InvalidStudentAgeException
        LogicLevel = 10;
    }

    public override void DisplayRole() => Console.WriteLine($"Роль: Учень. ПІБ: {FullName}, Вік: {Age}");
    public void PerformActivity() { LogicLevel += 5; }

    // ОБРОБКА ВИНЯТКІВ: Робота з файлами
    public void SaveDataToFile(string filePath)
    {
        filePath = @"student_data.txt";
        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter(filePath, true);
            writer.WriteLine($"[{DateTime.Now}] Студент: {FullName} | Логіка: {LogicLevel}");
            Console.WriteLine($"[Файл] Дані студента '{FullName}' успішно збережено.");
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"[Помилка файлової системи] Директорію не знайдено: {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[Помилка вводу/виводу] Не вдалося записати файл: {ex.Message}");
        }
        finally
        {
            // finally виконується завжди
            if (writer != null)
            {
                writer.Close();
                Console.WriteLine("[Файл] Потік запису закрито.");
            }
        }
    }
}
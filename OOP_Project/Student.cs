using System;
using System.Collections.Generic;

public class Student : Person, IActivityParticipant
{
    private int _age;
    public int Age
    {
        get => _age;
        set
        {
            if (value < 6 || value > 18)
                throw new InvalidStudentAgeException(
                    $"Вік {value} є недопустимим. Школяр має бути віком від 6 до 18 років.");
            _age = value;
        }
    }

    public int LogicLevel { get; private set; }

    // ── Звичайний конструктор (новий студент) ───────────────
    public Student(string fullName, int age) : base(fullName)
    {
        Age        = age;
        LogicLevel = 10;
    }

    // ── Конструктор відновлення з файлу ────────────────────
    // Приймає logicLevel, щоб точно відтворити збережений стан.
    public Student(string fullName, int age, int logicLevel) : base(fullName)
    {
        Age        = age;
        LogicLevel = logicLevel;
    }

    public override void DisplayRole() =>
        Console.WriteLine($"Роль: Учень. ПІБ: {FullName}, Вік: {Age}, Логіка: {LogicLevel}");

    public void PerformActivity()
    {
        LogicLevel += 5;
        Console.WriteLine($"[{FullName}] виконав завдання. Логіка: {LogicLevel}");
    }

    // ── Запис лише цього студента в загальний файл ──────────
    // Передає актуальний список щоразу, щоб файл не накопичував дублі.
    public void SaveDataToFile(List<Student> allStudents)
    {
        DataStore.SaveStudents(allStudents);
    }
}
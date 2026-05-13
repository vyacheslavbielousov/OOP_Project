using System;
using System.Collections.Generic;
using System.Text;

public class Teacher
{
    public string FullName { get; set; }
    public string Specialization { get; set; }

    public Teacher(string fullName, string specialization)
    {
        FullName = fullName;
        Specialization = specialization;
    }

    // --- ВЕРСІЯ 4: Задачі другого пріоритету ---
    public void AssignHomework(Student student)
    {
        Console.WriteLine($"\n[Вчитель {FullName}] призначив домашнє завдання для {student.FullName}.");
        student.CompleteHomework();
    }
}

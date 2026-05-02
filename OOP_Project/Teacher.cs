using System;
using System.Collections.Generic;
using System.Text;

public class Teacher
{
    public string FullName { get; set; }
    public string Specialization { get; set; }

    // Конструктор з параметрами
    public Teacher(string fullName, string specialization)
    {
        FullName = fullName;
        Specialization = specialization;
    }

    public override string ToString() => $"Вчитель: {FullName}, Спеціалізація: {Specialization}";
}

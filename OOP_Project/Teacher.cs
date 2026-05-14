using System;
using System.Collections.Generic;
using System.Text;

public class Teacher : Person, IActivityParticipant
{
    public string Specialization { get; set; }

    // Виклик конструктора базового класу через base()
    public Teacher(string fullName, string specialization) : base(fullName)
    {
        Specialization = specialization;
    }

    public override void DisplayRole()
    {
        Console.WriteLine($"Роль: Викладач. ПІБ: {FullName}, Спеціалізація: {Specialization}");
    }

    // Реалізація інтерфейсу
    public void PerformActivity()
    {
        Console.WriteLine($"[{FullName}] проводить онлайн-трансляцію курсу.");
    }
}

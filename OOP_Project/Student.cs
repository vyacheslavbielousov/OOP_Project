using System;
using System.Collections.Generic;
using System.Text;

public class Student : Person, IActivityParticipant
{
    public int Age { get; set; }
    public int LogicLevel { get; private set; }

    // Виклик конструктора базового класу через base()
    public Student(string fullName, int age) : base(fullName)
    {
        Age = age;
        LogicLevel = 10;
    }

    // Перевизначення абстрактного методу
    public override void DisplayRole()
    {
        Console.WriteLine($"Роль: Учень. ПІБ: {FullName}, Вік: {Age}");
    }

    // Реалізація інтерфейсу (Задача 3-го пріоритету)
    public void PerformActivity()
    {
        LogicLevel += 5;
        Console.WriteLine($"[{FullName}] розв'язує задачі з програмування. Логіка: {LogicLevel}");
    }
}
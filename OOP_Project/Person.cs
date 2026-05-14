using System;
using System.Collections.Generic;
using System.Text;

public abstract class Person
{
    public string FullName { get; set; }

    // Конструктор базового класу
    protected Person(string fullName)
    {
        FullName = fullName;
        Console.WriteLine($"[Базовий клас Person] Створено людину: {FullName}");
    }

    // Абстрактний метод, який обов'язково треба перевизначити у похідних класах
    public abstract void DisplayRole();
}

public interface IActivityParticipant
{
    void PerformActivity(); // Метод, який мають реалізувати учасники платформи
}
using System;
using System.Collections.Generic;
using System.Text;

public class Parent : Person
{
    public Student Child { get; set; }

    public Parent(string fullName, Student child) : base(fullName)
    {
        Child = child;
    }

    public override void DisplayRole()
    {
        // Якщо дитина не призначена, виводимо "Невідомо" замість падіння програми на цьому етапі
        string childName = Child != null ? Child.FullName : "Не призначено";
        Console.WriteLine($"Роль: Батьки. ПІБ: {FullName}, Дитина: {childName}");
    }

    public void CheckChildProgress()
    {
        // ГЕНЕРАЦІЯ СТАНДАРТНОГО ВИНЯТКУ: звернення до null-об'єкта
        if (Child == null)
        {
            throw new NullReferenceException($"У системі не знайдено даних про дитину для батьків ({FullName}).");
        }
        Console.WriteLine($"[{FullName}] перевіряє успішність: {Child.FullName} має рівень логіки {Child.LogicLevel}.");
    }
}
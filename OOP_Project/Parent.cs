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
        Console.WriteLine($"Роль: Батько/Мати. ПІБ: {FullName}, Дитина: {Child.FullName}");
    }
}
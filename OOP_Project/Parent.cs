using System;
using System.Collections.Generic;
using System.Text;

public class Parent
{
    public string FullName { get; set; }
    // ВЗАЄМОЗВ'ЯЗОК: Асоціація (Батьки знають про свою дитину)
    public Student Child { get; set; }

    public Parent(string fullName, Student child)
    {
        FullName = fullName;
        Child = child;
    }

    public override string ToString() => $"Батько/Мати: {FullName}, Дитина: {Child.FullName}";
}
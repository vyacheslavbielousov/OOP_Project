using System;
using System.Collections.Generic;
using System.Text;

public class Parent
{
    public string FullName { get; set; }
    public Student Child { get; set; }

    public Parent(string fullName, Student child)
    {
        FullName = fullName;
        Child = child;
    }

    // --- ВЕРСІЯ 3: Пріоритетний метод дій ---
    public void CheckChildProgress()
    {
        Console.WriteLine($"\n[Батьківський контроль] {FullName} перевіряє успішність дитини ({Child.FullName}).");
        if (Child.IsReadyForAdvancedIT())
        {
            Console.WriteLine(" -> Чудовий результат! Дитина готова до просунутих ІТ-курсів.");
        }
        else
        {
            Console.WriteLine(" -> Дитині ще потрібно попрацювати над логікою та soft skills.");
        }
    }
}
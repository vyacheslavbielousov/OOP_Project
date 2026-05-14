using System;
using System.Collections.Generic;
using System.Text;

public class SmartSchool
{
    public string BranchName { get; set; }

    // Композиція з використанням абстрактного базового класу (Поліморфізм)
    public List<PlatformContent> Database { get; private set; }

    public static string City { get; set; }
    static SmartSchool() { City = "Київ"; }

    public SmartSchool(string branchName)
    {
        BranchName = branchName;

        // Заповнення бази конкретними похідними об'єктами
        Database = new List<PlatformContent>
            {
                new VideoLesson("Що таке Smart City?", 15),
                new InteractiveTask("Алгоритм роботи розумного світлофора", 10),
                new VideoLesson("Екологія та IT", 20)
            };
    }

    public void ShowAllContent()
    {
        Console.WriteLine($"\n--- База контенту школи '{BranchName}' ---");
        foreach (var content in Database)
        {
            // Поліморфний виклик: система сама знає, чи це відео, чи задача
            content.OpenContent();
        }
    }
}
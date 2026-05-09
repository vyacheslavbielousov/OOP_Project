using System;
using System.Collections.Generic;
using System.Text;

public class Student
{
    public string FullName { get; set; }
    public int LogicLevel { get; private set; }
    public int SoftSkillsLevel { get; private set; }

    private int _age;
    public int Age
    {
        get { return _age; }
        set { _age = (value >= 6 && value <= 18) ? value : 10; }
    }

    public Student(string fullName, int age)
    {
        FullName = fullName;
        Age = age;
        LogicLevel = 10; // Початковий рівень
        SoftSkillsLevel = 10;
    }

    // --- ВЕРСІЯ 3: Пріоритетні методи дій ---
    public void StudyProgramming(int hours)
    {
        LogicLevel += hours * 5; // Кожна година дає +5 до логіки
        Console.WriteLine($"[Навчання] {FullName} вивчає програмування {hours} год. Рівень логіки тепер: {LogicLevel}");
    }

    public void DevelopSoftSkills(int hours)
    {
        SoftSkillsLevel += hours * 3; // Кожна година дає +3 до soft skills
        Console.WriteLine($"[Soft Skills] {FullName} працює в команді {hours} год. Рівень Soft Skills тепер: {SoftSkillsLevel}");
    }

    // --- ВЕРСІЯ 3: Предикатна функція ---
    // Перевіряє, чи готовий учень до просунутого курсу (повертає true/false)
    public bool IsReadyForAdvancedIT()
    {
        return LogicLevel >= 50 && SoftSkillsLevel >= 30;
    }

    public override string ToString() => $"Учень: {FullName}, Логіка: {LogicLevel}, SoftSkills: {SoftSkillsLevel}";
}
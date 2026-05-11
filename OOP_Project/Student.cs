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
        LogicLevel = 10;
        SoftSkillsLevel = 10;
    }

    // Методи з минулих версій
    public void StudyProgramming(int hours) => LogicLevel += hours * 5;
    public void DevelopSoftSkills(int hours) => SoftSkillsLevel += hours * 3;
    public bool IsReadyForAdvancedIT() => LogicLevel >= 50 && SoftSkillsLevel >= 30;

    // --- ВЕРСІЯ 4: Задачі другого пріоритету ---
    public void CompleteHomework()
    {
        LogicLevel += 5;
        SoftSkillsLevel += 2;
        Console.WriteLine($"[Домашнє завдання] {FullName} виконав ДЗ. Логіка: {LogicLevel}, SoftSkills: {SoftSkillsLevel}");
    }

    // a) Бінарні арифметичні оператори (*, /)
    // Множення на число (інтенсивне навчання)
    public static Student operator *(Student s, int multiplier)
    {
        s.LogicLevel *= multiplier;
        return s;
    }

    // Ділення (втрата концентрації)
    public static Student operator /(Student s, int divider)
    {
        s.LogicLevel /= divider;
        return s;
    }

    // b) Унарні оператори (+, -, ++, --, !, true, false)
    public static Student operator ++(Student s)
    {
        s.LogicLevel += 10; // Підвищення рівня
        return s;
    }

    public static Student operator --(Student s)
    {
        s.LogicLevel -= 5; // Зниження рівня
        return s;
    }

    public static Student operator +(Student s) => s; // Унарний плюс (не змінює об'єкт)

    public static Student operator -(Student s)
    {
        s.LogicLevel = 0; // Штраф (обнулення логіки)
        return s;
    }

    public static bool operator !(Student s) => s.LogicLevel == 0; // Перевірка на нульові знання

    public static bool operator true(Student s) => s.LogicLevel >= 20; // Вважається "успішним"
    public static bool operator false(Student s) => s.LogicLevel < 20;

    // c) Оператори порівняння (==, !=, <, >, <=, >=)
    // Загальний бал учня для порівняння
    private int TotalScore => LogicLevel + SoftSkillsLevel;

    public static bool operator >(Student s1, Student s2) => s1.TotalScore > s2.TotalScore;
    public static bool operator <(Student s1, Student s2) => s1.TotalScore < s2.TotalScore;
    public static bool operator >=(Student s1, Student s2) => s1.TotalScore >= s2.TotalScore;
    public static bool operator <=(Student s1, Student s2) => s1.TotalScore <= s2.TotalScore;

    public static bool operator ==(Student s1, Student s2)
    {
        if (ReferenceEquals(s1, s2)) return true;
        if (s1 is null || s2 is null) return false;
        return s1.TotalScore == s2.TotalScore;
    }

    public static bool operator !=(Student s1, Student s2) => !(s1 == s2);

    // Перевизначення Equals та GetHashCode вимагається при перевантаженні == та !=
    public override bool Equals(object obj) => obj is Student s && this == s;
    public override int GetHashCode() => TotalScore.GetHashCode();

    public override string ToString() => $"Учень: {FullName} (Оцінка: {TotalScore} -> Логіка: {LogicLevel}, SoftSkills: {SoftSkillsLevel})";
}
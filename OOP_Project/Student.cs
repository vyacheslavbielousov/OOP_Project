using System;
using System.Collections.Generic;
using System.Text;

public class Student
{
    // a. Властивості, що автоматично реалізуються (Auto-implemented properties)
    public string FullName { get; set; }

    // b. Відкрита властивість для читання, закрита для запису (Private set)
    public int LogicLevel { get; private set; }
    public int SoftSkillsLevel { get; private set; }

    // c. Властивість читання та запису (з backing field) для валідації даних
    private int _age;
    public int Age
    {
        get { return _age; }
        set
        {
            // Перевірка віку школяра
            if (value >= 6 && value <= 18)
                _age = value;
            else
                _age = 10; // Дефолтне значення, якщо введено некоректний вік
        }
    }

    // 1) Конструктор без параметрів
    public Student()
    {
        FullName = "Невідомий учень";
        Age = 10;
        LogicLevel = 0;
        SoftSkillsLevel = 0;
    }

    // 2) Конструктор з параметрами + 6) Виклик іншого конструктора через this
    public Student(string fullName, int age) : this(fullName, age, 10, 10)
    {
        // Цей конструктор делегує роботу головному конструктору нижче
    }

    // Головний конструктор ініціалізації полів
    public Student(string fullName, int age, int logicLevel, int softSkillsLevel)
    {
        FullName = fullName;
        Age = age; // Викличе set-аксесор з перевіркою
        LogicLevel = logicLevel;
        SoftSkillsLevel = softSkillsLevel;
    }

    // 5) Конструктор копій
    public Student(Student otherStudent)
    {
        FullName = otherStudent.FullName;
        Age = otherStudent.Age;
        LogicLevel = otherStudent.LogicLevel;
        SoftSkillsLevel = otherStudent.SoftSkillsLevel;
    }

    public override string ToString() => $"Учень: {FullName}, Вік: {Age}, Логіка: {LogicLevel}, SoftSkills: {SoftSkillsLevel}";
}
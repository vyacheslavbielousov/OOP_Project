using System;
using System.Collections.Generic;
using System.Text;

public class TrainingCourse
{
    public string CourseName { get; set; }
    public int MaxCapacity { get; set; } // Максимальна кількість місць
    public Teacher CourseTeacher { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public TrainingCourse(string courseName, Teacher teacher, int maxCapacity)
    {
        CourseName = courseName;
        CourseTeacher = teacher;
        MaxCapacity = maxCapacity;
        EnrolledStudents = new List<Student>();
    }

    // --- ВЕРСІЯ 3: Предикатна функція ---
    public bool IsCourseFull()
    {
        return EnrolledStudents.Count >= MaxCapacity;
    }

    // Модифікований метод додавання учня з використанням предикатної функції
    public void AddStudent(Student student)
    {
        if (IsCourseFull())
        {
            Console.WriteLine($"[Помилка] Неможливо додати {student.FullName}. Курс '{CourseName}' повністю заповнений!");
        }
        else
        {
            EnrolledStudents.Add(student);
            Console.WriteLine($"[Успіх] {student.FullName} успішно зарахований на курс '{CourseName}'.");
        }
    }

    // --- ВЕРСІЯ 3: Пріоритетний метод (Імітація тренінгу) ---
    public void ConductLesson(int durationHours)
    {
        Console.WriteLine($"\n--- Починається заняття на курсі '{CourseName}' (Викладач: {CourseTeacher.FullName}) ---");
        foreach (var student in EnrolledStudents)
        {
            student.StudyProgramming(durationHours);
            student.DevelopSoftSkills(durationHours);
        }
        Console.WriteLine("--- Заняття завершено ---\n");
    }
}
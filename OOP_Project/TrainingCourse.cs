using System;
using System.Collections.Generic;
using System.Text;

public class TrainingCourse
{
    public string CourseName { get; set; }
    public int MaxCapacity { get; set; }
    public Teacher CourseTeacher { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public TrainingCourse(string courseName, Teacher teacher, int maxCapacity)
    {
        CourseName = courseName;
        CourseTeacher = teacher;
        MaxCapacity = maxCapacity;
        EnrolledStudents = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        // ГЕНЕРАЦІЯ ВИНЯТКУ: Перевищення ліміту курсу
        if (EnrolledStudents.Count >= MaxCapacity)
        {
            throw new CourseCapacityExceededException($"На курсі '{CourseName}' закінчилися вільні місця (Ліміт: {MaxCapacity}).");
        }
        EnrolledStudents.Add(student);
        Console.WriteLine($"[Курс] {student.FullName} успішно зарахований на '{CourseName}'.");
    }

    // Демонстрація можливого ділення на нуль
    public void CalculateAverageAttendance(int totalVisits, int heldLessons)
    {
        // Якщо уроків не було (heldLessons = 0), система викине DivideByZeroException
        int avg = totalVisits / heldLessons;
        Console.WriteLine($"Середня відвідуваність: {avg} учнів на урок.");
    }
}
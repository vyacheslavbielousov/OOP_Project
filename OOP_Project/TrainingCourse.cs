using System;
using System.Collections.Generic;
using System.Text;

public class TrainingCourse
{
    public string CourseName { get; set; }
    public Teacher CourseTeacher { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public TrainingCourse(string courseName, Teacher teacher)
    {
        CourseName = courseName;
        CourseTeacher = teacher;
        EnrolledStudents = new List<Student>();
    }

    public void AddStudent(Student student)
    {
        EnrolledStudents.Add(student);
        Console.WriteLine($"[Курс] Учня {student.FullName} успішно додано на курс '{CourseName}'.");
    }
}
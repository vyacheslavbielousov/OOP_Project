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
    public static TrainingCourse operator +(TrainingCourse course, Student student)
    {
        course.EnrolledStudents.Add(student);
        Console.WriteLine($"[Оператор +] Учня {student.FullName} додано на курс {course.CourseName}.");
        return course;
    }

    public static TrainingCourse operator -(TrainingCourse course, Student student)
    {
        if (course.EnrolledStudents.Contains(student))
        {
            course.EnrolledStudents.Remove(student);
            Console.WriteLine($"[Оператор -] Учня {student.FullName} відраховано з курсу {course.CourseName}.");
        }
        return course;
    }
}
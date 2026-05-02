using System;
using System.Collections.Generic;
using System.Text;

public class TrainingCourse
{
    public string CourseName { get; set; }

    // ВЗАЄМОЗВ'ЯЗОК: Агрегація (Вчитель і учні існують незалежно від курсу)
    public Teacher CourseTeacher { get; set; }
    public List<Student> EnrolledStudents { get; set; }

    public TrainingCourse(string courseName, Teacher teacher)
    {
        CourseName = courseName;
        CourseTeacher = teacher;
        EnrolledStudents = new List<Student>(); // Ініціалізація порожнього списку
    }

    public void AddStudent(Student student)
    {
        EnrolledStudents.Add(student);
    }
}

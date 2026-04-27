using System;
using System.Collections.Generic;
using System.Text;

public class TrainingCourse
{
    public string CourseName;
    public Teacher CourseTeacher;
    public List<Student> EnrolledStudents; // Агрегація (учні існують окремо)

    public void AddStudent(Student student) { }
    public void StartLesson() { }
}

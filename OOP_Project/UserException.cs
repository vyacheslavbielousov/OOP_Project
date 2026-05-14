using System;
using System.Collections.Generic;
using System.Text;

public class InvalidStudentAgeException : Exception
{
    public InvalidStudentAgeException(string message) : base(message) { }
}

public class CourseCapacityExceededException : Exception
{
    public CourseCapacityExceededException(string message) : base(message) { }
}
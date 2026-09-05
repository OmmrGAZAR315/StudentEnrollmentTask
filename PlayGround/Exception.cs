namespace PlayGround;

public class CourseMaxCapacityException : Exception
{
    public CourseMaxCapacityException() : base("Course is full.")
    {
        
    }
}
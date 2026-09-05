namespace PlayGround
{
    internal class Course
    {
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public int Capacity { get; set; }
        public string Duration { get; set; }
        public decimal CreditHours { get; set; }

        public Course(string name, string courseCode, int capacity, string duration, decimal creditHours)
        {
            CourseCode = courseCode;
            Name = name;
            NumberOfStudents = 0;
            Capacity = capacity;
            CreditHours = creditHours;
            Duration = duration;
        }
    }
}

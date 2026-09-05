namespace PlayGround
{
    internal class Student
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public decimal GPA { get; set; }

        public List<string> WishListCourses { get; set; }

        public Student( string id,string name, decimal gpa, List<string> wishListCourses)
        {
            Name = name;
            Id = id;
            GPA = gpa;
            WishListCourses = wishListCourses;
        }
    }
}
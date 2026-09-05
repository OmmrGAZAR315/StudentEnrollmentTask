namespace PlayGround
{
    internal class CourseRepository : IRepository<Course>
    {
        public static Dictionary<string, Course>? Courses { get; set; }

        public CourseRepository(Dictionary<string, Course>? courses)
        {
            Courses = courses;
        }

        public CourseRepository()
        {
            Courses = new Dictionary<string, Course>();
        }

        public void Add(Course item)
        {
            Courses.TryAdd(item.CourseCode, item);
        }

        public Course? Get(string code)
        {
            return Courses.GetValueOrDefault(code);
        }

        public void Remove(string code)
        {
            Courses.Remove(code);
        }

        public List<Course> GetAll()
        {
            return Courses.Values.ToList();
        }

        public List<Course> Filter(FilterCriteria<Course> criteria)
        {
            // course.CreditHours >= 3.5
            return Courses.Where(kvp => criteria(kvp.Value))
                .Select(kvp => kvp.Value)
                .ToList();
        }
    }
}
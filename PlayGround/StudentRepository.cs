namespace PlayGround
{
    internal class StudentRepository : IRepository<Student>
    {
        public static Dictionary<string, Student>? Students { get; set; }

        public StudentRepository(Dictionary<string, Student>? students)
        {
            Students = students;
        }

        public StudentRepository()
        {
            Students = new Dictionary<string, Student>();
        }

        public void Add(Student item)
        {
            Students.TryAdd(item.Id, item);
        }

        public Student? Get(string id)
        {
            return Students.GetValueOrDefault(id);
        }

        public void Remove(string id)
        {
            Students.Remove(id);
        }

        public List<Student> GetAll()
        {
            return Students.Values.ToList();
        }

        public List<Student> Filter(FilterCriteria<Student> criteria)
        {
            // Student.GPA >= 3.5
            return Students.Where(kvp => criteria(kvp.Value))
                .Select(kvp => kvp.Value)
                .ToList();
        }
    }
}
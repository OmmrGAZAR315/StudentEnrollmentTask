namespace PlayGround
{
    internal class Program
    {
        public static int StudentProjectLimit = 5;

        static void Main(string[] args)
        {
            #region Course Repository

            Dictionary<string, Course> coursesTemp = new()
            {
                { "C1", new("Course1", "C1", 3, "10 weeks", 3.5m) },
                { "C2", new("Course2", "C2", 4, "12 weeks", 4.0m) },
                { "C3", new("Course3", "C3", 2, "8 weeks", 2.5m) },
                { "C4", new("Course4", "C4", 5, "14 weeks", 4.5m) },
                { "C5", new("Course5", "C5", 3, "10 weeks", 3.5m) },
            };

            #endregion

            #region Student Repository

            Dictionary<string, Student> studentApplicants = new()
            {
                { "St1", new("St1", "Student 1", 3.2m, ["C1", "C2", "C3"]) },
                { "St2", new("St2", "Student 2", 3.5m, ["C2", "C3", "C4"]) },
                { "St3", new("St3", "Student 3", 3.0m, ["C1", "C4", "C5"]) },
                { "St4", new("St4", "Student 4", 3.8m, ["C3", "C4", "C5"]) },
                { "St5", new("St5", "Student 5", 3.1m, ["C1", "C2", "C5"]) },
            };

            #endregion

            var courseRepo = new CourseRepository(coursesTemp);
            var studentRepo = new StudentRepository();

            var registeredStudents = new Queue<Student>();
            for (var i = 0; i < StudentProjectLimit; i++)
                registeredStudents.Enqueue(studentApplicants.Values.ToArray()[i]);

            EnrollRepository enrollRepository = new EnrollRepository(studentApplicants);
            var AdminActions = new Stack<string>();

            foreach (var student in registeredStudents)
            {
                foreach (var courseCode in student.WishListCourses)
                {
                    try
                    {
                        enrollRepository.EnrollStudentInCourse(student.Id, courseCode);
                        AdminActions.Push($"Enrolled Student {student.Id} in Course {courseCode}");
                        // Console.WriteLine("Enrolled Student in Course");
                        studentRepo.Add(student);
                    }
                    catch (CourseMaxCapacityException)
                    {
                        AdminActions.Push($"Dropped Course {courseCode}");
                        // Console.WriteLine("Dropped Course");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error enrolling student {student.Id} in course {courseCode}: {ex.Message}");
                        Console.WriteLine($"{ex.StackTrace}");
                    }
                }
            }


            Console.WriteLine(string.Join(",", studentRepo.GetAll()));
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Filter Students with GPA >= 2:");
            studentRepo.Filter(student => student.GPA >= 2.0m).ForEach(c => Console.WriteLine(c.Name+": GPA"+c.GPA));
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Undo Admin Actions:");
            Console.WriteLine(AdminActions.Pop());
            Console.WriteLine(AdminActions.Pop());
        }
    }
}
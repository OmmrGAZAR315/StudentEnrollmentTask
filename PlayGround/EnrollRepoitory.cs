namespace PlayGround
{
    internal class EnrollRepository
    {
        private readonly Dictionary<string, Student>? _students;
        private readonly Dictionary<string, Course>? _courseRepository;

        public EnrollRepository(Dictionary<string, Student> students)
        {
            _students = students;
            _courseRepository = CourseRepository.Courses;
        }

        public void EnrollStudentInCourse(string studentId, string courseCode)
        {
            var student = _students!.GetValueOrDefault(studentId);
            var course = _courseRepository!.GetValueOrDefault(courseCode);
            
            if (student == null || course == null)
            {
                throw new Exception("Student or Course not found.");
            }

            if (course.NumberOfStudents >= course.Capacity)
            {
                throw new CourseMaxCapacityException();
            }

            if (!student.WishListCourses.Contains(courseCode))
            {
                throw new Exception("Student has not wished for this course.");
            }

            // Enroll the student in the course
            course.NumberOfStudents++;
        }
    }
}
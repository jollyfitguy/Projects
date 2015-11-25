using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        Random random;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                random = new Random();
            }

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            List<Course> courses = new List<Course>();
            List<Student> students = new List<Student> { new Student { StudentId = 1, Name = "Benson Price" }, new Student { StudentId = 2, Name = "Ryan Dockstader" } };

            courses.Add(new Course { CourseId = 1, Name = "Computer Science 101", Students = students });
            courses.Add(new Course { CourseId = 2, Name = "Algebra", Students = new List<Student> { new Student { StudentId = 3, Name = "Jared Parkinson" }, students[0] } });
            courses.Add(new Course { CourseId = 3, Name = "English", Students = students });

            foreach (Student student in students)
            {
                student.Courses = courses.FindAll(p => p.Students.Contains(student));
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("Student List:<br/>");
            foreach (Student student in students)
            {
                sb.Append(String.Format("{0} - {1} is enrolled in:<br/>", student.StudentId, student.Name));
                foreach (Course course in student.Courses)
                {
                    sb.Append(String.Format("&nbsp;&nbsp;&nbsp; {0} - {1}<br/>", course.CourseId, course.Name));
                }
                sb.Append("<br/>");
            }

            sb.Append("<br/>Course List:<br/>");
            foreach (Course course in courses)
            {
                sb.Append(String.Format("Course ID: {0}  :  {1}<br/>Students Enrolled<br/>", course.CourseId, course.Name));
                foreach (Student student in course.Students)
                {
                    sb.Append(string.Format("&nbsp;&nbsp;  {0} - {1}<br/>", student.StudentId, student.Name));
                }
            }

            resultLabel.Text = sb.ToString();

        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */

            Dictionary<int, Student> students = new Dictionary<int, Student>
            {
                {1, new Student { Name = "Benson Price", StudentId = 1, Courses = new List<Course> {new Course { Name = "Computer Science", CourseId = 101 }, new Course { Name = "Calculus", CourseId = 220 } } } },
                {2, new Student { Name = "Ryan Dockstader", StudentId = 2, Courses = new List<Course> { new Course { Name = "Computer Science", CourseId = 101 }, new Course { Name = "English", CourseId = 151 } } } },
                {3, new Student { Name = "Jared Parkinson", StudentId = 3, Courses = new List<Course> { new Course { Name = "Computer Science", CourseId = 101 },new Course { Name = "Calculus", CourseId = 220 } } } }
            };

            List<Course> courses = new List<Course>();
            for (int i = 0; i < students.Count; i++)
            {
                foreach (Course course in students.ElementAt(i).Value.Courses)
                {
                    if(!courses.Exists(p => p.CourseId == course.CourseId))
                    {
                        courses.Add(course);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();



            for (int i = 0; i < students.Count; i++)
            {
                sb.Append(String.Format("StudentID:{0} - {1}<br/>Taking<br/>", students.ElementAt(i).Value.Name, students.ElementAt(i).Value.StudentId));
                foreach (Course course in students.ElementAt(i).Value.Courses)
                {
                    sb.Append(string.Format("&nbsp; ID:{0} - {1}<br/>", course.CourseId, course.Name));
                }
                sb.Append("<br/>");
            }

            sb.Append("Courses students are enrolled in:<br/>");
            foreach(Course course in courses)
            {
                sb.Append(String.Format("&nbsp;ID:{0} - {1}<br/>", course.CourseId, course.Name));
            }

            resultLabel.Text = sb.ToString();

        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */

            Dictionary<int, Student> students = new Dictionary<int, Student>
            {
                {
                    1, new Student
                    {
                        Name = "Benson Price",
                        StudentId = 1,
                        Courses = new List<Course>
                        {
                            new Course { Name = "Computer Science", CourseId = 101 },
                            new Course { Name = "Calculus", CourseId = 220 }
                        },
                        Grades = new List<Grade>
                        {
                            new Grade { StudentId = 1, CourseId = 101, PercentageScore = random.Next(55,101) },
                            new Grade { StudentId = 1, CourseId = 220, PercentageScore = random.Next(55,101) }
                        }
                    }
                },
                {
                    2, new Student
                    {
                        Name = "Ryan Dockstader",
                        StudentId = 2,
                        Courses = new List<Course>
                        {
                            new Course { Name = "Computer Science", CourseId = 101 },
                            new Course { Name = "English", CourseId = 151 }
                        },
                        Grades = new List<Grade>
                        {
                            new Grade {StudentId = 2, CourseId = 101, PercentageScore = random.Next(55,101) },
                            new Grade {StudentId = 2, CourseId = 151, PercentageScore = random.Next(55,101) }
                        }
                    }
                },
                {
                    3, new Student
                    {
                        Name = "Jared Parkinson",
                        StudentId = 3,
                        Courses = new List<Course>
                        {
                            new Course { Name = "Computer Science", CourseId = 101 },
                            new Course { Name = "Calculus", CourseId = 220 }
                        },
                        Grades = new List<Grade>
                        {
                            new Grade {StudentId = 3, CourseId = 101, PercentageScore = random.Next(55,101) },
                            new Grade {StudentId = 3, CourseId = 220, PercentageScore = random.Next(55,101) }
                        }
                    }
                }
            };
            

            StringBuilder sb = new StringBuilder();

            sb.Append("Grade List<br/>");

            for (int i = 0; i < students.Count; i++)
            {
                sb.Append(String.Format("StudentID:{0} - {1}<br/>Taking<br/>", students.ElementAt(i).Value.Name, students.ElementAt(i).Value.StudentId));
                foreach (Course course in students.ElementAt(i).Value.Courses)
                {
                    sb.Append(string.Format("&nbsp; ID:{0} - {1} ", course.CourseId, course.Name));
                    foreach(Grade grade in students.ElementAt(i).Value.Grades)
                    {
                        if(grade.CourseId == course.CourseId)
                        {
                            sb.Append(string.Format("Score: {0}<br/>", grade.PercentageScore));
                        }
                    }
                }
                sb.Append("<br/>");
            }

        }
    }
}
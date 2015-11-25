using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    public class Grade
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int PercentageScore { get; set; }
    }
}
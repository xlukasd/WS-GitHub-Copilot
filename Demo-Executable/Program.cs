using Algorithms;
using Exercise_Performance;
using Exercise_Performance.Help;

namespace Demo_Executable
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // #demo_debugging_PerformanceAnalysis
            //DemoSqlPerformance();
            //DemoConcatPerformance();

            // #demo_debugging_ThrownExceptionAnalysis
            //DemoExceptionAnalysis();

            Console.WriteLine("Hello, World!");
        }

        private static void DemoSqlPerformance()
        {
            var connectionString = File.ReadAllText(@"C:\Users\lukas.durovsky\OneDrive - Thermo Fisher Scientific\_private\Praca\_workshops\GitHubCopilot\sql_workshop_connectionstring.txt");
            
            CourseSaver.SaveCourses(Enumerable.Range(0, 150).Select(_ => GenerateRandomCourse()).ToList(), connectionString);
        }

        private static void DemoConcatPerformance()
        {
            string concatenated = string.Empty;
            string toConcat = "a";

            for (int i = 0; i < 200000; i++)
            {
                concatenated += toConcat;
            }
        }

        private static void DemoExceptionAnalysis()
        {
            var connectionString = File.ReadAllText(@"C:\Users\lukas.durovsky\OneDrive - Thermo Fisher Scientific\_private\Praca\_workshops\GitHubCopilot\sql_workshop_connectionstring.txt");

            var course = GenerateRandomCourse();

            string veryLongName = "Very long course name which is definitely exceeding lenght limit.";
            veryLongName = veryLongName.PadLeft(256, 'a');

            course.Name = veryLongName;

            CourseSaver.SaveCourses([course], connectionString);
        }

        private static Course GenerateRandomCourse()
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                DepartmentId = Guid.NewGuid(),
                Lecturer = Guid.NewGuid(),
                Name = "Course Name",
                Amount = 1000,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30)
            };

            return course;
        }
    }
}

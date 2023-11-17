using System.Collections.Generic;
using System.IO;

namespace StudentScores
{
    public class StudentDB
    {
        private const string dir = @"C:\C#\Files\";
        private const string path = dir + "StudentScores.txt";

        public static List<Student> GetStudents()
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            StreamReader textIn = new StreamReader(path);

            List<Student> students = new List<Student>();

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine() ?? "";
                Student student = new Student(row);
                students.Add(student);
            }

            return students; 
        }

        public static void SaveStudents(List<Student> students)
        {
            StreamWriter textOut = new StreamWriter(path, true);

            foreach (Student student in students)
                textOut.WriteLine(student.ToString());
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var university = new University();
            var ministryOfEducation = new MinistryOfEducation(university);

            ministryOfEducation.GenerateStudents();
            List<StudentData> studentDatas = new List<StudentData>();

            foreach (var student in ministryOfEducation)
            {
                studentDatas.Add(new StudentData(student.Name, student.Year));
                Console.WriteLine($"Name = {student.Name}  Year = {student.Year}  Country = {student.Country}");
            }
        }
    }

    class University : IEnumerable<Student>
    {
        private List<Student> _students;

        public University()
        {
            _students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Student
    {
        public string Name;
        public int Year;
        public Countries Country;
    }

    class MinistryOfEducation : IEnumerable<Student>
    {
        private University _university;

        public MinistryOfEducation(University university)
        {
            _university = university;
        }

        public void GenerateStudents()
        {
            _university.AddStudent(new Student() { Name = "Vazgo", Year = 1987, Country = Countries.Armenia });
            _university.AddStudent(new Student() { Name = "Kolya", Year = 2001, Country = Countries.Russia });
            _university.AddStudent(new Student() { Name = "Klimax", Year = 1960, Country = Countries.Russia });
            _university.AddStudent(new Student() { Name = "Klitor", Year = 2000, Country = Countries.USA });
            _university.AddStudent(new Student() { Name = "Katya", Year = 1978, Country = Countries.Russia });
            _university.AddStudent(new Student() { Name = "Aram", Year = 1988, Country = Countries.Armenia });
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return _university.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class StudentData
    { 
        public string Name;
        public int Year;

        public StudentData(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }

    public enum Countries
    {
        Armenia,
        Russia,
        USA
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Moodle moodle = new Moodle();

            Teacher ogretmen = new Teacher(moodle);
            moodle.teacher = ogretmen;

            moodle.students = new List<Student>();

            Student ogrenci1 = new Student(moodle);
            Student ogrenci2 = new Student(moodle);

            moodle.students.Add(ogrenci1);
            moodle.students.Add(ogrenci2);

            ogretmen.SlaytGonder("Tasarım Desenleri");
            ogretmen.SoruGonder("Mediator Pattern Soru");

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Moodle _moodle;

        public CourseMember(Moodle moodle)
        {
            _moodle = moodle;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Moodle moodle) : base(moodle)
        {

        }

        public void SlaytGonder(string url)
        {
            Console.WriteLine("Teacher slayt gönderdi");
            _moodle.SlaytYukle(url);
        }

        public void SoruGonder(string url)
        {
            Console.WriteLine("Teacher soru gönderdi");
            _moodle.OdevYukle(url);
        }
    }

    class Student : CourseMember
    {
        public Student(Moodle moodle) : base(moodle)
        {

        }

        public void SlaytAl(string url)
        {
            Console.WriteLine("Ogrenci Slayt aldı " + url);
        }

        public void OdevAl(string url)
        {
            Console.WriteLine("Ogrenci Ödev aldı " + url);
        }
    }

    class Moodle
    {
        public Teacher teacher { get; set; }
        public List<Student> students { get; set; }

        public void SlaytYukle(string url)
        {
            foreach(var student in students)
            {
                student.SlaytAl(url);
            }
        }

        public void OdevYukle(string url)
        {
            foreach(var student in students)
            {
                student.OdevAl(url);
            }
        }
    }
}

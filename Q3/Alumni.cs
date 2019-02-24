using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Q3
{
    public class Alumni
    {
        public string CourseCode { get; }
        public string FirstName { get; }
        public string Surname { get; }
        public DateTime GradYr { get; }
        public DateTime StartYr { get; }

        public Alumni(string courseCode, string firstName, string surname, DateTime gradYr, DateTime startYr)
        {
            if(gradYr > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException();
            }

            if((gradYr.Year - startYr.Year) > 6)
            {
                throw new ArgumentOutOfRangeException();
            }

            if(courseCode == null)
            {
                throw new ArgumentNullException();
            }

            if(!Regex.IsMatch(courseCode, "^(UG)|(PG)") || courseCode.Length > 8)
            {
                throw new ArgumentException("Invalid argument", "courseCode");
            }

            CourseCode = courseCode;
            FirstName = firstName;
            Surname = surname;
            GradYr = gradYr;
            StartYr = startYr;
        }
    }

    public class AlumnusList
    {
        public List<Alumni> Alumnus { get; }

        public AlumnusList()
        {
            Alumnus = new List<Alumni>();
        }

        public void AddAlumni(Alumni alumni)
        {
            if(alumni == null)
            {
                throw new ArgumentNullException();
            }

            Alumnus.Add(alumni);
        }

        public void AddAlumnus(Alumni[] alumnus)
        {
            if (alumnus == null)
            {
                throw new ArgumentNullException();
            }
            foreach (Alumni alum in alumnus)
            {
                if(alum == null)
                {
                    throw new ArgumentNullException();
                }
            }
            Alumnus.AddRange(alumnus);
        }

        public bool RemoveAlumni(Alumni alumni)
        {
            if(Alumnus.Count() == 0)
            {
                throw new ArgumentException("Alumnus List was empty, nothing to be removed");
            }
            return Alumnus.Remove(alumni);
            
        }

    }
}

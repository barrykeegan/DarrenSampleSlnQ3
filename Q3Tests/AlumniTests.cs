using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q3;

namespace Q3Tests
{
    [TestClass]
    public class AlumniTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateAlumniWithFutureGradDateShouldThrowArgumentOutOfRangeException()
        {
            DateTime futureDateTime = new DateTime(2200, 12, 1);

            DateTime startDateTime = new DateTime(2015, 12, 1);

            Alumni alumni = new Alumni("UG123", "Joe", "Stevens", futureDateTime, startDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateAlumniNumOfYrsBetweenStartAndGradMoreThan6YrsShouldThrowArugmentOutOfRangeException()
        {
            DateTime startDateTime = new DateTime(2001, 12, 1);

            DateTime gradDateTime = DateTime.Now;

            Alumni alumni = new Alumni("UGAC1", "Nikki", "Bell", gradDateTime, startDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateAlumniWithNullCourseCodeShouldThrowArgumentNullException()
        {
            DateTime startDateTime = new DateTime(2014, 12, 1);

            DateTime gradDateTime = new DateTime(2015, 12, 2);

            Alumni alumni = new Alumni(null, "Sarah", "Cornell", gradDateTime, startDateTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateAlumniWithIncorrectCourseCodeFormatShouldThrowArgumentException()
        {
            DateTime startDateTime = new DateTime(2013, 09, 11);

            DateTime gradDateTime = new DateTime(2016, 10, 22);

            Alumni alumni = new Alumni("BH101", "Dave", "McHale", gradDateTime, startDateTime);
        }

        [TestMethod]
        public void AddAlumniUpdatesEmptyAlumnusWithNewAlumni()
        {
            DateTime startDateTime = new DateTime(2015, 12, 12);

            DateTime gradDateTime = new DateTime(2016, 6, 6);

            Alumni alumni = new Alumni("PG192E1", "Phil", "Davids", gradDateTime, startDateTime);

            AlumnusList alumnus = new AlumnusList();

            alumnus.AddAlumni(alumni);

            CollectionAssert.Contains(alumnus.Alumnus, alumni);

            /*
             Above line is equivalent to the following...
            List<Alumni> alums = new List<Alumni>();
            alums.Add(alumni);

            CollectionAssert.AreEquivalent(alumnus.Alumnus, alums);
            */
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullAlumniToAlumnusListShouldThrowArgumentNullException()
        {
            Alumni alumni = null;

            AlumnusList alumnus = new AlumnusList();

            alumnus.AddAlumni(alumni);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullAlumniArrayToAlumnusListShouldThrowArgumentNullException()
        {
            Alumni[] nullAlumnus = null;

            AlumnusList alumnus = new AlumnusList();

            alumnus.AddAlumnus(nullAlumnus);
        }

        [TestMethod()]
        public void AddAlumniArrayToAlumnusShouldContainArrayEntriesInAlumnusList()
        {
            DateTime startDateTime = new DateTime(2015, 12, 12);

            DateTime gradDateTime = new DateTime(2016, 6, 6);

            Alumni alumni1 = new Alumni("PG192E1", "Phil", "Davids", gradDateTime, startDateTime);
            Alumni alumni2 = new Alumni("UG333F1", "Bazz", "Atron", gradDateTime, startDateTime);

            Alumni[] alumniArray = new Alumni[2];

            AlumnusList alumnus = new AlumnusList();

            alumniArray.SetValue(alumni1, 0);
            alumniArray.SetValue(alumni2, 1);

            alumnus.AddAlumnus(alumniArray);

            CollectionAssert.Contains(alumnus.Alumnus, alumni1);
            CollectionAssert.Contains(alumnus.Alumnus, alumni2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddAlumniArrayWithOneNullAlumniToAlumnusShouldThrowArgumentNullException()
        {
            DateTime startDateTime = new DateTime(2015, 12, 12);

            DateTime gradDateTime = new DateTime(2016, 6, 6);

            Alumni alumni1 = new Alumni("PG192E1", "Phil", "Davids", gradDateTime, startDateTime);
            Alumni alumni2 = null;

            Alumni[] alumniArray = new Alumni[2];

            AlumnusList alumnus = new AlumnusList();

            alumniArray.SetValue(alumni1, 0);
            alumniArray.SetValue(alumni2, 1);

            alumnus.AddAlumnus(alumniArray);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveFromEmptyAlumnusListShouldThrowArgumentException()
        {
            DateTime startDateTime = new DateTime(2015, 12, 12);
            DateTime gradDateTime = new DateTime(2016, 6, 6);
            Alumni alumni = new Alumni("PG192E1", "Phil", "Davids", gradDateTime, startDateTime);

            AlumnusList alumnus = new AlumnusList();

            alumnus.RemoveAlumni(alumni);
        }

        [TestMethod()]
        public void RemoveAddedAlumniFromAlumnusListShouldRemoveAlumni()
        {
            DateTime startDateTime = new DateTime(2015, 12, 12);
            DateTime gradDateTime = new DateTime(2016, 6, 6);
            Alumni alumni = new Alumni("PG192E1", "Phil", "Davids", gradDateTime, startDateTime);
            AlumnusList alumnus = new AlumnusList();
            alumnus.AddAlumni(alumni);
            //verify alumni was added in the first place
            CollectionAssert.Contains(alumnus.Alumnus, alumni);

            Assert.AreEqual(true, alumnus.RemoveAlumni(alumni));

            //verify alumni removed
            CollectionAssert.DoesNotContain(alumnus.Alumnus, alumni);
        }
    }
}

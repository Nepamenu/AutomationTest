using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation
{
    public class Demo
    {
        [Test]

        public static void TestForIsEven()
        {
            int leftover = 4 % 2;
            Assert.AreEqual(0, leftover, "4 is not even");
        }

        [Test]
        
        public static void TestNowIs18()
        {
            DateTime CurrentTime = DateTime.Now;
            //Assert.AreEqual(19, CurrentTime.Hour, "Dabar ne 18 valanda");
            Assert.IsTrue(CurrentTime.Hour.Equals(20), "Dabar ne 18 valanda");
        }

        [Test]

        public static void ArDalinasBeLiekanos()
        {
            int beLiekanos = 955 % 3;
            //Assert.True(996 % 3 == 0, "Isint devided 3");
            Assert.AreEqual(0, beLiekanos, "Nesidalina be liekanos");

        }


        [Test]
        public static void IsMonday()
        {
            DateTime currentDay = DateTime.Now;
            Assert.AreEqual(DateTime.Today.DayOfWeek, currentDay, "Dabar ne pirmadienis");

        }

        [Test]
        public static void TestWaitFor5S()
        {
            Thread.Sleep(5000);
        }

    }
}

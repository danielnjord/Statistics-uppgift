using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; // importerar NUnit.Framework-namespace
using Statistics; 


namespace Statistics.StatisticsTests
{
    internal class Class1
    {
        [Test]
        public void TestMaximum()
        {
            // Skriv ditt testfall här
            int[] testData = { 1, 2, 3, 4, 5 };
            int expected = 5;
            int actual = Statistics.Statistics.Maximum(testData); // Anropa Maximum-metoden från Statistics-klassen
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMinimum()
        {
            // Skriv ditt testfall här
        }

        // Lägg till fler testfall för andra metoder...
    }

}

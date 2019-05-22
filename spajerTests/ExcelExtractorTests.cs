using NUnit.Framework;
using spajer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spajer.Tests
{
    [TestFixture()]
    public class ExcelExtractorTests
    {
        [Test()]
        public void ExtractTest()
        {
            var ee = new ExcelExtractor();
            var res = ee.ExtractScheduleItems();
            var exp = new ScheduleItem()
            {
                Leader = "Ula",
                Name = "AKTYWNY SENIOR",
                Place = new Place() { Address = "jupiter" },
                Time = new DateTime(1, 1, 1, 9, 0, 0)
            };
            Assert.AreEqual(exp.Time,res[0].Time);
            Assert.AreEqual(exp.Place.Address,res[0].Place.Address);
            Assert.AreEqual(exp.Name,res[0].Name);
            Assert.AreEqual(exp.Leader,res[0].Leader);
        }
    }
}
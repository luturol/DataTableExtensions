using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocExentesions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PocExtensionTests
{
    [TestClass]
    public class DataTableExtensionsTests
    {
        [TestMethod]
        public void ShouldBeAbleToMapObjectFromSelectInDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] { new DataColumn("Name", typeof(string)), new DataColumn("Age", typeof(int)) });

            DataRow row = table.NewRow();
            row["Name"] = "Rafael";
            row["Age"] = 22;
            table.Rows.Add(row);
            row = table.NewRow();
            row["Name"] = "Bellinha";
            row["Age"] = 10;
            table.Rows.Add(row);
            List<Person> persons = table.Select<Person>().ToList();
            Assert.IsTrue(persons.Count == 2);

        }
    }
}

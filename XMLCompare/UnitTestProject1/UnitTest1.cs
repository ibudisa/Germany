using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLCompare;
using DAL;
using System.Collections.Generic;

namespace UnitTestProject1
{
   /* [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSameXML()
        {
            CompareFile c = new CompareFile(@"C:\drivers\Test11.xml", @"C:\drivers\Test1.xml");
            List<FileData> data = c.Compare();
            bool b = false;
            if (data.Count==0)
            {
                b = true;
            }
            else
            {
                b = false;
            }
            Assert.IsTrue(b);
        }

        [TestMethod]
        public void TestDifferentAttribute()
        {
            CompareFile c = new CompareFile(@"C:\drivers\Test12.xml", @"C:\drivers\Test1.xml");
            List<FileData> data = c.Compare();
             string id = data[0].NodeName;
            Assert.AreEqual("ID", id);
        }


        [TestMethod]
        public void TestDifferentElement()
        {
            CompareFile c = new CompareFile(@"C:\drivers\Test13.xml", @"C:\drivers\Test1.xml");
            List<FileData> data = c.Compare();
            string title = data[0].NodeName;
            Assert.AreEqual("title", title);
        }
    }*/
}

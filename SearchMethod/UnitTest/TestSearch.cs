using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using NUnit.Framework;


namespace UnitTest
{
    [TestFixture]
    public class TestSearch
    {
        [Test]
        public  void TestPattern1Res()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("1;158;",df.Find("the",100,200,1));
        }

        [Test]
        public void TestPattern2Res()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("2;158;211;", df.Find("the",100,250,2));
        }

        [Test]
        public void TestPattern5Res()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("5;8;62;98;158;211;", df.Find("the",0,250,5));
        }

        [Test]
        public void TestPattern3Res()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("3;98;158;211;", df.Find("the",80,250,5));
        }

        [Test]
        public void TestPattern2ResReversed()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("2;243;176;", df.Find("searched",260,150,2));
        }

        [Test]
        public void TestPattern3ResReversed()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("3;243;176;77;", df.Find("searched",260,0,3));
        }

        [Test]
        public void TestPattern1ResReversed()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("1;170;", df.Find("to",270,100,1));
        }

        [Test]
        public void TestPattern4ResReversedFromOffsetToBig()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("4;235;194;25;5;", df.Find("is",5000,0,4));
        }

        [Test]
        public void TestPattern4ResToOffsetToBig()
        {
            DataFile df = new DataFile(@"D:\SearchMethod\SearchMethod\SearchMethod\File.txt");

            Assert.AreEqual("2;194;235;", df.Find("is",100,10000,2));
        }
    }
}

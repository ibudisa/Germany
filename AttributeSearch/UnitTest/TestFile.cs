using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Data;

namespace UnitTest
{
    [TestFixture]
    public class TestFile
    {   
        [Test]
        public  void Match1Attribute1Hit()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");
            
            //StringAssert.IsMatch("1;73;138;",atfile.Match("0+3+001",1));

            Assert.AreEqual("1;1390;44;", atfile.Match("4+10+0100000015",1,0,1500));
          
        }

        [Test]
        public void Match1Attribute2Hits()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("2;1519;41;1560;43;", atfile.Match("4+10+1700000000",2,1519,1603));
        }

        [Test]
        public void AttributeValueNotFound()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("0;", atfile.Match("0+4+1001",2,0,1500));
        }

        [Test]
        public void Match2Attributes3Hits()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("3;1434;44;1478;41;1434;44;", atfile.Match("0+4+1000#4+10+0100000016", 3, 1434, 1519));
        }

        [Test]
        public void Match2Attributes1Hit()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("1;1434;44;", atfile.Match("0+4+1000#4+10+0100000016", 1, 1434, 1519));
        }

        [Test]
        public void InvalidPattern()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("Pattern invalid!", atfile.Match("1+3+001#8+7+0147119",1,1434,1519));
        }

        [Test]
        public void Match1Attribute2HitsFromToOffset()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("2;1390;44;1434;44;", atfile.Match("0+4+1000",2,1390,1478));
        }

        [Test]
        public void Match2Attributes3HitsFromToOffset()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("3;1728;41;1769;41;1728;41;", atfile.Match("0+4+1000#4+10+1900000001", 3, 1728, 1810));
        }

        [Test]
        public void Match2Attributes3HitsFromToOffsetReversed()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("3;1769;41;1728;41;1728;41;", atfile.Match("0+4+1000#4+10+1900000001",3,1810,1728));
        }
        [Test]
        public void Match1Attribute2HitsFromToOffsetReversed()
        {
            AttributeFile atfile = new AttributeFile(@"D:\AttributeSearch\AttributeSearch\00000107_00000168.descr");

            Assert.AreEqual("2;1434;44;1390;44;", atfile.Match("0+4+1000",2,1478,1390));
        }
    }
}

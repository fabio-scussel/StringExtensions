using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scussel.StringExtensions;
using System;

namespace Tests
{
    [TestClass]
    public class TestsStringExtensions
    {
        [TestMethod]
        public void Scussel_StringExtensions_CapitalizeFirstLetterTest()
        {
            string t = null;
            Assert.AreEqual(null, t.CapitalizeFirstLetter());
            t = "test";
            Assert.AreEqual("Test", t.CapitalizeFirstLetter());
            t = "";
            Assert.AreEqual(t, t.CapitalizeFirstLetter());
            t = "43test abc";
            Assert.AreEqual(t, t.CapitalizeFirstLetter());
            t = "ú";
            Assert.AreEqual("Ú", t.CapitalizeFirstLetter());
        }

        [TestMethod]
        public void Scussel_StringExtensions_ContainsTest()
        {
            string[] options = { "abc", "foo", "xyz" };
            string t = null;
            Assert.AreEqual<bool>(false, t.Contains(options));

            t = "test foo";
            Assert.AreEqual<bool>(true, t.Contains(options));
        }

        [TestMethod]
        public void Scussel_StringExtensions_GetFirstWordTest()
        {
            string t = null;
            Assert.AreEqual(null, t.GetFirstWord());
            t = "test abc";
            Assert.AreEqual("test", t.GetFirstWord());
            t = "";
            Assert.AreEqual(t, t.GetFirstWord());
            t = "43test abc";
            Assert.AreEqual("43test", t.GetFirstWord());
            t = " abc";
            Assert.AreEqual("abc", t.GetFirstWord());
        }

        [TestMethod]
        public void Scussel_StringExtensions_GetNumbersTest()
        {
            string t = null;
            Assert.AreEqual("", t.GetNumbers());
            t = "test abc";
            Assert.AreEqual("", t.GetNumbers());
            t = "(51)3344-4303";
            Assert.AreEqual("5133444303", t.GetNumbers());
            t = "a0b1c2";
            Assert.AreEqual("012", t.GetNumbers());
        }

        [TestMethod]
        public void Scussel_StringExtensions_LeftTest()
        {
            string t = null;
            Assert.AreEqual(null, t.Left(4));
            t = "test abc";
            Assert.AreEqual("test", t.Left(4));
            t = "test abc";
            Assert.AreEqual(t, t.Left(40));
        }

        [TestMethod]
        public void Scussel_StringExtensions_HashTest()
        {
            string t = "foo";
            Assert.AreEqual(1628994470, t.Hash());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Scussel_StringExtensions_HashExceptionTest()
        {
            string t = null;
            Assert.AreEqual(1628994470, t.Hash());
        }

        [TestMethod]
        public void Scussel_StringExtensions_ReplaceFirstTest()
        {
            string t = null;
            Assert.AreEqual(null, t.ReplaceFirst("test", "foo"));
            t = "";
            Assert.AreEqual(t, t.ReplaceFirst("test", "foo"));
            t = "test test abc";
            Assert.AreEqual("foo test abc", t.ReplaceFirst("test", "foo"));
            t = "xyz test test abc";
            Assert.AreEqual("xyz foo test abc", t.ReplaceFirst("test", "foo"));
            t = "xyz test test abc";
            Assert.AreEqual("xyz  test abc", t.ReplaceFirst("test", null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Scussel_StringExtensions_ReplaceFirstExceptionTest()
        {
            string t = "xyz test test abc";
            Assert.AreEqual("xyz  test abc", t.ReplaceFirst(null, "foo"));
        }

        [TestMethod]
        public void Scussel_StringExtensions_ToIntTest()
        {
            string t = null;
            Assert.AreEqual(0, t.ToInt());
            t = "abc";
            Assert.AreEqual(0, t.ToInt());
            t = "  -9 ";
            Assert.AreEqual(-9, t.ToInt());
            t = "854";
            Assert.AreEqual(854, t.ToInt());
            t = "854,98";
            Assert.AreEqual(0, t.ToInt());
        }

        [TestMethod]
        public void Scussel_StringExtensions_ToUshortTest()
        {
            string t = null;
            Assert.AreEqual(0, t.ToUshort());
            t = "abc";
            Assert.AreEqual(0, t.ToUshort());
            t = "  -9 ";
            Assert.AreEqual(0, t.ToUshort());
            t = "854";
            Assert.AreEqual(854, t.ToUshort());
            t = "854,98";
            Assert.AreEqual(0, t.ToUshort());
        }

        [TestMethod]
        public void Scussel_StringExtensions_RemoveDiacriticsTest()
        {
            Assert.AreEqual(" ACEGUA", "ACEGUÁ".RemoveDiacritics());
            Assert.AreEqual("SAO JOAO", "SÃO JOÃO".RemoveDiacritics());
            string c = null;
            Assert.IsNull(c.RemoveDiacritics());
        }
    }
}

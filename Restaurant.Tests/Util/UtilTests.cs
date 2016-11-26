using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Common;

namespace Restaurant.Tests.Util
{
    [TestClass]
    public class UtilTests
    {

        [TestMethod]
        public void EncoderUtilShouldEncode()
        {
            // Arrange         
            var testText = "test";

            // Act
            var encText = DecoderUtil.Encrypt(testText);

            // Assert
            Assert.AreNotEqual(testText, encText);
        }

        [TestMethod]
        public void DecoderUtilShouldDecode()
        {
            // Arrange         
            var testText = "test";

            // Act
            var encText = DecoderUtil.Encrypt(testText);
            var decText = DecoderUtil.Decrypt(encText);


            // Assert
            Assert.AreEqual(testText, decText);
        }


    }
}

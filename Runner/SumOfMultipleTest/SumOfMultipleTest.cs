using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemInterfaces;
using System;
using System.IO;
using System.Text;

namespace SumOfMultipleTest
{
    [TestClass]
    public class SumOfMultipleTest
    {
        [TestMethod]
        public void TakeUserInput_ValidInteger()
        {
            StringBuilder fakeOutput = SetupConsoleWatcher();

            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();
            var fakeUserInput = new FakeValidInput();
            var input = sumOfMultiple.TakeUserInput(fakeUserInput);

            StringAssert.Contains(SumOfMultiple.SumOfMultiple.AskForUserInput, fakeOutput.ToString().Trim());

            Assert.AreEqual(expected: "10", input);
        }

        [TestMethod]
        public void TakeUserInput_ValidNegativeInteger()
        {
            StringBuilder fakeOutput = SetupConsoleWatcher();

            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();
            var fakeUserInput = new FakeNegativeInput();
            var input = sumOfMultiple.TakeUserInput(fakeUserInput);

            StringAssert.Contains(SumOfMultiple.SumOfMultiple.AskForUserInput, fakeOutput.ToString().Trim());

            Assert.AreEqual(expected: "-10", input);
        }

        [TestMethod]
        public void TakeUserInput_InvalidInteger()
        {
            SetupConsoleWatcher();

            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();
            var fakeUserInput = new FakeInvalidInput();

            Assert.ThrowsException<OutOfMemoryException>(() => sumOfMultiple.TakeUserInput(fakeUserInput));
        }

        [TestMethod]
        public void PerformSum_ValidLimit()
        {
            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();           

            Assert.AreEqual(expected: 23, sumOfMultiple.PerformSum(10));
        }

        [TestMethod]
        public void PerformSum_ValidNegativeLimit()
        {
            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();

            Assert.AreEqual(expected: -23, sumOfMultiple.PerformSum(-10));
        }

        [TestMethod]
        public void PerformSum_TooLargeLimit()
        {
            StringBuilder fakeOutput = SetupConsoleWatcher();

            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();
            
            Assert.ThrowsException<ArgumentException>(() => sumOfMultiple.PerformSum(565656565));
            StringAssert.Contains(SumOfMultiple.SumOfMultiple.TooLargeLimit, fakeOutput.ToString().Trim());
        }

        [TestMethod]
        public void PerformSum_ZeroLimit()
        {
            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();

            Assert.AreEqual(expected: 0, sumOfMultiple.PerformSum(0));
        }

        [TestMethod]
        public void GetFinalString_Valid()
        {
            var sumOfMultiple = new SumOfMultiple.SumOfMultiple();

            StringAssert.Contains(sumOfMultiple.GetFinalString(23), "23");

            StringAssert.Contains(sumOfMultiple.GetFinalString(23), "3,5");
        }

        private static StringBuilder SetupConsoleWatcher()
        {
            var fakeOutput = new StringBuilder();
            var writer = new StringWriter(fakeOutput);
            
            Console.SetOut(writer);
            return fakeOutput;
        }

        #region FakeInputs
        private class FakeValidInput : IUserInput
        {
            public string GetUserInput()
            {
                return "10";
            }
        }

        private class FakeNegativeInput : IUserInput
        {
            public string GetUserInput()
            {
                return "-10";
            }
        }

        private class FakeInvalidInput : IUserInput
        {
            public string GetUserInput()
            {
                return "abc";
            }
        } 
        #endregion
    }
}

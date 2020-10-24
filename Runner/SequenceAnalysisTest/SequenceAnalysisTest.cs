using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SequenceAnalysisTest
{
    [TestClass]
    public class SequenceAnalysisTest
    {
        [TestMethod]
        public void SortCharacters_Valid()
        {
            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();

            Assert.AreEqual(expected: "AIM", sequenceAnalysis.SortCharacters(new List<char> { 'M', 'A', 'I' }));

        }

        [TestMethod]
        public void FindUpperCaseWords_AllUpperCaseWords()
        {
            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();

            var result = sequenceAnalysis.FindUpperCaseWords("I AM NILANJAN");

            var expected = new List<char> { 'I', 'A', 'M', 'N', 'I', 'L', 'A', 'N', 'J', 'A', 'N' };


            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindUpperCaseWords_PartialUpperCaseWords()
        {
            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();

            var result = sequenceAnalysis.FindUpperCaseWords("I am Nilanjan DUTTA");

            var expected = new List<char> { 'I', 'D', 'U', 'T', 'T', 'A' };


            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FindUpperCaseWords_NoUpperCaseWords()
        {
            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();

            var result = sequenceAnalysis.FindUpperCaseWords("i am Nilanjan Dutta");

            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void TakeUserInput_ValidString()
        {
            StringBuilder fakeOutput = SetupConsoleWatcher();

            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();
            var fakeUserInput = new FakeValidInput();
            var input = sequenceAnalysis.TakeUserInput(fakeUserInput);

            StringAssert.Contains(SequenceAnalysis.SequenceAnalysis.AskForUserInput, fakeOutput.ToString().Trim());

            Assert.AreEqual(expected: "I am Nilanjan DUTTA", input);
        }

        

        [TestMethod]
        public void TakeUserInput_EmptyString()
        {
            SetupConsoleWatcher();

            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();
            var fakeUserInput = new FakeInvalidInput();            

            Assert.ThrowsException<OutOfMemoryException>(() => sequenceAnalysis.TakeUserInput(fakeUserInput));
        }

        [TestMethod]
        public void ShowResult_WithUpperCaseLetters()
        {
            StringBuilder fakeOutput = SetupConsoleWatcher();

            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();
            sequenceAnalysis.ShowResult(new List<char> { 'I', 'D', 'U', 'T', 'T', 'A' });

            StringAssert.Contains("Output: ADITTU", fakeOutput.ToString().Trim());
        }

        [TestMethod]
        public void ShowResult_WithEmptyUpperCaseLettersList()
        {
            StringBuilder fakeOutput = SetupConsoleWatcher();

            var sequenceAnalysis = new SequenceAnalysis.SequenceAnalysis();
            sequenceAnalysis.ShowResult(new List<char>());

            StringAssert.Contains(SequenceAnalysis.SequenceAnalysis.NoUpperCaseLettersFound, fakeOutput.ToString().Trim());
        }

        private static StringBuilder SetupConsoleWatcher()
        {
            var fakeOutput = new StringBuilder();
            var writer = new StringWriter(fakeOutput);

            Console.SetOut(writer);
            return fakeOutput;
        }

        #region Fake Inputs
        private class FakeValidInput : IUserInput
        {
            public string GetUserInput()
            {
                return "I am Nilanjan DUTTA";
            }
        }

        private class FakeInvalidInput : IUserInput
        {
            public string GetUserInput()
            {
                return string.Empty;
            }
        } 
        #endregion
    }
}

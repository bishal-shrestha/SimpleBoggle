using System;
using ServerApp.Models;
using Xunit;

namespace ServerApp.Tests
{
    public class WordValidatorTests
    {
        [Fact]
        public void IsWordValid()
        {
            bool validWord = WordValidator.IsWordInDict("educational");
            Assert.True(validWord);
        }
    }
}
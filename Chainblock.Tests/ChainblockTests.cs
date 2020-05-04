using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private IChainblock testChainblock; 

        [SetUp]
        public void CreateTestChainblock()
        {

        }

        [Test]
        public void TestAddShoudAddTransactionToChainblock()
        {
            this.testChainblock = new ChainBlock();

            var testTarnsaction = new Transaction(1, "John", "Paul", "FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d", TransactionStatus.Successfull);
            this.testChainblock.Add(testTarnsaction);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount,testChainblock.Count);
            Assert.IsTrue(testChainblock.Contains(testTarnsaction));
        }

        [Test]
        public void TestTryingToAddNullTransactionShoudThrowException()
        {
            this.testChainblock = new ChainBlock();

            Assert.That(() =>
            {
                this.testChainblock.Add(null);
            }
            , Throws
            .ArgumentException
            .With
            .Message
            .EqualTo(ExceptionMessages.TransactionCanNotBeNull));
        }
    }
}
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

        [Test]
        public void TestCountShoudReturnCorrectValue()
        {
            CreateTestChainblock();

            int expectedCount = 5;
            Assert.AreEqual(expectedCount,this.testChainblock.Count);

            this.testChainblock.Add(new Transaction(6, "Dorian", "Simon", "TtQxPb#+2f4Tl_H-#UJ%i^ZYO7hY#6GGwuwn7*sUxk$OOuFF", TransactionStatus.Successfull));
            expectedCount += 1;

            Assert.AreEqual(expectedCount, this.testChainblock.Count);

            this.testChainblock.RemoveTransactionById(5);
            expectedCount -= 1;

            Assert.AreEqual(expectedCount, this.testChainblock.Count);
        }

        [Test]
        public void TetsTryingToAddInvalidDataShoudNotAffectCount()
        {
            CreateTestChainblock();

            int expectedCount = 5;
            Assert.AreEqual(expectedCount, this.testChainblock.Count);

            Assert.That(() =>
            {
                this.testChainblock.Add(null);
            }
            , Throws
            .ArgumentException
            .With
            .Message
            .EqualTo(ExceptionMessages.TransactionCanNotBeNull));

            expectedCount = 5; //Count shoud be still the same!

            Assert.AreEqual(expectedCount, this.testChainblock.Count);
        }

        private void CreateTestChainBlock()
        {
            this.testChainblock = new ChainBlock();
            var testTarnsaction1 = new Transaction(1, "John", "Paul", "FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d", TransactionStatus.Successfull);
            var testTarnsaction2 = new Transaction(2, "Tom", "Jane", "EPbeY6&bfeKRuU9fU_3kLc**e=^tr3vg#6CwXPhNYznPa*4z^n^h", TransactionStatus.Aborted);
            var testTarnsaction3 = new Transaction(3, "Anna", "George", "qa0!@UTkevE*rxgN8bvMB3d#-u-=h6*J_my4^jtCJ#6jDa&?", TransactionStatus.Successfull);
            var testTarnsaction4 = new Transaction(4, "Marco", "Gert", "'6}A&)tN6sU;#*!Mc~xzCGj){DRDa7kXJk9K7qEfA;t<_4LthP8+a@8(uG{-#8LD", TransactionStatus.Unauthorized);
            var testTarnsaction5 = new Transaction(5, "Otto", "Frank", "2vLy.,6,%*esEDxJ*=B_aymRZKnX9JnZ(D<YwNkAZ2HSgx%G2UC}>SWLx]T5f-3Q", TransactionStatus.Failed);
        }
    }
}
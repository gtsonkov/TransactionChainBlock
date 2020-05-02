using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    public class TransactionTests
    {
        //SequreString: In Production mode this string will be generated form another software here will be used only test values.

        [Test]
        public void TestConstructorShoudWorkCorrectly()
        {
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = "David";
            string to = "Tom";
            string sequreString = @"FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d"; //In Production mode this string will be generated form another software here will be used only test values.

            ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);

            Assert.AreEqual(id, testTransaction.Id);
            Assert.AreEqual(from, testTransaction.From);
            Assert.AreEqual(to, testTransaction.To);
            Assert.AreEqual(sequreString, testTransaction.SequreString);
            Assert.AreEqual(transactionStatus, testTransaction.Status);
        }

        [Test]
        [TestCase(-161)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestShoudThrowExceptionIfTryToCreateTransactionWithInvalidID(int id)
        {
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            string from = "David";
            string to = "Tom";
            string sequreString = @"FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d"; //In Production mode this string will be generated form another software here will be used only test values.

            Assert.That(() =>
            {
                ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);
            }
            , Throws
            .ArgumentException
            .With
            .Message
            .EqualTo(ExceptionMessages.InvalidIDMessage));
        }
    }
}
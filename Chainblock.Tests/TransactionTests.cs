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
        public void TestChangeSenderShoudWorkCorrectly()
        {
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = "David";
            string to = "Tom";
            string sequreString = @"FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d"; //In Production mode this string will be generated form another software here will be used only test values.

            ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);
            Assert.AreEqual(from, testTransaction.From);

            from = "Martin";
            testTransaction.From = from;
            Assert.AreEqual(from, testTransaction.From);
        }

        [Test]
        public void TestChangeRecieverShoudWorkCorrectly()
        {
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = "David";
            string to = "Tom";
            string sequreString = @"FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d"; //In Production mode this string will be generated form another software here will be used only test values.

            ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);
            Assert.AreEqual(from, testTransaction.From);

            to = "Martin";
            testTransaction.To = to;
            Assert.AreEqual(to, testTransaction.To);
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

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestShoudThrowExceptionIfTryToCreateTransactionWithInvalidSenderName(string senderName) //From
        {
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = senderName;
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
            .EqualTo(ExceptionMessages.InvalidSenderRecieverUsernameMessage));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestShoudThrowExceptionIfTryToCreateTransactionWithInvalidRecieverrName(string recieverName) //To
        {
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = "David";
            string to = recieverName;
            string sequreString = @"FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d"; //In Production mode this string will be generated form another software here will be used only test values.

            Assert.That(() =>
            {
                ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);
            }
            , Throws
            .ArgumentException
            .With
            .Message
            .EqualTo(ExceptionMessages.InvalidSenderRecieverUsernameMessage));
        }

        [Test]
        [TestCase("21rm$u*&msc5V4GaGpGUuC@ev%y81l8m7N?CHJrbQ6kv6!")] //46
        [TestCase("Q#KGrJ8yx8Ecl3O6SA-ydyY$2*$X#q+rfzCFh2EyaBy222CEn")] //49
        [TestCase("7o$=vamUNPMRWkPG|9p_UDE%pcW!2C+CLm*5rju#4&cD1MfMDr")] //50
        [TestCase("Ec?jF5j3c4LYF240@TBQf+=yiCjy=LQ|dS_mO93JI34C9X_?dvu5-=S")] //55
        [TestCase("q^V2V$5l@Ie#u8+O5S=R#IS|uHBk*PG5YB9L%d!u$B_5a-MFBi9&J#fY9DZE")] //60
        [TestCase("A%sv@smMW4L_a?z1q#&&SyjtszPYGcZ=^T!7zAI2Qj%|YG+IpRFV9RQbMZ*tM6Q")] //63
        [TestCase("6v8Z9v1?HV_vtNgL#itC_2njem9E8Uyjz&A^pP1r&*gFiXw?hA!E#q1vSIGVOS1?Z")] //65
        [TestCase("9&ergMc47t8L%yC+K^qY?6s9m?1AnJrF6@hHlD%I?_.VWrO$a1402!#RkpTAX&KbIYlm8n=&P9!Xje?6GVqOuCiJed10xv?JW4H@T")] //101
        public void TestShoudThrowExceptionIfTryToCreateTransactionWithInvalidSequreStringLenght(string sqString)
        {
            //Testing from SequreString here is possible only with lenght. Validation of sequre string will be Assure from another software in Production mode. The sense from this calss is not to assure this validation. 
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = "David";
            string to = "Tom";
            string sequreString = sqString; //In Production mode this string will be generated form another software here will be used only test values.

            Assert.That(() =>
            {
                ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);
            }
            , Throws
            .ArgumentException
            .With
            .Message
            .EqualTo(ExceptionMessages.InvalidSequreStringLenght));
        }

        [Test]
        public void TestSequreStringShoudBeSuccessfulyChanged()
        {
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = "David";
            string to = "Tom";
            string sequreString = @"FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOu4d"; //In Production mode this string will be generated form another software here will be used only test values.

            ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);

            Assert.AreEqual(sequreString, testTransaction.SequreString);

            sequreString = @"qa0!@UTkevE*rxgN8bvMB3d#-u-=h6*J_my4^jtCJ#6jDa&?"; // 48
            testTransaction.SequreString = sequreString;
            Assert.AreEqual(sequreString, testTransaction.SequreString);

            sequreString = @"EPbeY6&bfeKRuU9fU_3kLc**e=^tr3vg#6CwXPhNYznPa*4z^n^h"; // 52
            testTransaction.SequreString = sequreString;
            Assert.AreEqual(sequreString, testTransaction.SequreString);

            sequreString = @"pzc*fgbR_S_-g#KP98Ku7#2Z77@rcrY=2DtxE#tf7M+d%TKB%A8YPHteU6yjZN%A"; // 64
            testTransaction.SequreString = sequreString;
            Assert.AreEqual(sequreString, testTransaction.SequreString);
        }

        [Test]
        public void TestStatusShoudBeChangeSuccessffuly()
        {
            //Test data
            TransactionStatus transactionStatus = TransactionStatus.Successfull;
            int id = 1;
            string from = "David";
            string to = "Tom";
            string sequreString = @"FtQxPb#+2f4Tl|O?iUp%i^+YO7hY#6GGwuwn7*sUxk$OOutd"; //In Production mode this string will be generated form another software here will be used only test values.

            ITransaction testTransaction = new Transaction(id, from, to, sequreString, transactionStatus);

            Assert.AreEqual(transactionStatus, testTransaction.Status);

            transactionStatus = TransactionStatus.Unauthorized;
            testTransaction.Status = transactionStatus;
            Assert.AreEqual(transactionStatus, testTransaction.Status);

            transactionStatus = TransactionStatus.Failed;
            testTransaction.Status = transactionStatus;
            Assert.AreEqual(transactionStatus, testTransaction.Status);

            transactionStatus = TransactionStatus.Aborted;
            testTransaction.Status = transactionStatus;
            Assert.AreEqual(transactionStatus, testTransaction.Status);
        }
    }
}
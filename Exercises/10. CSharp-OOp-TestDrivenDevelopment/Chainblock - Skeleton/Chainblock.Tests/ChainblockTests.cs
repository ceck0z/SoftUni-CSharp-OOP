using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private Chainblock chainblock;
        private Transaction mainTransaction;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
            this.mainTransaction = new Transaction(5, TransactionStatus.Successfull, "Gosho", "Pesho", 23.54m);
        }

        [Test]
        public void AddShouldIncreaseCountWithOne()
        {
            this.chainblock.Add(this.mainTransaction);

            Assert.That(1, Is.EqualTo(chainblock.Count));
        }

        [Test]
        public void CountShouldStartFromZero()
        {
            Assert.That(0, Is.EqualTo(this.chainblock.Count));
        }

        [Test]
        public void AddShouldThrowExceptionAndNotIncreaseCountWithOneWhenNullTransactionIsAdded()
        {
            Assert.Throws<ArgumentNullException>(() => this.chainblock.Add(null));

            Assert.That(0, Is.EqualTo(this.chainblock.Count));
        }

        [Test]
        public void AddShouldAddTheCorrectTransaction()
        {

            this.chainblock.Add(this.mainTransaction);

            foreach (var transaction in chainblock)
            {
                Assert.AreEqual(this.mainTransaction, transaction);
            }
        }

        [Test]
        public void ContainsByIdShouldReturnTrue()
        {
            this.chainblock.Add(this.mainTransaction);

            bool actual = this.chainblock.Contains(5);

            Assert.IsTrue(actual);
        }

        [Test]
        public void ContainsByIdShouldReturnFalse()
        {
            this.chainblock.Add(this.mainTransaction);

            bool actual = this.chainblock.Contains(9);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ContainsByIdWithNegativeValueShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.Contains(-25));
        }

        [Test]
        public void ContainsByTransactionShouldReturnTrue()
        {
            this.chainblock.Add(this.mainTransaction);

            bool actual = this.chainblock.Contains(this.mainTransaction);

            Assert.IsTrue(actual);
        }

        [Test]
        public void ContainsByTransactionShouldReturnFalse()
        {
            bool actual = this.chainblock.Contains(this.mainTransaction);

            Assert.IsFalse(actual);
        }

        [Test]
        public void ContainsByNullTransactionShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.chainblock.Contains(null));

        }

        [Test]
        public void ChangeTransactionShouldChangeTheStatusCorrectly()
        {
            this.chainblock.Add(this.mainTransaction);

            TransactionStatus expected = TransactionStatus.Failed;

            this.chainblock.ChangeTransactionStatus(5, expected);

            Assert.AreEqual(expected, this.mainTransaction.Status);

        }

        [Test]
        public void ChangeTransactionShouldThrowArgumentExceptionWithInvalidIdTransaction()
        {
            TransactionStatus expected = TransactionStatus.Aborted;

            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(5, expected));
        }

        [Test]
        public void RemoveTransactionByIdShouldRemoveCorrectTransactionAndKeepsTheOrder()
        {
            Transaction firstTransaction = new Transaction(1,TransactionStatus.Unauthorized,"Simo","Dimo",57.65m);
            Transaction secondTransaction = new Transaction(2,TransactionStatus.Unauthorized,"Simo","Dimo",57.65m);
            Transaction thirdTransaction = new Transaction(3,TransactionStatus.Unauthorized,"Simo","Dimo",57.65m);


            var expected = new List<Transaction>()
            {
                firstTransaction,
                thirdTransaction
            };

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            this.chainblock.RemoveTransactionById(2);

            int count = 0;

            foreach (var transaction in this.chainblock)
            {
                Assert.AreEqual(expected[count], transaction);
                count++;
            }
        }

        [Test]
        public void RemoveTransactionByIdWithNegativeShouldThrowInvalidOperationException()
        {          
            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(-5));
        }

        [Test]
        public void RemoveTransactionByIdWithInvalidIdShouldThrowInvalidOperationException()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            
            this.chainblock.Add(firstTransaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(2));
        }

        [Test]
        public void RemoveTransactionByIdShouldShouldDecreaseCountCorrectly()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);


            var expected = new List<Transaction>()
            {
                firstTransaction,
                thirdTransaction
            };

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            this.chainblock.RemoveTransactionById(2);

            Assert.That(2, Is.EqualTo(this.chainblock.Count));
        }

        [Test]
        public void GetByIdShouldReturnCorrectTransaction()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);
            
            ITransaction expected = secondTransaction;
            ITransaction actual = this.chainblock.GetById(2);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(7)]
        public void GetByIdWithInvalidIdShouldThrowException(int id)
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(id));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnCorrectTransactions()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successfull, "Simo", "Dimo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expected = new List<Transaction>()
            {
                thirdTransaction,
                firstTransaction
            };

            IEnumerable<ITransaction> actual = this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized);

            CollectionAssert.AreEqual(expected,actual);
        }

        [Test]
        public void GetByTransactionStatusWithoutNonExistingStatusShouldThrowInvalidOperationException()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successfull, "Simo", "Dimo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Simo", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);


            IEnumerable<ITransaction> actual = this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized);

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Failed));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusShouldReturnCorrectSenders(TransactionStatus status)
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<string> expected = new List<string>()
            {
                firstTransaction.From,
                secondTransaction.From,
                thirdTransaction.From
            };

            IEnumerable<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized);

            CollectionAssert.AreEqual(expected, actual);

        }

        [Test]
        public void GetAllSendersWithTransactionStatusWithoutAnyTransactionsShouldThrowInvalidOperationException(TransactionStatus status)
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock
                                                               .GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));

        }
        [Test]
        public void GetAllRecieversWithTransactionStatusShouldReturnCorrectSenders(TransactionStatus status)
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Successfull, "Simo", "Ivo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<string> expected = new List<string>()
            {
                firstTransaction.To,
                secondTransaction.To,
                thirdTransaction.To
            };

            IEnumerable<string> actual = this.chainblock.GetAllRecieversWithTransactionStatus(TransactionStatus.Unauthorized);

            CollectionAssert.AreEqual(expected, actual);

        }

        [Test]
        public void GetAllRecieversWithTransactionStatusWithoutAnyTransactionsShouldThrowInvalidOperationException(TransactionStatus status)
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllRecieversWithTransactionStatus(TransactionStatus.Unauthorized));

        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdShouldReturnTransactionsInCorrectOrder()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Ivo", 57.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {
                thirdTransaction,
                firstTransaction,
                secondTransaction
            };

            IEnumerable<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expected, actual); 
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdWithoutAnyTransactionsShouldReturnEmptyCollection()
        {
            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {};

            IEnumerable<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.AreEqual(expected, actual); 
        }

        [Test]
        public void GetBySenderOrderedByAmountThenByIdShouldReturnTransactionOrderdByAmountInDescending()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Ivo", 60.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {
                secondTransaction,
                firstTransaction
            };

            IEnumerable<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending("Simo");

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetBySenderOrderedByAmountThenByIdWithoutAnyMatchesShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending("Simo"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdShouldReturnTransactionOrderdByAmountInDescendingThenById()
        {
            Transaction firstTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Simo", "Dimo", 57.65m);
            Transaction secondTransaction = new Transaction(2, TransactionStatus.Unauthorized, "Simo", "Ivo", 60.65m);
            Transaction thirdTransaction = new Transaction(3, TransactionStatus.Unauthorized, "Misho", "Dimo", 59.65m);

            this.chainblock.Add(firstTransaction);
            this.chainblock.Add(secondTransaction);
            this.chainblock.Add(thirdTransaction);

            IEnumerable<ITransaction> expected = new List<ITransaction>()
            {
                thirdTransaction,
                firstTransaction
            };

            IEnumerable<ITransaction> actual = this.chainblock.GetByReceiverOrderedByAmountThenById("Dimo");

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdWithoutAnyTransactionsShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() =>this.chainblock.GetByReceiverOrderedByAmountThenById("Dimo"));
        }
    }
}

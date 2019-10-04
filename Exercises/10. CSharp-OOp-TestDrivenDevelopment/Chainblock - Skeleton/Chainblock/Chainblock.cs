using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Contracts;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new List<ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException("null is invalid Transaction");
            }

            this.transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new ArgumentException("null is invalid Transaction");
            }

            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (tx == null)
            {
                throw new ArgumentNullException("null is invalid Transaction");
            };

            return this.transactions.Contains(tx);
        }

        public bool Contains(int id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("Id must be positive");
            }

            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);
            
            return this.transactions.Contains(transaction);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .OrderByDescending(x => x.Amount)
                .ThenBy(y => y.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllRecieversWithTransactionStatus(TransactionStatus status)
        {
            var currentTransactions = this.transactions
                .Where(x => x.Status == status)
                .Select(y => y.To);

            if (!currentTransactions.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransactions;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var currentTransaction = this.transactions
                .Where(x => x.Status == status)
                .Select(x => x.From);

            if (!currentTransaction.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransaction;
        }

        public ITransaction GetById(int id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException("Id must be positive");
            }

            ITransaction transaction = this.transactions
                .FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException("Transaction not found");
            }

            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var currentTransaction = this.transactions
                .Where(x => x.To == receiver)
                .OrderByDescending(x => x.Amount)
                .ThenBy(x => x.Id); 

            if (!currentTransaction.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransaction;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var currentTransaction = this.transactions
                 .Where(x => x.From == sender)
                 .OrderByDescending(x => x.Amount);

            if (!currentTransaction.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var currentTransaction =  this.transactions
                .Where(x => x.Status == status)
                .OrderByDescending(x => x.Amount);

            if (!currentTransaction.Any())
            {
                throw new InvalidOperationException();
            }

            return currentTransaction;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            return this.transactions.GetEnumerator();
        }

        public void RemoveTransactionById(int id)
        {
            if (id < 0)
            {
                throw new InvalidOperationException();
            }
            
            ITransaction transaction = this.transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                throw new InvalidOperationException();
            }

            this.transactions.Remove(transaction);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

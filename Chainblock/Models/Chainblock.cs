using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chainblock.Models
{
    public class ChainBlock : IChainblock
    {
        public int Count => throw new NotImplementedException();

        public void Add(ITransaction tx)
        {
            throw new NotImplementedException();
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ITransaction tx)
        {
            throw new NotImplementedException();
        }

        public bool Contains(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllInLenghtRange(int lo, int hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByLenghtDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverAndLeghtRange(string receiver, int lo, int hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumLenghtDescending(string sender, int lenght)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByLenghtDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumLenght(TransactionStatus status, int lenght)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void RemoveTransactionById(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
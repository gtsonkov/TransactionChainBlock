using System.Collections.Generic;

namespace Chainblock.Contracts
{
    public interface IChainblock : IEnumerable<ITransaction>
    {
        int Count { get; }

        void Add(ITransaction tx);

        bool Contains(ITransaction tx);

        bool Contains(int id);

        void ChangeTransactionStatus(int id, TransactionStatus newStatus);

        void RemoveTransactionById(int id);

        ITransaction GetById(int id);

        IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status);

        IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status);

        IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status);

        IEnumerable<ITransaction> GetAllOrderedByLenghtDescendingThenById();

        IEnumerable<ITransaction> GetBySenderOrderedByLenghtDescending(string sender);

        IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver);

        IEnumerable<ITransaction> GetByTransactionStatusAndMaximumLenght(TransactionStatus status, int lenght);

        IEnumerable<ITransaction> GetBySenderAndMinimumLenghtDescending(string sender, int lenght);

        IEnumerable<ITransaction> GetByReceiverAndLeghtRange(string receiver, int lo, int hi);

        IEnumerable<ITransaction> GetAllInLenghtRange(int lo, int hi);
    }
}
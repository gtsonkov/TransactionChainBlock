using System;

namespace Chainblock.Contracts
{
    public interface ITransaction
    {
        int Id { get; set; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        string SequreString { get; set; }
    }
}
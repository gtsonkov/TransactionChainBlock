using Chainblock.Common;
using Chainblock.Contracts;
using System;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private const int MIN_ID_VALUE = 0;
        
        private int id;
        private string from;
        private string to;
        private string sequreString;
        private TransactionStatus ts;

        public Transaction(int id, string from, string to, string sequreString, TransactionStatus ts)
        {
            this.id = id;
            this.from = from;
            this.to = to;
            this.sequreString = sequreString;
            this.ts = ts;
        }

        public int Id 
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value <= MIN_ID_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidIDMessage);
                }

                this.id = value;
            } 
        }

        public TransactionStatus Status
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string From
        {
            get
            {
                return this.from;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSenderUsernameMessage);
                }

                this.from = value;
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSenderUsernameMessage);
                }

                this.to = value;
            }
        }

        public string SequreString
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
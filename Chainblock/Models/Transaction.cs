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
            this.Id = id;
            this.From = from;
            this.To = to;
            this.SequreString = sequreString;
            this.Status = ts;
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
                return this.ts;
            }

            set
            {
                this.ts = value;
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
                    throw new ArgumentException(ExceptionMessages.InvalidSenderRecieverUsernameMessage);
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
                    throw new ArgumentException(ExceptionMessages.InvalidSenderRecieverUsernameMessage);
                }

                this.to = value;
            }
        }

        public string SequreString
        {
            get
            {
                return this.sequreString;
            }

            set
            {
                if (value.Length != 48 && value.Length != 52 && value.Length != 64)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidSequreStringLenght);
                }

                this.sequreString = value;
            }
        }
    }
}
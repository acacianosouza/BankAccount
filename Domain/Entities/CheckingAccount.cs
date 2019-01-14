using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CheckingAccount : BaseEntity
    {
        [Column(Order = 1)]
        public long Number { get; set; }
        [Column(Order = 2, TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }
        [Column(Order = 3)]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual IEnumerable<Transaction> SentTransactions { get; set; }
        public virtual IEnumerable<Transaction> ReceivedTransactions { get; set; }
    }
}

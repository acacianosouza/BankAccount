using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid FromCheckingAccountId { get; set; }
        public Guid ToCheckingAccountId { get; set; }
        public decimal Amount { get; set; }


        [ForeignKey("FromCheckingAccountId")]
        public virtual CheckingAccount FromCheckingAccount { get; set; }

        [ForeignKey("ToCheckingAccountId")]
        public virtual CheckingAccount ToCheckingAccount { get; set; }
    }
}

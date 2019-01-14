using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Request
{
    public class TransferRequest
    {
        public string UserId{ get; set; }
        public long NumberFrom { get; set; }
        public long NumberTo { get; set; }
        public decimal Amount { get; set; }
    }
}

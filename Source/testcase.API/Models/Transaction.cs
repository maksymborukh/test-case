﻿namespace testcase.API.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
        public string Amount { get; set; }
    }
}

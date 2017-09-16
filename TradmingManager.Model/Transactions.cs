using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingManager.Model
{
    public enum TransactionType
    {
        Exchange =0,
        Margin = 1,
    }

    public enum OrderType
    {
        Market = 0,
        Limit = 1,
        Stop = 2,
        StopLimit = 3,
        TrailingStop =4,
        FillOrKill = 5
    }

    public enum Exchange
    {
        Bitfinex = 0,
        CoinBase = 1,
        OkCoin = 2,
        BitMex = 3
    }

    public enum Symbol
    {
        BTCUSD = 0,
        ETHUSD = 1,
        LTCUSD = 2,
        ZECUSD = 3,
    }

    public enum Status
    {
        New = 0,
        Filled = 1,
        PartialyFilled = 2,
        Deleted = 3,
    }
    public class Transactions
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        [Required]
        private string transactionId;
        [Required]
        private DateTime transactionTime;
        [Required]
        private TransactionType transactionType;
        [Required]
        private OrderType orderType;
        [Required]
        private Exchange exchange;
        [Required]
        private decimal price;
        [Required]
        private double amount;
        [Required]
        private double leverage;
        private decimal transcationFee;
        [Required]
        private Symbol symbol;
        [Required]
        private Status status;

        //foreign keys
        private string userId;
        private Users user;

        public int Id { get => id; set => id = value; }
        public string TransactionId { get => transactionId; set => transactionId = value; }
        public DateTime TransactionTime { get => transactionTime; set => transactionTime = value; }
        public TransactionType TransactionType { get => transactionType; set => transactionType = value; }
        public OrderType OrderType { get => orderType; set => orderType = value; }
        public decimal Price { get => price; set => price = value; }
        public double Amount { get => amount; set => amount = value; }
        public double Leverage { get => leverage; set => leverage = value; }
        public decimal TranscationFee { get => transcationFee; set => transcationFee = value; }
        public string UserId { get => userId; set => userId = value; }
        public Users User { get => user; set => user = value; }
        public Exchange Exchange { get => exchange; set => exchange = value; }
        public Symbol Symbol { get => symbol; set => symbol = value; }
        public Status Status { get => status; set => status = value; }
    }
}

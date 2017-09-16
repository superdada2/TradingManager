using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TradingManager.Model
{
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int userId;
        [Required]
        private string password;
        [Required]
        private string userName;
        private string email;

        private List<Transactions> transactions;

        public int UserId { get => userId; set => userId = value; }
        public string Password { get => password; set => password = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public List<Transactions> Transactions { get => transactions; set => transactions = value; }
    }
}

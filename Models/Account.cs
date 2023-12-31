using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class Account
{
    public int IdAccount { get; set; }

    public string? Account1 { get; set; }

    public decimal? Balance { get; set; }

    public int IdMoney { get; set; }

    public int IdUser { get; set; }

    public int? IdBank { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public virtual Bank? IdBankNavigation { get; set; }

    public virtual Money IdMoneyNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

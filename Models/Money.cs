using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class Money
{
    public int IdMoney { get; set; }

    public string Money1 { get; set; } = null!;

    public string? Symbol { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; } = new List<CountryCurrency>();
}

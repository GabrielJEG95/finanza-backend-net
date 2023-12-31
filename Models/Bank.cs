using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class Bank
{
    public int IdBank { get; set; }

    public string? Bank1 { get; set; }

    public int? IdCountry { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual Country? IdCountryNavigation { get; set; }
}

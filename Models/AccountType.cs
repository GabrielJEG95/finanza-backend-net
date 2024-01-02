using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class AccountType
{
    public int IdAccountType { get; set; }

    public string? AccountType1 { get; set; }

    public string? Icon { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}

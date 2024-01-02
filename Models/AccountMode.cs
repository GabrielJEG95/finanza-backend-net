using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class AccountMode
{
    public int IdAccountMode { get; set; }

    public string? AccountMode1 { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}

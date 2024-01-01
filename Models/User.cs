using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<UserInformation> UserInformations { get; set; } = new List<UserInformation>();
}

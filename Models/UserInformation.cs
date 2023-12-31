using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class UserInformation
{
    public int IdUserInfo { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? PhoneCode { get; set; }

    public int? PhoneNumber { get; set; }

    public DateTime? BirthDays { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}

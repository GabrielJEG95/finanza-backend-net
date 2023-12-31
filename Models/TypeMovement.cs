using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class TypeMovement
{
    public int IdTypeMovements { get; set; }

    public string TypeMovements { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }

    public bool? Status { get; set; }
}

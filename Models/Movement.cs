using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class Movement
{
    public int IdMovements { get; set; }

    public decimal? Movements { get; set; }

    public int? IdTypeMovements { get; set; }

    public int? IdAccount { get; set; }

    public DateTime? MovementDate { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public bool? Status { get; set; }
}

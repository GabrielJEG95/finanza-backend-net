using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class Country
{
    public int IdCountry { get; set; }

    public string? Country1 { get; set; }

    public string? Icon { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<Bank> Banks { get; set; } = new List<Bank>();

    public virtual ICollection<CountryCurrency> CountryCurrencies { get; set; } = new List<CountryCurrency>();
}

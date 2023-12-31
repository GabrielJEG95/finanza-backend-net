using System;
using System.Collections.Generic;

namespace finanza_backend_net.Models;

public partial class CountryCurrency
{
    public int IdCountryCurrency { get; set; }

    public int? IdCountry { get; set; }

    public int? IdMoney { get; set; }

    public DateTime RegistrationDate { get; set; }

    public bool? Status { get; set; }

    public virtual Country? IdCountryNavigation { get; set; }

    public virtual Money? IdMoneyNavigation { get; set; }
}

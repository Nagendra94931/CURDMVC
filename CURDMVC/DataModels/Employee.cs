using System;
using System.Collections.Generic;

namespace CURDMVC.DataModels;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public bool? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}

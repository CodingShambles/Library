﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Address : EntityBase
{

    public string? ZipCode { get; set; }

    public string? Street { get; set; }

    public string? Complement { get; set; }

    public int Number { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public Person? Resident;
}
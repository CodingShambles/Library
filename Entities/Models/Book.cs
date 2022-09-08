﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Book : EntityBase
{
    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Series { get; set; }

    public string? Publisher { get; set; }

    public string? PublishingYear { get; set; }
    
    public string? Isbn { get; set; }

    public string? Language { get; set; }

    public long? TotalVolumes { get; set; }

    public long? AvailableVolumes { get; set; }


    public List<Tags>? Tags { get; set; }

    public Person? Borrower;
}
using System;
using System.Collections.Generic;

namespace WebApi_Minimal1.Models;

public partial class Film
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public bool? InCinema { get; set; }

    public string? Genre { get; set; }

    public string? Director { get; set; }

    public string? ScriptLanguage { get; set; }
}

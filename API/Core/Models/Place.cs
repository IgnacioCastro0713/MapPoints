using System;
using System.Collections.Generic;

namespace API.Core.Models;

public partial class Place
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}
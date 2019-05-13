using System;
using System.Collections.Generic;

namespace MV.ApplicationService.ViewModels
{
  public class TMDBViewModel
  {
    public List<MovieViewModel> Results { get; set; }
    public int Page { get; set; }
    public int Total_Results { get; set; }
    public TMDBDateViewModel Dates { get; set; }
    public int Total_Pages { get; set; }
  }
}


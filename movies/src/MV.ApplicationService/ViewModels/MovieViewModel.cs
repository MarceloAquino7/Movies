using System;
using System.Collections.Generic;

namespace MV.ApplicationService.ViewModels
{
    public class MovieViewModel : BaseViewModel
    {
      public int VoteCount { get; set; }
      public bool IsVideo { get; set; }
      public double VoteAverage { get; set; }
      public string Title { get; set; }
      public double Popularity { get; set; }
      public string PosterPath { get; set; }
      public string OriginalLanguage { get; set; }
      public string OriginalTitle { get; set; }
      public List<int> GenreIds { get; set; }
      public string BackdropPath { get; set; }
      public bool IsAdult { get; set; }
      public string Overview { get; set; }
      public DateTime ReleaseDate { get; set; }
    }

    public class TMDQViewModel
    {
      public List<MovieViewModel> Results { get; set; }
      public int Page { get; set; }
      public int TotalResults { get; set; }
      public TMDQDateViewModel Dates { get; set; }
      public int TotalPages { get; set; }
    } 

    public class TMDQDateViewModel
    {
      public DateTime Maximum { get; set; }
      public DateTime Minimum { get; set; }
  }
}

using System;
using System.Collections.Generic;

namespace MV.Domain.Models
{
  public class Movie
  {
    public int VoteCount { get; set; }
    public int Id { get; set; }
    public bool IsVideo { get; set; }
    public double VoteAverage { get; set; }
    public string Title { get; set; }
    public double Popularity { get; set; }
    public string PosterPath { get; set; }
    public string OriginalLanguage  { get; set; }
    public string OriginalTitle { get; set; }
    public List<int> GenreIds { get; set; }
    public string BackdropPath { get; set; }
    public bool IsAdult { get; set; }
    public string Overview { get; set; }
    public DateTime ReleaseDate { get; set; }
  }
}
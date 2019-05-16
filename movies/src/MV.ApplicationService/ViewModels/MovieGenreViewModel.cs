using System;
using System.Collections.Generic;

namespace MV.ApplicationService.ViewModels
{
  public class MovieGenreViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class MovieGenre
  {
    public IEnumerable<MovieGenreViewModel> Genres { get; set; }
  }
}

using System;
using System.Collections.Generic;

namespace MV.ApplicationService.ViewModels
{
  public class MovieVideosViewModel
  {
    public string Id { get; set; }
    public string Iso_639_1 { get; set; }
    public string Iso_3166_1 { get; set; }
    public string Key { get; set; }
    public string Name { get; set; }
    public string Site { get; set; }
    public int Size { get; set; }
    public string Type { get; set; }
  }
}

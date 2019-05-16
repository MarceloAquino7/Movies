using System;
using System.Collections.Generic;

namespace MV.ApplicationService.ViewModels
{
  public class MovieCreditsViewModel
  {
    public int Id { get; set; }
    public List<Cast> Cast { get; set; }
    public List<Crew> Crew { get; set; }
  }

  public class Cast
  {
    public int Cast_Id { get; set; }
    public string Character { get; set; }
    public string Credit_Id { get; set; }
    public int Gender { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public string Profile_Path { get; set; }
  }

  public class Crew
  {
    public string Credit_Id { get; set; }
    public string Department { get; set; }
    public int Gender { get; set; }
    public int Id { get; set; }
    public string Job { get; set; }
    public string Name { get; set; }
    public string Profile_Path { get; set; }
  }
}

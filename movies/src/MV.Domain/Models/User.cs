using System;
using MV.Common.Repository.Contracts.Core.Entities;

namespace MV.Domain.Models
{
  public class User : DomainEntity
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime LastLogin { get; set; }
  }
}
using System;
using System.ComponentModel.DataAnnotations;
using MV.Common.Cqrs.Core.Commands;

namespace MV.Domain.Commands.User
{
  public class UpdateUserCommand : Command
  {
    public UpdateUserCommand(Guid id, string name, string email, DateTime lastLogin)
    {
      Id = id;
      Name = name;
      Email = email;
      LastLogin = lastLogin;
    }

    [Required] public Guid Id { get; protected set; }

    [Required]
    [MinLength(2)]
    [MaxLength(255)]
    public string Name { get; protected set; }

    [MinLength(2)] [MaxLength(255)] public string Email { get; protected set; }

    [Required] public DateTime LastLogin { get; protected set; }
  }
}
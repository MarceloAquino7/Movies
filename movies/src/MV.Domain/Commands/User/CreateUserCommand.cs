using System.ComponentModel.DataAnnotations;
using MV.Common.Cqrs.Core.Commands;

namespace MV.Domain.Commands.User
{
  public class CreateUserCommand : Command
  {
    public CreateUserCommand(
      string name, string email)
    {
      Name = name;
      Email = email;
    }

    [MinLength(2)]
    [MaxLength(255)]
    [Required]
    public string Name { get; protected set; }

    [MinLength(2)] [MaxLength(255)] public string Email { get; protected set; }
  }
}
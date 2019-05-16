using System;
using System.ComponentModel.DataAnnotations;
using MV.Common.Cqrs.Core.Commands;

namespace MV.Domain.Commands.User
{
  public class DeleteUserCommand : Command
  {
    public DeleteUserCommand(Guid id)
    {
      Id = id;
    }

    [Required] public Guid Id { get; protected set; }
  }
}
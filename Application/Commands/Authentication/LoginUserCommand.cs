using MediatR;
using VetTail.Domain.Entities;

namespace VetTail.Application.Commands.Authentication;

public record LoginUserCommand(string Username, string Password) : IRequest<User>;

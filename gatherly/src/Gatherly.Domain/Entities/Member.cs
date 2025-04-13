using Gatherly.Domain.Primitives;
using Gatherly.Domain.ValueObjects;

namespace Gatherly.Domain.Entities;

public sealed class Member(
    Guid id,
    FirstName firstName,
    string lastName,
    string email)
    : Entity(id)
{
    public FirstName FirstName { get; set; } = firstName;

    public string LastName { get; set; } = lastName;

    public string Email { get; set; } = email;
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserParser
    {
        Task<IReadOnlyCollection<User>> ParseUsersAsync(Stream rawJson, CancellationToken ct);
        Task<User> ParseUserAsync(Stream rawJson, CancellationToken ct);
    }
}

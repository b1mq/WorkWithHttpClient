using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPostParcer
    {
        Task<IReadOnlyCollection<Post>> GetAllAsync(Stream rawJson, CancellationToken ct);
        Task<Post> ParseAsync(Stream rawJson, CancellationToken ct);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPostJsonService
    {
        Task<IReadOnlyCollection<Post>> GetAllAsync( CancellationToken ct);
        Task<Post> GetByIdAsync(int id,CancellationToken ct);

    }
}

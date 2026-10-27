using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserJsonService
    {
        Task<IReadOnlyCollection<User>> GetAllAsync(CancellationToken ct);
        Task<User?> GetByIdAsync(int id,CancellationToken ct);
    }
}

﻿

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> Save();
    }
}

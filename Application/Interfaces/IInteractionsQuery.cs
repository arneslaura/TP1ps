﻿using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionsQuery
    {
        Task<List<Interactions>> ReadAllInteractionsByProjectId(Guid projectId);
    }
}

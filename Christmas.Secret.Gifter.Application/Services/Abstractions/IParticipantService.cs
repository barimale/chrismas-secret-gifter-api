﻿using Christmas.Secret.Gifter.Domain;
using Christmas.Secret.Gifter.Infrastructure.Repositories.Abstractions.Scoped;

namespace Christmas.Secret.Gifter.Application.Services.Abstractions
{
    public interface IParticipantService : IBaseRepositoryOuterScope<Participant, string>, IBaseRepositoryInnerScope<Participant, string>
    {
        Task<Participant[]> GetAllAsync(string eventId, CancellationToken? cancellationToken = null);
        Task<bool> CheckIfNameAlreadyExist(string eventId, string name, CancellationToken? cancellationToken = null);
        Task<bool> CheckIfEmailAlreadyExist(string eventId, string email, CancellationToken? cancellationToken = null);
        Task<bool> CheckIfNameAlreadyExistEditMode(string eventId, string participantId, string name, CancellationToken? cancellationToken = null);
        Task<bool> CheckIfEmailAlreadyExistEditMode(string eventId, string participantId, string email, CancellationToken? cancellationToken = null);
    }
}

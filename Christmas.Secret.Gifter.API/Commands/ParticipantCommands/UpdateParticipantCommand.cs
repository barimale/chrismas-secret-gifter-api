﻿using Christmas.Secret.Gifter.Domain;
using MediatR;

namespace Christmas.Secret.Gifter.API.Commands.ParticipantCommands
{
    public record UpdateParticipantCommand : IRequest<Participant>
    {
        public UpdateParticipantCommand(Participant participant)
        {
            Participant = participant;
        }

        public Participant Participant { get; private set; }
    }
}

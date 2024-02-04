﻿using Algorithm.ConstraintsPairing.Model.Responses;
using Christmas.Secret.Gifter.Domain;
using MediatR;

namespace Christmas.Secret.Gifter.API.Queries
{
    public record AddGiftEventCommand : IRequest<GiftEvent>
    {
        public AddGiftEventCommand(GiftEvent giftEvent)
        {
            GiftEvent = giftEvent;
        }

        public GiftEvent GiftEvent { get; private set; }
    }
}

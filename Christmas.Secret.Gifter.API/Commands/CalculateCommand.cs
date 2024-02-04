﻿using Algorithm.ConstraintsPairing.Model;
using Algorithm.ConstraintsPairing.Model.Requests;
using MediatR;

namespace Christmas.Secret.Gifter.API.Queries
{
    public record CalculateCommand : IRequest<OutputDataSummary>
    {
        public CalculateCommand(AlgorithmRequest request)
        {
            Request = request;
        }

        public AlgorithmRequest Request { get; private set; }
    }
}

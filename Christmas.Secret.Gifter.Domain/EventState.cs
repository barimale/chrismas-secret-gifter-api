﻿namespace Christmas.Secret.Gifter.Domain
{
    public enum EventState
    {
        CREATED = 0,
        READY_FOR_ANALYZE,
        ANALYZE_IN_PROGRESS,
        COMPLETED_SUCCESSFULLY,
        COMPLETED_FAILY,
        ABANDONED,
    }
}
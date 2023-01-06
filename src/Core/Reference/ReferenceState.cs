using System;

namespace Dondoko.Reference;

public struct ReferenceState
{
    public ReferenceState(
        Type type,
        int unusedCount,
        int usingCount,
        int acquiredCount,
        int releasedCount,
        int addedCount,
        int removedCount)
    {
        Type = type;
        UnusedCount = unusedCount;
        UsingCount = usingCount;
        AcquiredCount = acquiredCount;
        ReleasedCount = releasedCount;
        AddedCount = addedCount;
        RemovedCount = removedCount;
    }

    public Type Type { get; init; }

    public int UnusedCount { get; init; }

    public int UsingCount { get; init; }

    public int AcquiredCount { get; init; }

    public int ReleasedCount { get; init; }

    public int AddedCount { get; init; }

    public int RemovedCount { get; init; }
}
using System;

namespace Dondoko.Reference;

public struct ReferenceState
{
    public ReferenceState(Type type, int unusedReferenceCount, int usingReferenceCount, int acquiredReferenceCount, int releasedReferenceCount, int addedReferenceCount, int removedReferenceCount)
    {
        Type = type;
        UnusedReferenceCount = unusedReferenceCount;
        UsingReferenceCount = usingReferenceCount;
        AcquiredReferenceCount = acquiredReferenceCount;
        ReleasedReferenceCount = releasedReferenceCount;
        AddedReferenceCount = addedReferenceCount;
        RemovedReferenceCount = removedReferenceCount;
    }

    public Type Type { get; init; }

    public int UnusedReferenceCount { get; init; }

    public int UsingReferenceCount { get; init; }

    public int AcquiredReferenceCount { get; init; }

    public int ReleasedReferenceCount { get; init; }

    public int AddedReferenceCount { get; init; }

    public int RemovedReferenceCount { get; init; }
}
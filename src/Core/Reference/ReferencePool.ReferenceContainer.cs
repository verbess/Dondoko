using System;
using System.Collections.Generic;

namespace Dondoko.Reference;

public static partial class ReferencePool
{
    private sealed class ReferenceContainer
    {
        private readonly Queue<IReference> _references;

        public ReferenceContainer(Type type)
        {
            Type = type;
            _references = new Queue<IReference>();
            UsingReferenceCount = 0;
            AcquiredReferenceCount = 0;
            ReleasedReferenceCount = 0;
            AddedReferenceCount = 0;
            RemovedReferenceCount = 0;
        }

        public Type Type { get; init; }

        public int UnusedReferenceCount => _references.Count;

        public int UsingReferenceCount { get; private set; }

        public int AcquiredReferenceCount { get; private set; }

        public int ReleasedReferenceCount { get; private set; }

        public int AddedReferenceCount { get; private set; }

        public int RemovedReferenceCount { get; private set; }
    }
}
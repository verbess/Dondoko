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

        public T Acquire<T>() where T : class, IReference, new()
        {
            if (typeof(T) != Type)
            {
                throw new InvalidOperationException(
                    SR.InvalidOperation_TypeMismatch);
            }

            UsingReferenceCount++;
            AcquiredReferenceCount++;
            lock (_references)
            {
                if (_references.Count > 0)
                {
                    return (T)_references.Dequeue();
                }
            }

            AddedReferenceCount++;

            return new T();
        }

        public IReference Acquire()
        {
            UsingReferenceCount++;
            AcquiredReferenceCount++;
            lock (_references)
            {
                if (_references.Count > 0)
                {
                    return _references.Dequeue();
                }
            }

            AddedReferenceCount++;

            return Activator.CreateInstance(Type) as IReference
                ?? throw new InvalidOperationException(
                    SR.InvalidOperation_InstanceCreationFailed);
        }

        public void Release(IReference reference)
        {
            reference.Release();
            lock (_references)
            {
                if (EnableStrictMode && _references.Contains(reference))
                {
                    throw new InvalidOperationException(
                        SR.InvalidOperation_ReferenceReleased);
                }

                _references.Enqueue(reference);
            }

            ReleasedReferenceCount++;
            UsingReferenceCount--;
        }

        public void Add<T>(int count) where T : class, IReference, new()
        {
            if (typeof(T) != Type)
            {
                throw new InvalidOperationException(
                    SR.InvalidOperation_TypeMismatch);
            }

            lock (_references)
            {
                AddedReferenceCount += count;
                while (count > 0)
                {
                    _references.Enqueue(new T());
                    count--;
                }
            }
        }

        public void Add(int count)
        {
            lock (_references)
            {
                AddedReferenceCount += count;
                while (count > 0)
                {
                    IReference reference = Activator.CreateInstance(Type) as IReference ?? throw new InvalidOperationException(SR.InvalidOperation_InstanceCreationFailed);
                    _references.Enqueue(reference);
                    count--;
                }
            }
        }

        public void Remove(int count)
        {
            lock (_references)
            {
                count = Math.Min(count, _references.Count);
                RemovedReferenceCount += count;
                while (count > 0)
                {
                    _references.Dequeue();
                    count--;
                }
            }
        }

        public void RemoveAll()
        {
            lock (_references)
            {
                RemovedReferenceCount += _references.Count;
                _references.Clear();
            }
        }
    }
}
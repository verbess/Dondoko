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
            UsingCount = 0;
            AcquiredCount = 0;
            ReleasedCount = 0;
            AddedCount = 0;
            RemovedCount = 0;
        }

        public Type Type { get; init; }

        public int UnusedCount => _references.Count;

        public int UsingCount { get; private set; }

        public int AcquiredCount { get; private set; }

        public int ReleasedCount { get; private set; }

        public int AddedCount { get; private set; }

        public int RemovedCount { get; private set; }

        public T Acquire<T>() where T : class, IReference, new()
        {
            if (typeof(T) != Type)
            {
                throw new InvalidOperationException(
                    SR.InvalidOperation_TypeMismatch);
            }

            UsingCount++;
            AcquiredCount++;
            lock (_references)
            {
                if (_references.Count > 0)
                {
                    return (T)_references.Dequeue();
                }
            }

            AddedCount++;

            return new T();
        }

        public IReference Acquire()
        {
            UsingCount++;
            AcquiredCount++;
            lock (_references)
            {
                if (_references.Count > 0)
                {
                    return _references.Dequeue();
                }
            }

            AddedCount++;

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

            ReleasedCount++;
            UsingCount--;
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
                AddedCount += count;
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
                AddedCount += count;
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
                RemovedCount += count;
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
                RemovedCount += _references.Count;
                _references.Clear();
            }
        }
    }
}
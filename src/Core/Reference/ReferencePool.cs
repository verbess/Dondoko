using System;
using System.Collections.Generic;

namespace Dondoko.Reference;

public static partial class ReferencePool
{
    private static readonly Dictionary<Type, ReferenceContainer> s_containers;

    static ReferencePool()
    {
        s_containers = new Dictionary<Type, ReferenceContainer>();
        EnableStrictMode = false;
    }

    public static bool EnableStrictMode { get; set; }
}
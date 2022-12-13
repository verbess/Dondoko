using System;
using Dondoko.Reference;

namespace Dondoko;

public abstract class CoreEventArgs : EventArgs, IReference
{
    protected CoreEventArgs() : base() { }

    public abstract void Release();
}
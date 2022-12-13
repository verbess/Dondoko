using System;
using Dondoko.Reference;

namespace Dondoko;

public abstract class DondokoEventArgs : EventArgs, IReference
{
    protected DondokoEventArgs() : base() { }

    public abstract void Release();
}
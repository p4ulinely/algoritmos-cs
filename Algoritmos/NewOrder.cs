using System;
using Entities;

internal class NewOrder : Order, IComparable<NewOrder>
{
    private bool _isDisposed = false;

    public NewOrder(int id, DateTime creation)
    {
        Id = id;
        Creation = creation;
    }

    public int CompareTo(NewOrder obj)
    {
        if (this.Id < obj.Id)
            return -1;
        else if (this.Id > obj.Id)
            return 1;

        return 0;
    }
}
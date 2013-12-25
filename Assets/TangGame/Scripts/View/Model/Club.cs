using System;

namespace TangGame.View
{
public class Club
{
    public long Id
    {
        get;
        private set;
    }

    public Club (long id)
    {
        this.Id = id;
    }

    public bool Equils(Club other)
    {
        return this.Id == other.Id;
    }
}
}


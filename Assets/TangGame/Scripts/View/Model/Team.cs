using System;

namespace TangGame.View
{
public class Team
{
    public long Id
    {
        get;
        private set;
    }

    public Team (int id)
    {
        this.Id = id;
    }

    public bool Equils(Team other)
    {
        return this.Id == other.Id;
    }
}
}


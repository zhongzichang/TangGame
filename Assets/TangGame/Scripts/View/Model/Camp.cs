using System;

namespace TangGame.View
{
public class Camp
{
    public int Id
    {
        get;
        private set;
    }

    public Camp (int id)
    {
        this.Id = id;
    }


    public bool Equils(Camp other)
    {
        return this.Id == other.Id;
    }
}
}


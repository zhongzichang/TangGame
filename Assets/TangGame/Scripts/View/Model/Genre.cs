using System;

namespace TangGame.View
{
public class Genre
{
    public enum Name {KZ=1,XLK,QJL,NONE}

    private Name name;
    private bool updated = false;

    public Genre (Name name)
    {
        this.name = name;
        this.updated = false;
    }

    public Name GetName()
    {
        return name;
    }

    public bool isUpdated()
    {
        return updated;
    }

    public void To(Name name)
    {
        this.name = name;
        this.updated = true;
    }


}
}


using System;
using System.Collections;

namespace TangGame.View
{
public class Part
{
    public const int MOUNT_ID = 0;
    public const int PLAYER_ID = 1;
    public const int WEAPON_ID = 2;

    private static readonly string[] partNames = {"mount", "player","weapon" };

    private static Hashtable partMap = new Hashtable();
    public static Hashtable PartMap
    {
        get
        {
            if(partMap.Count == 0)
            {
                for(int i=0; i<partNames.Length; i++)
                {
                    partMap[partNames[i]] = i;
                }
            }
            return partMap;
        }
    }

    public int Id
    {
        get;
        private set;
    }

    public string Name
    {
        get;
        private set;
    }
    public bool Updated = false;

    private string itemName = null;
    public string ItemName
    {
        get
        {
            return itemName;
        }
        set
        {
            if(this.itemName != value)
            {
                this.itemName = value;
                this.Updated = true;
            }
        }
    }

    public Part (int id,string name)
    {
        this.Id = id;
        this.Name = name;
        this.Updated = false;
    }

    public static Part[] NewParts()
    {
        // init part
        Part[] parts = new Part[partNames.Length];
        for(int i=0; i<partNames.Length; i++)
        {
            parts[i] = new Part(i,partNames[i]);
        }
        return parts;
    }


}
}


/*
 * Created by Emacs
 * Author: zzc
 * Date: 2013/6/6
 */
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class ChangeAchievePush : Response
{
    public const string NAME = "changeAchieve_PUSH";

    public short showType;
    public long heroAchieveId;
    public List<Item> items = null;


    public ChangeAchievePush() : base(NAME)
    {

    }

    public static ChangeAchievePush Parse(MsgData data)
    {

        ChangeAchievePush push = new ChangeAchievePush();

        int index = 0;
        push.showType = data.GetShort(index++);
        push.heroAchieveId = (long)data.GetDouble(index++);
        if(index < data.Size)
        {
            List<Item> items = new List<Item>();
            while(index < data.Size)
            {
                MsgData itemData = data.GetMsgData(index++);
                Item item = new Item();
                item.type = itemData.GetShort(0);
                item.id = (long)itemData.GetDouble(1);
                item.num = itemData.GetInt(2);
                items.Add(item);
            }
            push.items = items;
        }
        return push;
    }
}
}
/*
 * Created by Emacs
 *
 * Author: zzc
 * Date: 2013/6/6
 */

using TangNet;

namespace TangGame.Net
{
public class BattleAwardPush : Response
{
    public const string NAME = "battleAward_PUSH";

    public long exp;
    public int addExp;
    public int prestige;
    public int flopPrestige;

    public BattleAwardPush() : base(NAME)
    {

    }

    public static BattleAwardPush Parse(MsgData data)
    {
        BattleAwardPush push = new BattleAwardPush();
        int index = 0;
        push.exp = (long) data.GetDouble(index++);
        push.addExp = data.GetInt(index++);
        push.prestige = data.GetInt(index++);
        push.flopPrestige = data.GetInt(index++);
        return push;
    }
}
}
/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// 家族成员职务发生变化
public class ChangeCasteArmsPush : Response
{
    public const string NAME = "changeCasteArms_PUSH";

    public long id;//玩家ID
    public string name;//玩家名称
    public int officer;//家族职务
    public int level;//玩家等级

    public long oldId;//前任领导人的ID，只存在更换领导人时
    public string oldName;//前任领导人的名称
    public int oldOfficer;//前任领导人的现任职务

    public ChangeCasteArmsPush() : base(NAME)
    {
    }

    public static ChangeCasteArmsPush Parse(MsgData data)
    {
        ChangeCasteArmsPush push = new ChangeCasteArmsPush();
        int index = 0;

        push.id = data.GetLong(index++);
        push.name = data.GetString(index++);
        push.officer = data.GetShort(index++);
        push.level = data.GetShort(index++);

        if(data.Size > index)
        {
            push.oldId = data.GetLong(index++);
            push.oldName = data.GetString(index++);
            push.oldOfficer = data.GetShort(index++);
        }
        return push;
    }
}
}
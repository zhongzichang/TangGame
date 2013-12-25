/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 16:02
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 验证Hero位置
/// </summary>
public class ValidateHeroPointsResult : Response
{
    public const string NAME = "validateHeroPoints_RESULT";

    public long heroId;
    public short x;
    public short y;
    public int hp;

    public ValidateHeroPointsResult() : base(NAME)
    {
    }

    public static ValidateHeroPointsResult Parse(MsgData data)
    {

        ValidateHeroPointsResult result = new ValidateHeroPointsResult();

        int index = 0;
        result.heroId = (long)data.GetDouble(index++);
        result.x = data.GetShort(index++);
        result.y = data.GetShort(index++);
        result.hp = data.GetInt(index++);

        return result;

    }
}
}

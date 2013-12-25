/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 15:20
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 领取别人掉落的物品
/// </summary>
public class OtherRansomResult : Response
{
    public const string NAME = "otherRansom_RESULT";

    public bool success;

    public OtherRansomResult() : base(NAME)
    {
    }

    public static OtherRansomResult Parse(MsgData data)
    {

        OtherRansomResult result = new OtherRansomResult();

        result.success = data.GetShort(0) == 1 ? true : false;

        return result;
    }
}

}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/21
 * Time: 18:25
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 技能使用内息值
/// </summary>
public class ChangeBreathResult : Response
{
    public const string NAME = "changeBreath_REsult";

    public short skillSort;
    public short num;

    public ChangeBreathResult() : base(NAME)
    {
    }

    public static ChangeBreathResult Parse(MsgData data)
    {

        ChangeBreathResult result = new ChangeBreathResult();

        int index = 0;
        result.skillSort = data.GetShort(index++);
        result.num = data.GetShort(index++);

        return result;

    }
}
}

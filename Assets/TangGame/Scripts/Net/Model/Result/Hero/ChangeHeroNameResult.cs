/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 16:17
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 修改英雄名字
/// </summary>
public class ChangeHeroNameResult : Response
{

    public const string NAME = "changeHeroName_RESULT";

    public string heroName;

    public ChangeHeroNameResult() : base(NAME)
    {
    }

    public static ChangeHeroNameResult Parse(MsgData data)
    {

        ChangeHeroNameResult result = new ChangeHeroNameResult();
        result.heroName = data.GetString(0);
        return result;
    }

}
}

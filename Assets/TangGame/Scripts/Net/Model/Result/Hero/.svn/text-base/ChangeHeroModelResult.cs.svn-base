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
/// 攻击模式改变返回
public class ChangeHeroModelResult : Response
{
    public const string NAME = "changeHeroModel_RESULT";

    public int mode;

    public ChangeHeroModelResult() : base(NAME)
    {
    }

    public static ChangeHeroModelResult Parse(MsgData data)
    {
        ChangeHeroModelResult result = new ChangeHeroModelResult();

        result.mode = data.GetShort(0);

        return result;

    }
}
}

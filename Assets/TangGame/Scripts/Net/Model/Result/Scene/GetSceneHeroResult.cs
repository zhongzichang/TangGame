/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/28
 * Time: 20:18
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of GetSceneHeroResult.
/// </summary>
[Response(NAME)]
public class GetSceneHeroResult : Response
{
    public const string NAME = "getSceneHero_RESULT";

    public HeroNew hero = null;


    public GetSceneHeroResult() : base(NAME)
    {
    }

    public static GetSceneHeroResult Parse(MsgData data)
    {

        GetSceneHeroResult result = new GetSceneHeroResult();

        HeroNew hero = HeroNew.ParseSceneData(data);

        result.hero = hero;

        return result;


    }
}
}

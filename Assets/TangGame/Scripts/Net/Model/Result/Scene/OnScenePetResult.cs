/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:34
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of OnScenePetResult.
/// </summary>
public class OnScenePetResult : Response
{
    public const string NAME = "onScenePet_PUSH";

    public List<ScenePet> pets;

    public OnScenePetResult() : base(NAME)
    {
    }
    public static OnScenePetResult Parse(MsgData data)
    {
        OnScenePetResult result = new OnScenePetResult();
        result.pets = new List<ScenePet>();
        for(int i=0; i<data.Size; i++)
        {

            result.pets.Add(ScenePet.Parse(data.GetMsgData(i)));

        }

        return result;
    }
}
}

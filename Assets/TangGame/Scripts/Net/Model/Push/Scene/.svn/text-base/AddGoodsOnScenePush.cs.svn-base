/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 2:03
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddGoodsOnScene.
/// </summary>
public class AddGoodsOnScenePush : Response
{

    public const string NAME = "addGoodsOnScene_PUSH";

    public List<SceneFlopGoods> goodsList;

    public AddGoodsOnScenePush() : base(NAME)
    {
    }

    public static AddGoodsOnScenePush Parse(MsgData data)
    {

        AddGoodsOnScenePush push = new AddGoodsOnScenePush();

        push.goodsList = new List<SceneFlopGoods>();
        for(int i=0; i<data.Size; i++)
        {
            push.goodsList.Add(SceneFlopGoods.Parse(data.GetMsgData(i)));
        }

        return push;

    }
}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/4/2
 * Time: 11:13
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ShopMsgResult.
/// </summary>
public class ShopMsgResult : Response
{
    public const string NAME = "shopMsg_RESULT";

    public int multiple;
    public List<int> goodsIds = new List<int>();

    public ShopMsgResult() : base(NAME)
    {
    }

    public static ShopMsgResult Parse(MsgData data)
    {
        ShopMsgResult result = new ShopMsgResult();
        int index = 0;
        result.multiple = data.GetShort(index++);
        while(index < data.Size)
        {
            result.goodsIds.Add(data.GetInt(index++));
        }
        return result;


    }
}
}

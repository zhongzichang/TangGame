using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class StorageDataResult : Response
{
    public const string NAME = "storageData_RESULT";

    public bool isSetKey;//1:有密码 2:无密码
    public int length;
    public int coin;
    public List<HeroGoods> list = new List<HeroGoods>();


    public StorageDataResult() : base(NAME)
    {
    }

    public static StorageDataResult Parse(MsgData data)
    {
        StorageDataResult result = new StorageDataResult();

        result.isSetKey = data.GetShort(0) == 1;
        result.length = data.GetShort(1);
        result.coin = data.GetInt(2);
        MsgData goodsData = data.GetMsgData(3);

        int index = 0;
        while(index < goodsData.Size)
        {
            result.list.Add(HeroGoods.Parse(goodsData.GetMsgData(index++)));
        }

        return result;
    }
}
}

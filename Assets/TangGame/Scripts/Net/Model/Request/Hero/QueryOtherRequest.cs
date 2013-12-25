using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class QueryOtherRequest : Request
{
    private short page;
    private short pageSize;
    public QueryOtherRequest(short page,short pageSize)
    {
        this.page=page;
        this.pageSize=pageSize;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_OTHER_QUERY_RANSOM_GOODS);


            data.PutShort(page);
            data.PutShort(pageSize);

            return data;
        }
    }
}
}

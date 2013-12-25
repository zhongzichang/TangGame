using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class SelectStarTaskRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(TaskProxy.SELECT_STAR_TASK);
        }
    }
}
}

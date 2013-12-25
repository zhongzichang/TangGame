/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 同意家族邀请
public class ArmsAgreeJoinRequest : Request
{

    public long playerId;//邀请者ID
    public int type;//1：同意，2：不同意
    public long armsId;//帮会ID

    public ArmsAgreeJoinRequest(long playerId, int type, long armsId)
    {
        this.playerId = playerId;
        this.type = type;
        this.armsId = armsId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_AGREE_JOIN);
            data.PutLong(playerId);
            data.PutShort(type);
            data.PutLong(armsId);
            return data;
        }
    }
}
}

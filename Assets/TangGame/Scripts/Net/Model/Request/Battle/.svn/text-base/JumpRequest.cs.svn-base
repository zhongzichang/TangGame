using System;
using TangNet;

namespace TangGame.Net
{
public class JumpRequest : Request
{
    private short x;
    private short y;
    public JumpRequest(short x,short y)
    {
        this.x=x;
        this.y=y;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(BattleProxy.S_JUMP);


            data.PutShort(x);
            data.PutShort(y);

            return data;
        }
    }
}
}

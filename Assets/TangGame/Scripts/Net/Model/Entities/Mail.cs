/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 22:56
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of Mail.
/// </summary>
public class Mail
{
    /** 邮件ID */
    public long id;
    /** 邮件类型(1:系统邮件 2:普通邮件 3:附件邮件) */
    public short type;
    /** 信件标题(最大长度30) */
    public string title;
    /** 信息(最大长度300) */
    public string msg;

    /** 游戏币 */
    public int coin;
    /** 代金券 */
    public int bindIngot;
    /** 元宝 */
    public int ingot;
    /** 附件 */
    public List<HeroGoods> goodsList = new List<HeroGoods>();

    public List<long> goodsIdList;

    /** 状态(-1.送件中 1.未读 2.已读) */
    public short state;
    /** 是已经拾取附件 */
    public bool isPickUpAffix;
    /** 送达时间 */
    public long time;

    /** 发件人Id */
    public long senderId;
    /** 发件人Name */
    public String senderName;
    /** 收件人ID */
    public long receiverId;
    /** 收件人Name */
    public string receiverName;

    public static Mail Parse(MsgData data)
    {
        Mail result = new Mail();
        int index = 0;
        result.id = data.GetLong(index++);
        result.type = data.GetShort(index++);
        result.title = data.GetString(index++);
        result.msg = data.GetString(index++);
        result.state = data.GetShort(index++);
        result.time = data.GetLong(index++);
        result.senderName = data.GetString(index++);

        result.coin = data.GetInt(index++);
        result.bindIngot = data.GetInt(index++);
        result.ingot = data.GetInt(index++);

        result.isPickUpAffix = data.GetShort(index++) == 1;

        MsgData goodsData = data.GetMsgData(index++);
        for(int i = 0; i < goodsData.Size; i++)
        {
            result.goodsList.Add(HeroGoods.Parse(goodsData.GetMsgData(i)));
        }

        return result;
    }
}
}

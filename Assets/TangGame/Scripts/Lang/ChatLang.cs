using UnityEngine;
using System.Collections;
using System.Xml;

/// 聊天文字
public class ChatLang
{
    ///世界
    public const string WORLD = "世界";
    ///附近
    public const string NEARBY = "附近";
    ///阵营
    public const string CAMP = "阵营";
    ///家族
    public const string CLAN = "仙盟";
    ///私聊
    public const string SECRET = "私聊";
    ///系统
    public const string SYSTEM = "系统";
    ///公告
    public const string NOTICE = "公告";
    ///队伍
    public const string TEAM = "队伍";
    ///GM
    public const string GM = "GM";
	
	public const string HAOJIAO = "号角";
    ///信息
    public const string INFO = "信息";

    ///聊天频道数据
    public static string[] CHANNEL_NAME = new string[] {"", WORLD, NEARBY, CAMP, CLAN, SECRET, SYSTEM, NOTICE, TEAM, GM};
    ///聊天频道数据简写
    public static string[] CHANNEL_NAME_S = new string[] {"", "世", "近", "阵", "族", "私", SYSTEM, NOTICE, "队", GM};
	
	public static string[] CHANNEL = new string[]{"世界频道","号角频道","世界频道","私聊频道","仙盟频道","队伍频道","系统频道"};
	public static string[] BUTTON_SHOW_CHANNEL = new string[]{"世界频道","号角频道","世界频道","私聊频道","仙盟频道","队伍频道","世界频道"};

    ///发送
    public const string SEND = "发送";

    ///世界频道
    public const string CHANEL_WORLD = "世界频道";
    ///队伍频道
    public const string CHANEL_TEAM = "队伍频道";
    ///阵营频道
    public const string CHANEL_CAMP = "阵营频道";
    ///附近频道
    public const string CHANEL_NEARBY = "附近频道";
    ///家族频道
    public const string CHANEL_CLAN = "家族频道";
    ///私聊频道
    public const string CHANEL_SECRET = "私聊频道";

    ///发  送
    public const string BUTTON_SEND = "发  送";
    ///世  界
    public const string BUTTON_WORLD = "世  界";
    ///队  伍
    public const string BUTTON_TEAM = "队  伍";
    ///附  近
    public const string BUTTON_NEARBY = "附  近";
    ///家  族
    public const string BUTTON_CLAN = "家  族";
    ///私  聊
    public const string BUTTON_SECRET = "私  聊";

}

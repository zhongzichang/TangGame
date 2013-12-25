using UnityEngine;
using System.Collections;
using System.Xml;

/// 文字
public class SocialLang
{
    ///好友
    public const string FRIEND = "好友";
    ///队伍
    public const string TEAM = "队伍";
    ///阵营
    public const string CAMP = "阵营";

    ///家族
    public const string CLAN = "家族";
    ///未加入家族
    public const string NOT_JOIN_CLAN = "未加入家族";
    ///加入家族
    public const string JOIN_CLAN = "加入家族";
    ///家族列表
    public const string CLAN_LIST = "家族列表";
    ///创建家族
    public const string CREATE_CLAN = "创建家族";
    ///创建
    public const string CREATE = "创建";
    ///同意
    public const string AGREE = "同意";
    ///全部同意
    public const string AGREE_ALL = "全部同意";
    ///忽略
    public const string IGNORE = "忽略";
    ///全部忽略
    public const string IGNORE_ALL = "全部忽略";
    ///拒绝
    public const string REFUSE = "拒绝";
    ///批准
    public const string APPROVE = "批准";
    ///踢出
    public const string KICK = "踢出";
    /// 家族邀请
    public const string CLAN_INVITE = "家族邀请";
    ///家族职位
    public static string[] CLAN_OFFICER = new string[] {"职位0", "职位1", "职位2", "职位3", "职位4", "职位5"};
    ///踢出家族
    public const string CLAN_KICK = "踢出家族";
    ///提升顺位
    public const string CLAN_UP = "提升顺位";
    ///降低顺位
    public const string CLAN_DOWN = "降低顺位";

    ///黑名单
    public const string BLACKLIST = "黑名单";
    ///仇人
    public const string ENEMY = "仇人";
    ///删除好友
    public const string DELETE_FRIEND = "删除好友";
    ///一键征友
    public const string ADD_FIREND = "一键征友";
    ///批量删除
    public const string BATCH_DELETE = "批量删除";
    ///自动回复
    public const string AUTO_REPLY = "自动回复";
    ///最近
    public const string LATELY = "最近";

    ///全部好友
    public const string ALL_FRIEND = "全部好友";
    ///三天内未登陆
    public const string NOT_LOGIN_3DAYS = "三天内未登陆";
    ///确定删除
    public const string OK_DELETE = "确定删除";
    ///取消删除
    public const string CANCEL_DELETE = "取消删除";


    ///仇人的称号
    public static string[] ENEMY_TITLE = new string[] {"偶有摩擦", "睚眦之怨", "冤家对头", "深仇大恨", "命中死敌", "不共戴天"};

    ///想成为您的好友，是否同意？
    public const string FRIEND_INFO_1 = "想成为您的好友，是否同意？";
    ///（{0}级）
    public const string FRIEND_INFO_2 = "（{0}级）";
    ///[00FF00]【{0}】[-]喂养了你的金蝉
    public const string FRIEND_INFO_3 = "[00FF00]【{0}】[-]喂养了你的金蝉";

    ///开启自动回复
    public const string FRIEND_INFO_4 = "开启自动回复";
    ///你好，我现在有事不在，一会儿联系你。
    public const string FRIEND_INFO_5 = "你好，我现在有事不在，一会儿联系你。";
    ///练级中，请勿打扰。
    public const string FRIEND_INFO_6 = "练级中，请勿打扰。";
    ///挂机中。。。
    public const string FRIEND_INFO_7 = "挂机中。。。";
    ///我去吃饭了，一会再联系
    public const string FRIEND_INFO_8 = "我去吃饭了，一会再联系。";
    ///请输入自定义内容
    public const string FRIEND_INFO_9 = "请输入自定义内容";
    ///拒绝陌生人窗口消息
    public const string FRIEND_INFO_10 = "拒绝陌生人窗口消息";
    //======================================队伍======================================
    /// 移交队长
    public const string TEAM_LEADER = "移交队长";
    /// 踢出队伍
    public const string TEAM_KICK = "踢出队伍";
    ///{0}邀请你加入队伍
    public const string TEAM_INVITE = "{0}邀请你加入队伍";
    ///{0}申请加入队伍
    public const string TEAM_APPLY = "{0}申请加入队伍";
    ///{0}离开队伍
    public const string TEAM_QUIT = "{0}离开队伍";
    ///队伍成员：
    public const string TEAM_MEMBER = "队伍成员：";
    ///离开队伍
    public const string QUIT_TEAM="离开";
    ///提升队长
    public const string TEAMLEADER="转让";
    ///请离队伍
    public const string OUSTERTEAM="请离";
    ///自动接受队伍要求
    public const string AUTOACCEPTINVITAT="自动接受队伍邀请";
    ///分配方式：
    public const string ALLOCATION="分配方式：";
    ///顺序拾取
    public const string ORDERPICKUP="顺序拾取";
    ///自由拾取
    public const string FREEPICKUP="自由拾取";
    ///创建队伍
    public const string CREATE_TEAM="创建队伍";
    /// <summary>
    /// 隐藏队伍面板
    /// </summary>
    public const string HIDE_TEAM="隐藏";
    public const string SHOW_TEAM="显示";

    ///{0}请求与你成为好友
    public const string FRIEND_INVITE="{0}请求与你成为好友";
    ///{0}拒绝了你的好友邀请
    public const string FRIEND_REJECT="{0}拒绝了你的好友邀请";
    ///{0}和你已断绝好友关系
    public const string FRIEND_DISENGAGE="{0}和你已断绝好友关系";
    ///你和{0}已成为好友
    public const string BECOME_FRIENDS="你和{0}已成为好友";

    ///"请输入家族名称！"
    public const string CLAN_MESSAGE_1="请输入家族名称！";
    ///"请输入2-5个字符的名称！"
    public const string CLAN_MESSAGE_2="请输入2-5个字符的名称！";
    ///"请输入合法的字符！"
    public const string CLAN_MESSAGE_3="请输入合法的字符！";
    ///"家族【{0}】创建成功！"
    public const string CLAN_MESSAGE_4="家族【{0}】创建成功！";
    ///已将【{0}】踢出家族
    public const string CLAN_MESSAGE_5="已将【{0}】踢出家族";
    ///确定将【{0}】踢出家族？
    public const string CLAN_MESSAGE_6="确定将【{0}】踢出家族？";
    ///玩家【{0}】离开家族。
    public const string CLAN_MESSAGE_7="玩家【{0}】离开家族。";
    ///玩家【{0}】被踢出家族。
    public const string CLAN_MESSAGE_8="玩家【{0}】被踢出家族。";
    ///玩家【{0}】加入家族。
    public const string CLAN_MESSAGE_9="玩家【{0}】加入家族。";
    ///玩家【{0}】的职位更改为{1}。
    public const string CLAN_MESSAGE_10="玩家【{0}】的职位更改为{1}。";
    ///{0}邀请你加入帮会
    public const string CLAN_MESSAGE_11 = "{0}邀请你加入【{1}】家族";
    ///家族邀请已发出，等待对方响应
    public const string CLAN_MESSAGE_12 = "家族邀请已发出，等待对方响应";
    ///加入家族申请已经发出，请等待批准！
    public const string CLAN_MESSAGE_13 = "加入家族申请已经发出，请等待批准！";

}

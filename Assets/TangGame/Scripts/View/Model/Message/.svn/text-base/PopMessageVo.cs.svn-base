
namespace TangGame.View
{
/// 弹出信息类，用于提示组队邀请，交易等
public class PopMessageVo
{
    /// 队伍邀请类型
    public const int TEAM_INVITE = 1;
    /// 队伍申请类型
    public const int TEAM_APPLY = 2;

    /// 交易邀请类型
    public const int TRADE_INVITE = 3;
    /// 好友邀请类型
    public const int FRIEND_INVITE = 4;

    /// 帮会邀请类型
    public const int CLAN_INVITE = 5;
    /// 煮酒烤火邀请类型
    public const int WINE_INVITE = 6;

    /// 类型，标示为是否为组队，交易等
    public int type;
    /// 该ID为多变ID，组队为队伍ID，交易为玩家ID
    public long id;
    /// 名称，根据类型而定，可能是队伍邀请的玩家名称，好友邀请的玩家名称
    public string name;

    /// 用于家族邀请的，家族ID
    public long clanId;
    /// 用于家族邀请的，家族名称
    public string clanName;

}
}
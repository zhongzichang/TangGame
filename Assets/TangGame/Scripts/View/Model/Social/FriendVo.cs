using System.Collections;
using TGN = TangGame.Net;
namespace TangGame.View
{
public class FriendVo
{
    /// 好友
    public const int FRIEND = 1;
    /// 仇人
    public const int ENEMY = 2;
    /// 黑名单
    public const int BLACK = 3;
    /// 师徒
    public const int MASTER = 4;
    /// 夫妻
    public const int COUPLES = 5;
    /// 结拜
    public const int SWORN = 6;
    ///被击杀名单
    public const int KILL_INFO = 7;
    ///最近
    public const int RECENTS = 8;

    ///关系编号,与两个人都无关*
    public long friendTypeId;

    /// 好友对象的ID
    public long id;
    /// 好友类型，比如好友，夫妻等
    public int type;
    /// 添加好友玩家的名称
    public string name;
    ///添加好友玩家的等级*
    public int level;
    ///性别
    public int sex = 1;
    ///职业
    public int job = 2;

    ///关系值，比如亲密度，仇恨值*
    public int relation;
    ///关系称号，比如师徒，夫妻*
    public string title = "";
    ///添加时间*
    public long time;
    /// 添加好友玩家的在线情况
    public int online;
    /// 玩家阵营
    public int camp;
    ///是否可以喂食
    public bool isCanFeed;
    ///登录时间
    public long loginTime;

    ///用于显示时选中处理
    public bool selected = false;

    ///是否在线
    public bool IsOnline()
    {
        return online == 1;
    }

    public void Update(FriendVo friend)
    {
        this.friendTypeId = friend.friendTypeId;
        this.id = friend.id;
        this.type = friend.type;
        this.name = friend.name;
        this.relation = friend.relation;
        this.level = friend.level;
        this.time = friend.time;
        this.online = friend.online;
        this.camp = friend.camp;
    }

    public void Update(TGN.Friends friend)
    {
        this.friendTypeId=friend.id;
        this.id=friend.heroId;
        this.type=friend.type;
        this.name=friend.heroName;
        this.relation=friend.val;
        this.level=friend.heroLv;
        this.time=friend.createTime;
        this.online=friend.heroOnLine;
        this.camp=friend.heroCamp;
    }

    ///克隆一个
    public FriendVo Clone()
    {
        FriendVo result = new FriendVo();
        result.Update(this);
        return result;
    }


    public static FriendVo FromData(TGN.Friends friend)
    {
        FriendVo result=new FriendVo();
        result.Update(friend);
        return result;
    }
}
}







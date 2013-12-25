using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TangGame.View;

namespace TangGame
{
/// 好友相关数据
public class FriendCache
{

    ///更新标示
    public static int updated = 0;
    ///好友列表
    public static ArrayList friends = new ArrayList();
    ///仇人列表
    public static ArrayList enemys = new ArrayList();
    ///黑名单列表
    public static ArrayList blacks = new ArrayList();
    ///最近列表
    public static ArrayList latelys = new ArrayList();

    ///好友申请更新标示
    public static int applyUpdated = 0;
    ///好友申请列表
    public static ArrayList applys = new ArrayList();
    ///喂养记录更新标示
    public static int feedUpdated = 0;
    ///喂养记录
    public static ArrayList toadFeed = new ArrayList();
    ///征友数据更新标示
    public static int partnerUpdated = 0;
    ///征友数据
    public static ArrayList partners = new ArrayList();

    /// 获取列表
    public static ArrayList GetFriendList(int type)
    {
        switch(type)
        {
        case FriendVo.FRIEND:
            return friends;
        case FriendVo.ENEMY:
            return enemys;
        case FriendVo.BLACK:
            return blacks;
        case FriendVo.RECENTS:
            return latelys;
        }
        return null;
    }

    //清空好友列表
    public static void ClearAll()
    {
        friends.Clear();
        enemys.Clear();
        blacks.Clear();
        latelys.Clear();
    }

    /// 是否是好友，只判断friends列表
    public static bool IsFriend(long id)
    {
        foreach(FriendVo friend in friends)
        {
            if(friend.id == id)
            {
                return true;
            }
        }
        return false;
    }

    //添加一个好友
    public static void AddFriend(FriendVo friend)
    {
        ArrayList list = GetFriendList(friend.type);
        if(list == null)
        {
            return;
        }
        list.Add(friend);
    }

    //修改一个好友
    public static void ChangeFriend(FriendVo friend)
    {
        ArrayList list = GetFriendList(friend.type);
        if(list == null)
        {
            return;
        }
        foreach(FriendVo temp in list)
        {
            if(temp.id == friend.id)
            {
                temp.Update(friend);
            }
        }
    }

    //删除玩家
    public static void RemoveFriend(FriendVo friend)
    {
        ArrayList list = GetFriendList(friend.type);
        if(list == null)
        {
            return;
        }
        int count = 0;
        foreach(FriendVo temp in list)
        {
            if(temp.id == friend.id)
            {
                list.RemoveAt(count);
                break;
            }
            count++;
        }
    }

    //根据类型，关系ID获取某个人
    public static FriendVo GetFriend(int type, long friendTypeId)
    {
        ArrayList list = GetFriendList(type);
        if(list == null)
        {
            return null;
        }
        foreach(FriendVo friend in list)
        {
            if(friend.friendTypeId.Equals(friendTypeId))
            {
                return friend;
            }
        }
        return null;
    }


    //根据获取某个人
    public static FriendVo GetFriend(long id)
    {
        foreach(FriendVo friend in friends)
        {
            if(friend.id.Equals(id))
            {
                return friend;
            }
        }
        foreach(FriendVo friend in enemys)
        {
            if(friend.id.Equals(id))
            {
                return friend;
            }
        }
        foreach(FriendVo friend in blacks)
        {
            if(friend.id.Equals(id))
            {
                return friend;
            }
        }
        foreach(FriendVo friend in latelys)
        {
            if(friend.id.Equals(id))
            {
                return friend;
            }
        }
        return null;
    }





}
}
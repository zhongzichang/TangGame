using dthbs;
using System;
using UnityEngine;

namespace TangGame.Net
{
public class Team
{
    /// 队伍ID
    public long teamId;
    /// 队伍队长ID
    public long leaderId;
    /// 队伍成员集合
    public TeamMember[] memberArray;
    /// 队伍拾取方式(1:随机拾取 2:顺序拾取 3:自由拾取)
    public int pickType;
    /// 顺序拾取下标
    public int pickIndex;

}
}
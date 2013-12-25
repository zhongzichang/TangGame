/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class ArmsProxy
{

    public const int TYPE = 0x0900;

    /// 查看帮会列表
    public const int S_ARMS_LIST = TYPE + 0x0001;
    /// 创建帮会
    public const int S_ARMS_CREATE = TYPE + 0x0002;
    /// 获取帮会信息
    public const int S_ARMS_MESSAGE = TYPE + 0x0003;
    /// 改成成员阶级
    public const int S_CHANGE_CASTE = TYPE + 0x0005;
    /// 更改公告
    public const int S_UPDATE_DESCRIBE = TYPE + 0x0006;
    /// 成员列表
    public const int S_MEMBER_LIST = TYPE + 0x0007;
    /// 邀请加入
    public const int S_INVITE_JOIN = TYPE + 0x0008;
    /// 同意加入
    public const int S_AGREE_JOIN = TYPE + 0x0009;
    /// 申请加入
    public const int S_ASK_JOIN = TYPE + 0x0010;
    /// 批准加入
    public const int S_CONFIRM_JOIN = TYPE + 0x0011;
    /// 踢出成员
    public const int S_DEL_MEMBER = TYPE + 0x0013;
    /// 退出帮会
    public const int S_GO_AWAY = TYPE + 0x0014;
    /// 查看申请列表
    public const int S_APPLY_LIST = TYPE + 0x0015;
    /// 获取帮会仓库
    public const int S_ARMS_STORAGE = TYPE + 0x0017;
    /// 帮主配分仓库资源给指定帮会成员
    public const int S_ARMS_RESOURCE_ALLOT = TYPE + 0x0018;
    /// 设置固定资源分配
    public const int S_ARMS_UPDATE_ARMS_ALLOT = TYPE + 0x0019;
    /// 领取资源
    public const int S_ARMS_FASTENRESOURCE_GET = TYPE + 0x0020;
    /// 查看阶级分配
    public const int S_ARMS_ALLOT_SELECT = TYPE + 0x0021;
    /// 领地每日产出
    public const int S_MANOR_OUT = TYPE + 0x0022;
    /// 帮主领取仓库资源
    public const int S_ARMS_LEADER_GET = TYPE + 0x0023;
    /// 帮会救援
    public const int S_ARMS_RESCUE_FLY = TYPE + 0x0024;
    /// 帮派搜索
    public const int S_ARMS_SEEK = TYPE + 0x0025;
    /// 清除申请列表
    public const int S_CLEAR_APPLY_LIST = TYPE + 0x0026;
    /// 修改帮会名称
    public const int CHANGE_ARMS_NAME = TYPE + 0x0027;
    /// 获取帮派活动状态
    public const int ARMS_ACTIVE = TYPE + 0x0028;
    /// 进入喂猪副本
    public const int INTO_PIG_FB = TYPE + 0x0029;
    /// 开起喂猪副本
    public const int START_PIG_FB = TYPE + 0x002A;
    /// 喂猪
    public const int FEED_PIG = TYPE + 0x002B;
    /// 帮派历练开启
    public const int ARMS_ASHRAM_START = TYPE + 0x002C;
    /// 帮派历练进入
    public const int ARMS_ASHRAM_INTO = TYPE + 0x002D;
    /// 发布帮会任务
    public const int ISSUE_ARMS_TASK = TYPE + 0x002E;

    public const int ARMS_ASHRAM_REWARD = TYPE + 0x0030;

    public const int PIG_FB_REWARD = TYPE + 0x0031;

}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/5
 * Time: 16:38
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of TaskProxy.
/// </summary>
public class TaskProxy
{
    public const short TYPE = 0x0900;

    /// 获取已接任务列表
    public const short S_TASK_GET_KNOW = TYPE + 0x0001;
    /// 获取可接任务列表
    public const short S_TASK_GET_UNKNOW = TYPE + 0x0002;
    /// 接任务
    public const short S_TASK_ADD_KNOW = TYPE + 0x0003;
    /// 完成任务
    public const short S_TASK_FINISH = TYPE + 0x0005;
    /// 放弃任务
    public const short S_TASK_DEL_KNOW = TYPE + 0x0006;
    /// NPC任务提示
    public const short S_TASK_UPDATE_NPC = TYPE + 0x0007;
    /// 重新挑战任务
    public const short S_TASK_REPEAT = TYPE + 0x0009;
    /// 查看任务状态(获取任务弹出面板)
    public const short S_GET_TASK = TYPE + 0x000a;
    /// 播放动画完成任务
    public const short S_TASK_CARTOON = TYPE + 0x0011;
    /// 条件传送
    public const short S_TASK_FLY = TYPE + 0x0012;
    /// 接受循环任务
    public const short S_GET_LOOP_TASK = TYPE + 0x0013;
    /// 直接完成任务
    public const short MIA_COMPLETE = TYPE + 0x0014;
    /// 获取星级任务
    public const short SELECT_STAR_TASK = TYPE + 0x0015;
    /// 刷新任务星级
    public const short REFRESH_STAR_TASK = TYPE + 0x0016;
    /// 领取任务福利
    public const short TASK_WELFARE_REWARD = TYPE + 0x0017;


//		public static void SelectStarTask(){
//			NetData data = new NetData(SELECT_STAR_TASK);
//			Common.gameClient.SendMessage(data);
//		}
//
//		public static void RefreshStarTask(short type, long taskId, short refreshType, short expenseType, short level){
//			NetData data = new NetData(REFRESH_STAR_TASK);
//			data.PutShort(type);
//			data.PutLong(taskId);
//			data.PutShort(refreshType);
//			data.PutShort(expenseType);
//			data.PutShort(level);
//			Common.gameClient.SendMessage(data);
//		}
}
}

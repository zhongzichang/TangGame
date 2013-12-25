/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/20
 * 时间: 14:30
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class FriendProxy
{
    public const short TYPE = 0x2000;

    /** 请求添加好友 */
    public const short S_FRIEND_ASK = TYPE + 0x0001;
    /** 同意添加好友 */
    public const short S_FRIEND_AGREE = TYPE + 0x0002;
    /** 添加黑名单 */
    public const short S_FRIEND_ADD_HATE = TYPE + 0x0003;
    /** 解除关系 */
    public const short S_FRIEND_DEL = TYPE + 0x0004;
    /** 请求好友列表 */
    public const short S_FRIEND_LIST = TYPE + 0x0005;

    /**删除好友/黑名单/仇人*/
//		public static void FriendDelete(int type,long friendTypeId){
//			NetData data=new NetData(S_FRIEND_DEL);
//			data.PutShort(type);
//			data.PutLong(friendTypeId);
//			Common.gameClient.SendMessage(data);
//		}
//		/**添加仇人黑名单*/
//		public static void FriendBlack(int type,string name){
//			NetData data=new NetData(S_FRIEND_ADD_HATE);
//			data.PutShort(type);
//			data.PutString(name);
//			Common.gameClient.SendMessage(data);
//		}
}
}
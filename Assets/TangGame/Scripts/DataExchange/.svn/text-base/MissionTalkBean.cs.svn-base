///xbhuang
///小伙伴们，来点乐子吧！
using UnityEngine;
using System.Collections;
namespace TangGame{
	public class MissionTalkBean{
		/// <summary>
		/// 点击的NPC的ID
		/// </summary>
		public long npcId;
		/// <summary>
		/// 点击NPC对应的任务ID
		/// </summary>
		public string note;
    /// <summary>
    /// 任务配置ID
    /// </summary>
    public int taskId;
		public string NAME;
		/// <summary>
		/// 传递进来的参数对象
		/// </summary>
		public object obj;
		public CallBack callback;
		public CallbackNotification callbackWithObject;
		public delegate void CallBack();
		public delegate void CallbackNotification(string NAME, object obj);
		
		public MissionTalkBean(long npcId, string note){
			this.npcId = npcId;
			this.note = note;
		}
		public MissionTalkBean(long npcId, string note, CallBack callback){
			this.npcId = npcId;
			this.note = note;
			this.callback = callback;
		}
    public MissionTalkBean (long npcId, string note, int taskId){
      this.npcId = npcId;
      this.note = note;
      this.taskId = taskId;
    }
		public MissionTalkBean(long npcId, string note, CallbackNotification callbackWithObject,string NAME,object obj){
			this.npcId = npcId;
			this.note = note;
			this.callbackWithObject = callbackWithObject;
			this.NAME = NAME;
			this.obj = obj;
		}
	}
}
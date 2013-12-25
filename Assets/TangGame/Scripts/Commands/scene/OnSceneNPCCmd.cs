///xbhuang
///小伙伴们，来点乐子吧！
///2013/11/13
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN=TangGame.Net;
namespace TangGame{
	/// <summary>
	/// 处理装载场景中的NPC
	/// </summary>
	public class OnSceneNPCCmd : SimpleCommand {
		public static string NAME = TGN.OnSceneNPCResult.NAME;
		public override void Execute(INotification notification)
		{
			TGN.OnSceneNPCResult result = notification.Body as TGN.OnSceneNPCResult;
			TangScene.Actor actor;
			foreach(TGN.Npc npc in result.npcs){
				ActorCache.AddOrUpdateActor(npc.id, npc);
				actor = ActorCache.GetActor(npc.id);
				if(actor != null){
					TangScene.TS.ActorEnter(actor);
				}
			}
      // 判断主动寻路是否打开
      if (AutoNavCache.isActive) {
        // 开始自动寻路
        AutoNavHelper.Start ();
      }
		}
	}
}
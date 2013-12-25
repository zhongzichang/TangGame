/// <summary>
///
/// xbhuang
/// 2013/10/23
///
/// Date: 2013/11/23
/// Edit:zzc
///
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangGame
{
	/// <summary>
	/// 添加主角英雄到场景
	/// </summary>
	public class LeadingActorEnterSceneCmd : SimpleCommand
	{
    
		public const string NAME = "TG_LEADING_ACTOR_ENTER_SCENE";

		public override void Execute (PureMVC.Interfaces.INotification notification)
		{
      
			TangScene.Actor leadingActor = ActorCache.GetActor (ActorCache.leadingActorId);
			if (leadingActor != null) {

				// 进入场景
				TangScene.TS.ActorEnter (leadingActor);

				// 控制主角
				TangScene.TS.SwitchControlledActor (leadingActor.id);



			}
		}
	}
}
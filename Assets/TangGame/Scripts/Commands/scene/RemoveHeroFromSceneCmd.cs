using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
/// <summary>
/// Remove hero from scene cmd.
/// </summary>
public class RemoveHeroFromSceneCmd : SimpleCommand {
	public static string NAME = TGN.RemoveHeroFromScenePush.NAME;
	public override void Execute (INotification notification)
	{
		TGN.RemoveHeroFromScenePush push = notification.Body as TGN.RemoveHeroFromScenePush;
		TS.TS.ActorExit(push.heroId);
	}
}

using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
/// <summary>
/// Remove npc from scene cmd.
/// </summary>
public class RemoveNpcFromSceneCmd : SimpleCommand {
	public static string NAME = TGN.RemoveNpcFromScenePush.NAME;
	public override void Execute (INotification notification)
	{
		TGN.RemoveNpcFromScenePush push = notification as TGN.RemoveNpcFromScenePush;
		TS.TS.ActorExit(push.roleId);
	}
}

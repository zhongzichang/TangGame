///xbhuang
/// <summary>
/// 2013/11/8
/// </summary>
///小伙伴们，来点乐子吧！
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using zyhd.TEffect;

namespace TangGame
{
	public class HeroPointCmd : SimpleCommand
	{
		public static string NAME = TGN.HeroPointPush.NAME;
		public static GameObject myServerPointCube;
		public override void Execute (INotification notification)
		{
			TGN.HeroPointPush push = notification.Body as TGN.HeroPointPush;
			if(myServerPointCube == null){
				 myServerPointCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				myServerPointCube.transform.localScale = Vector3.one * 5;
				myServerPointCube.renderer.material.color = Color.red;
			}
			myServerPointCube.transform.position = TangUtils.GridUtil.PointToVector3(push.x, push.y);
		}
	}
}
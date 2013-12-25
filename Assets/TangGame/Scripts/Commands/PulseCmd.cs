using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN=TangGame.Net;
namespace TangGame{
	/// <summary>
	/// 心跳处理命令
	/// </summary>
	public class PulseCmd : SimpleCommand {
		public static string NAME = TGN.PulsePush.NAME;
		public override void Execute(INotification notification)
		{
			//返回心跳
			TangNet.TN.Send(new TGN.PulseHandlerRequest());
		}
	}
}
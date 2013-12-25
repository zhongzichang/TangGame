using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using nh.ui.cache;
namespace nh.ui.chat
{
	public class ChatTopRightPanelMediator : Mediator{
		public new const string NAME = "ChatTopRightPanelMediator";
		public const string CLOSE_CHAT = "Close_Chat";
		private List<string> interests = new List<string> ();
	    ChatTopRightPanel panel;
	    public ChatTopRightPanelMediator(ChatTopRightPanel viewComponent) : base(NAME)
	    {
	        panel=viewComponent;
	
	    }
	    
		public override IList<string> ListNotificationInterests(){
			if (interests.Count == 0) {
				interests.Add (CLOSE_CHAT);
		    }
			return interests;
		}
	    
	    public override void HandleNotification (INotification notification){
//			Debug.Log("~~~~~~~~~~~~close chat~~~~~~~~~~~~~~");
			if (CLOSE_CHAT.Equals(notification.Name)){
	    		if(NGUITools.GetActive(panel.gameObject))
				PanelCache.IController.OpentUI(UIWindow.UIMAIN);
				
			}
    	}
	}
}


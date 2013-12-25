using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TangGame.Net;

using TN = TangNet;

namespace TangGame.Home
{
	public class HomeMediator : Mediator
	{
		public new const string NAME = "HomeMediator";

    private delegate void Handle(INotification notification);
    private Dictionary<string, Handle> handleTable = new Dictionary<string, Handle>();
   
		public HomeMediator (GameObject gameObject) : base(NAME)
		{
			PanelManager.Instance.Root = gameObject;

      handleTable.Add (EnterGameResult.NAME, HandleEnterGameResult);
      handleTable.Add (GetHeroListResult.NAME, HandleGetHeroListResult);
      handleTable.Add (GetHeroResult.NAME, HandleGetHeroResult);
      handleTable.Add (LoginResult.NAME, HandleLoginResult);
      handleTable.Add (RegisterAccountResult.NAME, HandleRegisterAccountResult);
      handleTable.Add (RegisterHeroResult.NAME, HandleRegisterHeroResult);

      SendNotification(NtftNames.TG_LOADING_END);
      PanelManager.Instance.ShowPanel<LoginPanel>();
		}

		public override IList<string> ListNotificationInterests ()
		{
      List<string> interests = new List<string> ();
      foreach(string key in handleTable.Keys){
        interests.Add(key);
      }
			return interests;
		}

  	public override void HandleNotification (PureMVC.Interfaces.INotification notification)
		{
      if( handleTable.ContainsKey( notification.Name ) )
      {
        handleTable[notification.Name]( notification );
      }
		}

		private void HandleEnterGameResult (INotification notification)
		{
      	TangNet.TN.Send (new GetHeroRequest ());
      
		}

		private void HandleLoginResult (INotification notification)
    {
      LoginResult response = notification.Body as LoginResult;
			if (response == null || !response.success) {
				ShowErrorMessge(HomeLang.ERROR_MESSAGE_LOGIN);
				return;
			}

			if (response.success) {
        LoginPanelCache.HeroId = response.heroId;
        PanelManager.Instance.ShowPanel<ServerListPanel>();
        ServerListPanel serverListPanel = PanelManager.Instance.GetPanel("ServerListPanel") as ServerListPanel;
        UIEventListener.Get(serverListPanel.server1).onClick += OnServerSelected;
        // TODO
//				if (response.heroId > 0) { 
//					TangNet.TN.Send (new GetHeroRequest ());
//				} else {
//					PanelManager.Instance.ShowPanel<RegisterPanel> ();
//				}
	  
			} else {
				Debug.Log ("login failure");
			}

      
			//TangNet.TN.Send(new GetHeroListRequest());
		}

    private void HandleRegisterAccountResult (INotification notification)
		{
      RegisterAccountResult response = notification.Body as RegisterAccountResult;
			if (response == null || !response.success) {
				LoginPanelCache.ErrorMessage = HomeLang.ERROR_MESSAGE_REGISTER_ACCOUNT;
				return;
			}
	    	
			string username = LoginPanelCache.Username;
			string password = LoginPanelCache.Password;
			TangNet.TN.Send (new LoginRequest (username, password));

		}

		private void HandleRegisterHeroResult (INotification notification)
		{
      RegisterHeroResult response = notification.Body as RegisterHeroResult;
			if (response == null || response.type != 0) {
        string error = GetRegisterHeroErrorMessage(response.type);
        ShowErrorMessge(error);
        return;
			}
	    	
			TangNet.TN.Send (new GetHeroRequest ());
		}

    private string GetRegisterHeroErrorMessage(int errorCode){
      if(errorCode == -1) 
        return HomeLang.ERROR_MESSAGE_REGISTER_HERO_NAME_BEUSED;
      else 
        return HomeLang.ERROR_MESSAGE_REGISTER_HERO;
    }

    private void ShowErrorMessge (string message)
    {
      Facade.SendNotification(NtftNames.TG_SHOW_ERROR_MESSAGE, message);
    }

    private void HandleGetHeroListResult (INotification notification)
		{
      GetHeroListResult response = notification.Body as GetHeroListResult;
			if (response == null) {
				LoginPanelCache.ErrorMessage = HomeLang.ERROR_MESSAGE_GET_HEROLIST;
				return;
			}
	    	
			if (response.heros == null || response.heros.Count == 0) {
				return;
			}

			HeroCache.heroList = response.heros;
			
			// TODO: select the first hero
			SimpleHero simpleHero = response.heros [0];
			TangNet.TN.Send (new EnterGameRequest (simpleHero.heroId));
		}

    private void HandleGetHeroResult (INotification notification)
		{
      GetHeroResult response = notification.Body as GetHeroResult;
			if (response == null || response.hero == null) {
				LoginPanelCache.ErrorMessage = HomeLang.ERROR_MESSAGE_GET_HERO;
				return;
			}
			HeroNew hero = response.hero;
			ActorCache.leadingActorId = hero.id;
			ActorCache.AddOrUpdateActor (hero.id, hero);
			nh.ui.cache.UIActorCache.myHero = hero;
			//TODO
			
			if (hero.hp == 0) {
				TangNet.TN.Send (new TangGame.Net.HeroReliveRequest (1));
			}

			TangNet.TN.Send (new TangGame.Net.GetTaskKnowRequest ());

			PanelManager.Instance.EnterGame (hero.mapId);
		}

    private void OnServerSelected(GameObject obj){
      PanelManager.Instance.ShowPanel<ServerConfirmPanel> ();
      ServerConfirmPanel serverConfirmPanel = PanelManager.Instance.GetPanel("ServerConfirmPanel") as ServerConfirmPanel;
      UIEventListener.Get(serverConfirmPanel.enter).onClick += OnEnterSelected;
    }
    
    private void OnEnterSelected(GameObject obj){
      if (LoginPanelCache.HeroId > 0) { 
        TangNet.TN.Send (new GetHeroRequest ());
      } else {
        PanelManager.Instance.ShowPanel<RegisterPanel> ();
      }
    }
	}
}

using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.chat
{
	public class OneMenuPanel:XBPanel
	{
	    public new const string NAME="OneMenuPanel";
	    public UIScrollView OneMenuList;
	    public UIGrid OneMenuGrid;
	    public UIButton channel_all;
	    public UIButton channel_haojiao;
	    public UIButton channel_world;
	    public UIButton channel_secret;
	    public UIButton channel_league;
	    public UIButton channel_team;
		public UIButton channel_system;	
		
		UISprite sp_all;
		UISprite sp_haojiao;
		UISprite sp_world;
		UISprite sp_secret;
		UISprite sp_league;
		UISprite sp_team;
		UISprite sp_system;
		
		UISprite lastSprite;
		UISprite currentSprite;
	    void Start()
	    {
	        PanelCache.ChatPanelTable.Add(NAME,this);
			UIEventListener.Get(channel_all.gameObject).onClick+=Channel_allButtonClick;
			UIEventListener.Get(channel_haojiao.gameObject).onClick+=Channel_haojiaoButtonClick;
			UIEventListener.Get(channel_world.gameObject).onClick+=Channel_worldButtonClick;
			UIEventListener.Get(channel_secret.gameObject).onClick+=Channel_secretButtonClick;
			UIEventListener.Get(channel_league.gameObject).onClick+=Channel_leagueButtonClick;
			UIEventListener.Get(channel_team.gameObject).onClick+=Channel_teamButtonClick;
			UIEventListener.Get(channel_system.gameObject).onClick+=Channel_systemButtonClick;
			
			sp_all = channel_all.gameObject.transform.GetComponentInChildren<UISprite>();
			sp_haojiao = channel_haojiao.gameObject.transform.GetComponentInChildren<UISprite>();
			sp_haojiao.enabled = false;
			sp_world = channel_world.gameObject.transform.GetComponentInChildren<UISprite>();
			sp_world.enabled = false;
			sp_secret = channel_secret.gameObject.transform.GetComponentInChildren<UISprite>();
			sp_secret.enabled = false;
			sp_league = channel_league.gameObject.transform.GetComponentInChildren<UISprite>();
			sp_league.enabled = false;
			sp_team = channel_team.gameObject.transform.GetComponentInChildren<UISprite>();
			sp_team.enabled = false;
			sp_system = channel_system.gameObject.transform.GetComponentInChildren<UISprite>();
			sp_system.enabled = false;
			
			lastSprite = sp_all;
			currentSprite = sp_all;
			
			FlashEffect fe1 = sp_secret.gameObject.AddComponent<FlashEffect>();
			fe1.enabled = false;
			fe1 = sp_league.gameObject.AddComponent<FlashEffect>();
			fe1.enabled = false;
			fe1 = sp_team.gameObject.AddComponent<FlashEffect>();
			fe1.enabled = false;
	    }
		
		
		
		public void Channel_allButtonClick(GameObject obj)
	    {
	        NewChatCache.currentChannel = 0;
			currentSprite = sp_all;
			MarkChannel ();
	    }
		public void Channel_haojiaoButtonClick(GameObject obj)
	    {
	        NewChatCache.currentChannel = 1;
			currentSprite = sp_haojiao;
			MarkChannel ();
	    }
		public void Channel_worldButtonClick(GameObject obj)
	    {
	        NewChatCache.currentChannel = 2;
			currentSprite = sp_world;
			MarkChannel ();
	    }
		public void Channel_secretButtonClick(GameObject obj)
	    {
	        NewChatCache.currentChannel = 3;
			currentSprite = sp_secret;
			MarkChannel ();
			FlashEffect fe = sp_secret.gameObject.GetComponent<FlashEffect>();
			if(fe && fe.enabled) fe.enabled = false;
	    }
		public void Channel_leagueButtonClick(GameObject obj)
	    {
	        NewChatCache.currentChannel = 4;
			currentSprite = sp_league;
			MarkChannel ();
			FlashEffect fe = sp_league.gameObject.GetComponent<FlashEffect>();
			if(fe && fe.enabled) fe.enabled = false;
	    }
		public void Channel_teamButtonClick(GameObject obj)
	    {
	        NewChatCache.currentChannel = 5;
			currentSprite = sp_team;
			MarkChannel ();
			FlashEffect fe = sp_team.gameObject.GetComponent<FlashEffect>();
			if(fe && fe.enabled) fe.enabled = false;
	    }
		public void Channel_systemButtonClick(GameObject obj)
	    {
	        NewChatCache.currentChannel = 6;
			currentSprite = sp_system;
			MarkChannel ();
	    }
		
		void MarkChannel(){
			lastSprite.enabled = false;
			lastSprite = currentSprite;
			currentSprite.enabled = true;
			currentSprite.alpha = 1f;
		}
	}
}
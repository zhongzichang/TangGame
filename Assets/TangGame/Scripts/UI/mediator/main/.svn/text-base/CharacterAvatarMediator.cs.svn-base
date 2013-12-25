using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.model.vo;
using nh.ui.cache;
using TangGame;
using TangGame.Net;

namespace nh.ui.main
{
	public class CharacterAvatarMediator : Mediator
	{
		public new const string NAME = "CharacterAvatarMediator";
		
		private List<string> interests = new List<string> ();
		
		string[] modes = new string[] {"普","队","家","战","战","战","战"};
		string[] headIcons =new string[] {"信女1","信男1","清女1","清男1","信女1","信男1","清女1","清男1"};
		CharacterAvatarPanel panel;
		HeroNew hero;
		public CharacterAvatarMediator(CharacterAvatarPanel viewComponent): base(NAME)
		{
			panel=viewComponent;
			hero=ActorCache.GetLeadingHero();
			
		}
		public override IList<string> ListNotificationInterests(){
			if (interests.Count == 0) {
				interests.Add (NotificationIDs.ID_ReSetHeroPropertyNum);
				interests.Add(TangGame.NtftNames.TG_LEADING_ACTOR_RELIVE);
		    }
			return interests;
		}
		public override void HandleNotification (INotification notification){
			
			if (NotificationIDs.ID_ReSetHeroPropertyNum.Equals(notification.Name)){
				panel.RefreshPropertyNum();
//				Debug.Log("~~~~~~~~~~~~ID_ReSetHeroPropertyNum~~~~~~~~~~~~~~");
			}else if(TangGame.NtftNames.TG_LEADING_ACTOR_RELIVE.Equals(notification.Name)){
				panel.RefreshPropertyNum();
			}
    	}
		
		/*
		#region ====================刷新面板各种数据=======================
		public void RefreshData()
		{
			ReSetHealthBar();
			ReSetAcatarSprite();
			ReSetManaBar();
			ReSetAcatarSprite();
			ReSetLevel();
			ReSetBattleMode();
		}
		public void ReSetHealthBar()
		{
			panel.lifeProgressBar.sliderValue=(float)hero.hp/(float)hero.hpMax;

		}
		public void ReSetManaBar()
		{
			panel.manaProgressBar.sliderValue=(float)hero.mp/(float)hero.mpMax;
		}
		public void ReSetAcatarSprite()
		{
			panel.avater.spriteName = GetHeadIcon(hero.genre, hero.sex);
		}
		public void ReSetLevel()
		{
			panel.level.text = hero.level.ToString();
		}
		public void ReSetBattleMode()
		{
			panel.battleMode.GetComponent<UISprite>().spriteName = GetModeByIndex(hero.portraitMode);
		}
		public void ChangeBattleMode()
		{
			NetworkCache.RequestQueue.Enqueue(new ChangeHeroModelRequest(hero.portraitMode%4+1));
		}
		#endregion

		#region ===============其它方法===================
		private string GetModeByIndex(int index)
		{
			return modes[System.Math.Abs(index-1)];
		}
		private string GetHeadIcon(short genre, short sex)
		{
			if(sex == 1){
				return Config.heroInitializeTable[genre.ToString()].Male_icon;
			}else{
				return Config.heroInitializeTable[genre.ToString()].Female_icon;
			}
		}   
		#endregion   
		*/
	}
}

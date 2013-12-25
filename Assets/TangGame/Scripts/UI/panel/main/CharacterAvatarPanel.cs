using UnityEngine;
using System.Collections;
using TangGame;
using nh.ui.cache;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace nh.ui.main
{
	public class CharacterAvatarPanel : XBPanel
	{
		public new const string NAME="CharacterAvatarPanel";
		public UIButton CharacterAvatar;
		public UISprite bgAvater;
		public UISprite avater;
		public UIButton battleMode;
		public UILabel level;
		public UISlider lifeProgressBar;
		public UISlider manaProgressBar;
		CharacterAvatarMediator mediator;
		private TangGame.Net.HeroNew hero;

		string[] modes;
		void Start()
		{
			mediator=new CharacterAvatarMediator(this);
			Facade.Instance.RegisterMediator(mediator);
			PanelCache.MainPanelTable.Add(NAME,mediator);
			UIEventListener.Get(battleMode.gameObject).onClick +=BattleModeClick;
			UIEventListener.Get(CharacterAvatar.gameObject).onClick+=CharacterAvatarClick;
			
//			hero = ActorCache.GetLeadingHero();
			hero = UIActorCache.myHero;
			modes = new string[] {"普","队","家","战","战","战","战"};
			RefreshData();
//			Debug.Log(hero.sex);
		}
		
		void Update()
		{

		}

		public void BattleModeClick(GameObject obj)
		{
			this.ChangeBattleMode();
		}
		public void CharacterAvatarClick(GameObject obj)
		{
			Debug.Log("you click me ~ -"+obj.name+" say!");
		}
		
		
		#region ====================刷新面板各种数据=======================
		public void RefreshData()
		{
			ReSetHealthBar();
			ReSetAcatarSprite();
			ReSetManaBar();
			ReSetLevel();
			ReSetBattleMode();
		}
		public void RefreshPropertyNum(){
			ReSetHealthBar();
			ReSetManaBar();
			ReSetLevel();
			ReSetBattleMode();
		}
		
		public void ReSetHealthBar()
		{
			lifeProgressBar.sliderValue=(float)hero.hp/(float)hero.hpMax;

		}
		public void ReSetManaBar()
		{
			manaProgressBar.sliderValue=(float)hero.mp/(float)hero.mpMax;
		}
		public void ReSetAcatarSprite()
		{
			avater.spriteName = Config.GetHeadIcon(hero.genre, hero.sex);
		}
		public void ReSetLevel()
		{
			level.text = hero.level.ToString();
		}
		public void ReSetBattleMode()
		{
			battleMode.GetComponent<UISprite>().spriteName = GetModeByIndex(hero.portraitMode);
		}
		public void ChangeBattleMode()
		{
//			NetworkCache.RequestQueue.Enqueue(new ChangeHeroModelRequest(hero.portraitMode%4+1));
		}
		#endregion

		#region ===============其它方法===================
		private string GetModeByIndex(int index)
		{
			return modes[System.Math.Abs(index-1)];
		}
		#endregion
		
	}
}


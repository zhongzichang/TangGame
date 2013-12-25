using System;
using UnityEngine;
using System.Collections;
using TangGame;
using TangGame.Xml;
using TangGame.Net;

namespace TangGame
{
	public class RegisterPanel : ViewPanel
	{
		public GameObject heroName;
		public GameObject create;
		public GameObject randomName;
		public GameObject heroTypeRoot;
		public GameObject heroSexRoot;
		public GameObject heroImages;
		public GameObject genderInfo;
		// TODO: only 1 heroType
//		public GameObject genderName;
		public GameObject agility;
		public GameObject attack;
		public GameObject defense;
		private UIInput heroNameInput;
		private UILabel genderInfoLabel;
		private UILabel genderNameLabel;
		private UISlider agilitySlider;
		private UISlider attackSlider;
		private UISlider defenseSlider;

		void Start ()
		{
			UIEventListener.Get (create).onClick += OnCreateButtonClicked;
			UIEventListener.Get (randomName.gameObject).onClick += OnRandomNameButtonClicked;
			
			OnInit ();
		}

		private void OnInit ()
		{
			InitToggle (heroSexRoot, OnHeroSexToggleClicked);
			InitToggle (heroTypeRoot, OnHeroTypeToggleClicked);

			heroNameInput = heroName.GetComponent<UIInput> ();
			heroNameInput.value = NameCache.GetName (LoginPanelCache.HeroSex);

			genderInfoLabel = genderInfo.GetComponent<UILabel> ();
			// TODO: only 1 heroType
//			genderNameLabel = genderName.GetComponent<UILabel> ();

			agilitySlider = agility.GetComponent<UISlider> ();
			attackSlider = attack.GetComponent<UISlider> ();
			defenseSlider = defense.GetComponent<UISlider> ();

			LoadHeroInfo ();
			LoadHeroImage ();
		}

		private void OnRandomNameButtonClicked (GameObject go)
		{
			short heroSex = LoginPanelCache.HeroSex;
			Debug.Log ("OnRandomNameButtonClicked " + heroSex);
			heroNameInput.value = NameCache.GetName (heroSex);
		}

		private void OnCreateButtonClicked (GameObject go)
		{
			string heroName = heroNameInput.value;
			short heroSex = LoginPanelCache.HeroSex;

			int heroTypeId = LoginPanelCache.HeroTypeId;
			int heroType = LoginPanelCache.HeroType;
			Debug.Log (String.Format ("OnCreateButtonClicked {0} {1} {2} {3}", heroName, heroSex, heroTypeId, heroType));
			TangNet.TN.Send (new CreateHeroRequest (heroName, heroSex, heroType));
		}

		private void InitToggle (GameObject parent, UIEventListener.VoidDelegate func)
		{
			foreach (UIToggle toggle in parent.GetComponentsInChildren<UIToggle>()){
//			foreach (Transform obj in parent.transform) {
//				UIToggle toggle = obj.GetComponent<UIToggle> ();
				if (toggle != null) {
					UIEventListener.Get (toggle.gameObject).onClick += func;
				}
			}
		}

		private void OnHeroSexToggleClicked (GameObject go)
		{
			Debug.Log (go.name);
			LoginPanelCache.UpdateHeroSex (go.name);
			
			LoadHeroImage ();
		}

		private void OnHeroTypeToggleClicked (GameObject go)
		{
			Debug.Log (go.name);
			LoginPanelCache.UpdateHeroType (go.name);
			
			LoadHeroInfo ();
			LoadHeroImage ();
		}

		private void LoadHeroInfo ()
		{
			HeroInitialize hero = LoginPanelCache.GetHeroInfo ();
			Debug.Log ("LoadHeroInfo" + hero);
			if (hero == null)
				return;

			// TODO: only 1 heroType
			// genderNameLabel.text = hero.Name;
			genderInfoLabel.text = hero.Info;
			agilitySlider.value = (float)hero.Agility / (float)100;
			attackSlider.value = (float)hero.Attack / (float)100;
			defenseSlider.value = (float)hero.Defense / (float)100;
		}

		private void LoadHeroImage ()
		{
			// TODO: only 1 heroType
			return;
			UISprite sprite = heroImages.GetComponent<UISprite> ();
			sprite.spriteName = LoginPanelCache.GetHeroImageName ();
		}
	}
}

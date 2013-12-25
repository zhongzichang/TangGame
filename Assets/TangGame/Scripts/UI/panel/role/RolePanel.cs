/*
 * yc : 2013/11/12
*/
using System;
using UnityEngine;
using nh.ui.basePanel;
using nh.ui.cache;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;
using TangGame.Net;
using System.Collections;
using System.Collections.Generic;
using Tang;
namespace nh.ui.main
{
	public class RolePanel : BasePanel
	{
		public GameObject equBut;         		//装备升级按钮
		public GameObject strengthBut;			//强化按钮strengthBut
		public GameObject gemBut;				//宝石按钮	
		public GameObject rageBut;				//仙珠按钮
//		public GameObject vipBut;				//vip按钮
//		public GameObject titleBut;				//称号按钮
		
		public GameObject LabelFighting;		//战斗力label
		public GameObject lifeNum;				//生命label
		public GameObject attackNum;			//攻击label
		public GameObject defenseNum;			//防御label
		public GameObject accuracyNum;			//命中label
		public GameObject missNum;				//闪避label
		public GameObject critNum;				//暴击label
		public GameObject tenacityNum;			//韧性label
		public GameObject nameLabel;			//玩家名字显示
		public GameObject HItem1;				//左1装备HItem头盔
		public GameObject HItem2;				//左2装备HItem盔甲
		public GameObject HItem3;				//左3装备HItem护手
		public GameObject HItem4;				//左4装备HItem裤子
		public GameObject HItem5;				//左5装备HItem鞋子
		public GameObject HItem6;				//左6装备HItem武器
		public GameObject HItem7;				//右1装备HItem项链
		public GameObject HItem8;				//右2装备HItem玉佩
		public GameObject HItem9;				//右3装备HItem腰坠
		public GameObject HItem10;				//右4装备HItem戒指1
		public GameObject HItem11;				//右5装备HItem戒指2
		public GameObject HItem12;				//右6装备HItem杂项
		public GameObject HItem13;				//下左装备HItem坐骑
		public GameObject HItem14;				//下右装备HItem披风

		private GameObject cameraObj;
		private UILabel[] nums;
		private TangGame.Net.HeroNew mHero;
		private SpriteAnimation sa;
		private float timer = 0;
		
		private Dictionary<EquipSite,GameObject> equList;
//		public string prePanel = NotificationIDs.ID_OpenOrCloseRole1st;
		private GameObject selectedObj;
		
		public GameObject SelectedObj{
			get{
				return selectedObj;
			}
			set{
				selectedObj = value;
			}
		}
		public RolePanel()
		{
		}
		void Awake(){
		
		}
		void Start(){
			nums = new UILabel[8];
			nums[0] = lifeNum.GetComponent<UILabel>();
			nums[1] = attackNum.GetComponent<UILabel>();
			nums[2] = defenseNum.GetComponent<UILabel>();
			nums[3] = accuracyNum.GetComponent<UILabel>();
			nums[4] = missNum.GetComponent<UILabel>();
			nums[5] = critNum.GetComponent<UILabel>();
			nums[6] = tenacityNum.GetComponent<UILabel>();
			nums[7] = LabelFighting.GetComponent<UILabel>();
//			mHero = ActorCache.GetLeadingHero();
			mHero = UIActorCache.myHero;
			
			nameLabel.GetComponent<UILabel>().text = mHero.name;
//			PureMVC.Patterns.Facade.Instance.SendNotification(prePanel);
//			GetComponent<UIPanel>().depth = 3;
			
//			strengthBut.GetComponent<UIButton>().isEnabled = false;
//			gemBut.GetComponent<UIButton>().isEnabled = false;
//			rageBut.GetComponent<UIButton>().isEnabled = false;
			equList = new Dictionary<RolePanel.EquipSite, GameObject>();
			equList.Add(EquipSite.WEAPON,HItem6);
			equList.Add(EquipSite.HELMET,HItem1);
			equList.Add(EquipSite.CLOTHES,HItem2);
			equList.Add(EquipSite.HANDGUARD,HItem3);
			equList.Add(EquipSite.PANTS,HItem4);
			equList.Add(EquipSite.SHOE,HItem5);
			equList.Add(EquipSite.NECKLACE,HItem7);
			equList.Add(EquipSite.CLOAK,HItem14);
			equList.Add(EquipSite.SIGN,HItem8);
			equList.Add(EquipSite.AMULET,HItem9);
			equList.Add(EquipSite.RING,HItem10);
			equList.Add(EquipSite.RING2,HItem11);
			equList.Add(EquipSite.SUNDRY,HItem12);

			cameraObj = GameObject.Instantiate(Resources.Load("Prefabs/Panel/CameraAvatar")) as GameObject;
			CreateHeroImage();
			
			DynamicBindUtil.BindToggleObjects(equBut);
		}

		void OnEnable(){
			if(cameraObj) cameraObj.SetActive(true);
		}

		void OnDisable(){
			if(cameraObj) cameraObj.SetActive(false);
		}

		void Update(){
			timer += Time.deltaTime;
			if(timer > 0.1){
				sa.currentIndex = (sa.currentIndex + 1)%9;
				timer = 0;
			}
		}

		private void CreateHeroImage(){
			GameObject actor = TangScene.TS.GetActorGameObject(ActorCache.leadingActorId);
			GameObject animationObj = actor.transform.GetChild(0).gameObject;

			GameObject heroRole = GameObject.Instantiate(animationObj) as GameObject;
			heroRole.transform.parent = cameraObj.transform;
			heroRole.transform.localPosition = new Vector3(-204, -28, 0);
			heroRole.transform.eulerAngles = new Vector3(270, 0, 0);
			heroRole.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
//			heroRole = NGUITools.AddChild(gameObject,heroRole);
//			heroRole.transform.localPosition = new Vector3(-235,0,-3);
//			Quaternion rotation = Quaternion.identity;
//			rotation.eulerAngles = new Vector3(270,1,1);
//			heroRole.transform.localRotation = rotation;
//			heroRole.transform.localScale = new Vector3(2,1,2);

			GameObject body = heroRole.transform.Find("body").gameObject;
			SpriteLayerBhvr slb = body.GetComponent<SpriteLayerBhvr>();
			slb.hiddenBeforeBegin = false;
			slb.hiddenAfterEnd = false;
			body = body.transform.GetChild(0).gameObject;
//			body.renderer.material.shader = Shader.Find("Custom/RoleShader");    //change shader Transparent/Cutout/Diffuse
//			me.mainTexture = body.renderer.material.mainTexture;
//			body.renderer.material = me;
			MultiSetSprite sps = body.GetComponent<MultiSetSprite>();
			sps.currentSetName = "idle/0";
//			
			GameObject weapon = heroRole.transform.Find("weapon").gameObject;
			slb = weapon.GetComponent<SpriteLayerBhvr>();
			slb.hiddenBeforeBegin = false;
			slb.hiddenAfterEnd = false;
			weapon = weapon.transform.GetChild(0).gameObject;
//			weapon.renderer.material.shader = Shader.Find("Custom/RoleShader");   //change shader
//			me1.mainTexture = weapon.renderer.material.mainTexture;
//			weapon.renderer.material = me1;
			sps = weapon.GetComponent<MultiSetSprite>();
			sps.currentSetName = "idle/0";
			
			sa = heroRole.GetComponent<SpriteAnimation>();
		}
		public void UpdateMyHeroPropertyNum(){
//			StartCoroutine(UpdateHeroPropertyNum());
			nums[0].text = "[ff0000]"+ mHero.hp +"[-]/"+ mHero.hpMax;
			nums[1].text = mHero.physicalAttack.ToString();
			nums[2].text = mHero.physicalDefense.ToString();
			nums[3].text = mHero.hitrate.ToString();
			nums[4].text = mHero.dodge.ToString();
			nums[5].text = mHero.criticalStrike.ToString();
			nums[6].text = mHero.tenacity.ToString();
//			nums[7].text = "战斗力-" + mHero.fightingCapacity;
		}
		//更新角色面板信息
		public void UpdateMyheroEquAndPropertyNum(AskForHeroEquResult push){
//	        Debug.Log(push.fightingCapacity + ":" + push.hp + ":" +push.hpMax + ":" +push.physicalAttack + ":" +push.physicalDefense + ":" +push.hitRate 
//	                  + ":" +push.dodge + ":" + push.criticalStrike + ":" +push.tenacity);
			nums[0].text = "[ff0000]"+push.hp +"[-]/"+ push.hpMax;
			nums[1].text = push.physicalAttack.ToString();
			nums[2].text = push.physicalDefense.ToString();
			nums[3].text = push.hitRate.ToString();
			nums[4].text = push.dodge.ToString();
			nums[5].text = push.criticalStrike.ToString();
			nums[6].text = push.tenacity.ToString();
			nums[7].text = "战斗力  :  " + push.fightingCapacity;
			//临时设置一个图标
//			SetEquItem(1,HItem1);
			if(push.heroEqus.Count > 0){
				List<short> types = new List<short>(push.heroEqus.Keys);Debug.Log(push.heroEqus.Count);			
				for(int i = 0;i < types.Count;i++){
					switch((EquipSite)(types[i])){
						case EquipSite.WEAPON:
							SetEquItem(push.heroEqus[types[i]],HItem6);
							break;
						case EquipSite.HELMET:
							SetEquItem(push.heroEqus[types[i]],HItem1);
							break;
						case EquipSite.CLOTHES:
							SetEquItem(push.heroEqus[types[i]],HItem2);
							break;
						case EquipSite.HANDGUARD:
							SetEquItem(push.heroEqus[types[i]],HItem3);
							break;
						case EquipSite.PANTS:
							SetEquItem(push.heroEqus[types[i]],HItem4);
							break;
						case EquipSite.SHOE:
							SetEquItem(push.heroEqus[types[i]],HItem5);
							break;
						case EquipSite.NECKLACE:
							SetEquItem(push.heroEqus[types[i]],HItem7);
							break;
						case EquipSite.CLOAK:
							SetEquItem(push.heroEqus[types[i]],HItem14);
							break;
						case EquipSite.SIGN:
							SetEquItem(push.heroEqus[types[i]],HItem8);
							break;
						case EquipSite.AMULET:
							SetEquItem(push.heroEqus[types[i]],HItem9);
							break;
						case EquipSite.RING:
							SetEquItem(push.heroEqus[types[i]],HItem10);
							break;
						case EquipSite.RING2:
							SetEquItem(push.heroEqus[types[i]],HItem11);
							break;
						case EquipSite.SUNDRY:
							SetEquItem(push.heroEqus[types[i]],HItem12);
							break;
					}
				}
			}
		}
		//通过物品id设置精灵图片
		private void SetEquItem(int goodsId,GameObject hItem){
			TangGame.Xml.ItemData item = TangGame.Config.itemTable[goodsId];
			int icon = item.Icon;
			HItem mi = hItem.GetComponent<HItem>();
			mi.UpdateShow(icon,false,0,0, GameConsts.GOODSITEM);
			mi.ItemId = goodsId;
		}
		
		public void UpdateEquItem(int site ,int goodsId){
			EquipSite si = (EquipSite)site;
			SetEquItem(goodsId,equList[si]);
		}

		
		public enum EquipSite
		{
			NONE,
			WEAPON,//武器
			HELMET,//头盔
			CLOTHES,//衣服
			HANDGUARD,//护手
			PANTS,//裤子
			SHOE,//鞋子
			NECKLACE,//项链
			CLOAK,//披风
			SIGN,//腰牌
			AMULET,//护身符
			RING,//戒指
			RING2,//戒指2
			SUNDRY//杂项
		}

	}
}

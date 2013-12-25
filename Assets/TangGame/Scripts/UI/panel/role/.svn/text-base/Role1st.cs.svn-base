/*
 * yc : 2013/11/19
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
using TangGame.Xml;
namespace nh.ui.main
{
	public class Role1st : BasePanel
	{
		public GameObject Checkbox;         		//是否自动购买材料
		public GameObject confirmBut;				//升级按钮
		public GameObject TopIcon;					//装备顶级图标
		public GameObject CurrentIcon;				//装备下一级图标	
		public GameObject goldNum;					//自动购买材料所需的花费
		public GameObject goldIcon;					//自动购买材料所需的货币类型图标
		public GameObject LabelAttribute;			//装备当前属性
		public GameObject LabelAttributeText1;		//装备当前属性数值
		public GameObject LabelItem;				//装备当前名字
		public GameObject LabelItemLevel;			//装备使用等级信息
		public GameObject LabelAttributeText2;		//装备升级后的数值增量
		public GameObject LabelGold;				//升级装备的货币消耗类型obj
		public GameObject LabelGoldNum;				//升级装备的货币消耗数值obj
		public GameObject Item1;					//升级装备的材料1
		public GameObject Item2;					//升级装备的材料2
		public GameObject Item3;					//升级装备的材料3
		public GameObject Item4;					//升级装备的材料4
		
		private UILabel attr;						//装备当前属性Label
		private UILabel attributeLabel;				//装备当前数值Label
		private UILabel attributeUpLabel;			//装备升级后的数值增量Label
		private UILabel itemNameLabel;				//装备名字Label
		private UILabel itemLevelInfoLabel;			//装备等级信息Label
		private UILabel coinLabel;					//装备升级所需铜币数值Label
		private UILabel goldLabel;					//装备升级所需购买所需货币数值Label
		
		public UIButton but;						//装备升级按钮uiButton
		private int itemToUpLevel = -1;					//当前要去升级的装备Id
		public Role1st()
		{
		}
		public int ItemToUpLevel{
			set{
				itemToUpLevel = value;
			}
			get{
				return itemToUpLevel;
			}
		}
		void Start(){
			attr = LabelAttribute.GetComponent<UILabel>();
			attr.text = "";
			attributeLabel = LabelAttributeText1.GetComponent<UILabel>();
			attributeLabel.text = "";
			attributeUpLabel = LabelAttributeText2.GetComponent<UILabel>();
			attributeUpLabel.text = "";
			coinLabel = LabelGoldNum.GetComponent<UILabel>();
			coinLabel.text = ""; 
			goldLabel = goldNum.GetComponent<UILabel>();
			goldLabel.text = "";
			itemNameLabel = LabelItem.GetComponent<UILabel>();
			itemNameLabel.text = "";
			itemLevelInfoLabel = LabelItemLevel.GetComponent<UILabel>();
			itemLevelInfoLabel.text = "";
			but = confirmBut.GetComponent<UIButton>();
			but.isEnabled = false;
		}
		void Update(){

		}
		//临时出版本代码
		public void SetTopAndNextItem1(int itemId){
			SetEquItem (itemId,CurrentIcon);
			string[] temp = TangGame.Config.itemTable[itemId].Equipproperty.Split(',');
			string num = "";Debug.Log(TangGame.Config.itemTable[itemId].Id);
			HeroPropertyEnum type = (HeroPropertyEnum)(int.Parse(temp[0]));
			switch(type){
				case HeroPropertyEnum.PHYSICALATTACK:
					num += "物理攻击";
					break;
				case HeroPropertyEnum.PHYSICALDEFENSE:
					num += "物理防御";
					break;
				case HeroPropertyEnum.MAGICATTACK:
					num += "法术攻击";
					break;
				case HeroPropertyEnum.MAGICDEFENSE:
					num += "法术防御";
					break;
				case HeroPropertyEnum.HITRATE:
					num += "命中";
					break;
				case HeroPropertyEnum.DODGE:
					num += "闪避";
					break;
				case HeroPropertyEnum.CRITICALSTRIKE:
					num += "暴击";
					break;
				case HeroPropertyEnum.TENACITY:
					num += "韧性";
					break;	
			}

			itemNameLabel.text = TangGame.Config.GetItemColorName(itemId);
			itemLevelInfoLabel.text = "装备使用等级:" + TangGame.Config.itemTable[itemId].NeedLv;
//			itemNameLabel.text = TangGame.Config.itemTable[itemId].Name;
			attr.text = num;
			attributeLabel.text = "+" + temp[1];
		}
		public void SetTopAndNextItem(int itemId){
			int topItemId = FindTopId(itemId);
			int nextItemId = -1;
			if(TangGame.Config.equip_upgrade[itemId].Next_id > 0){
				nextItemId = TangGame.Config.equip_upgrade[itemId].Next_id;
			}else{
				nextItemId = itemId;
			}	
			SetEquItem (topItemId,TopIcon);
			SetEquItem(nextItemId,CurrentIcon);
			attributeLabel.text = TangGame.Config.itemTable[itemId].Equipproperty.ToString();
//			attributeUpLabel.text = (TangGame.Config.itemTable[nextItemId].Equipproperty - TangGame.Config.itemTable[itemId].Equipproperty).ToString();
		}
		//可升级的行为
		public void SetCanUpLevel(int itemId){
			Equip_upgrade equ = TangGame.Config.equip_upgrade[itemId];
			coinLabel.text = equ.Money.ToString();
			string[] needs = equ.Upgradenum.Split(';');
			string[] temp;
			int goldNeed = 0;
			for(int i = 0;i < needs.Length;i++){
				temp = needs[i].Split(',');
				if(i == 0){
					SetEquItem(FindMinitypeItemId(temp[0],equ),Item1);
					//TODO 设置数量显示 ,计算购买材料所需的金锭或银锭数值
				}else if(i == 1){
					SetEquItem(FindMinitypeItemId(temp[0],equ),Item2);
				}else if(i == 2){
					SetEquItem(FindMinitypeItemId(temp[0],equ),Item3);
				}else{
					SetEquItem(FindMinitypeItemId(temp[0],equ),Item4);
				}
			}
			goldLabel.text = goldNeed.ToString();  
			ItemToUpLevel = itemId;
			but.isEnabled = true;
		}
		//通过minitype寻找itemId
		private int FindMinitypeItemId(string minitype,Equip_upgrade equ){
			string[] temp = equ.Minitype_id.Split(';');
			string[] temp1;
			int toParse = -1;
			foreach(string str in temp){
				temp1 = str.Split(':');
				if(minitype.Equals(temp1[0]))
				   toParse = int.Parse( temp1[1]);
			}
			return toParse;
		}
		//寻找顶级装备的id
	    private int FindTopId(int goodsId){
	    	int temp = goodsId;
	    	while(TangGame.Config.equip_upgrade[temp].Next_id > 0){
	    		temp = TangGame.Config.equip_upgrade[temp].Next_id;
	    	}
	    	return temp;
	    }
		//通过物品id设置精灵图片
		private void SetEquItem(int goodsId,GameObject hItem){
			TangGame.Xml.ItemData item = TangGame.Config.itemTable[goodsId];
			int icon = item.Icon;
			HItem mi = hItem.GetComponent<HItem>();
			mi.UpdateShow(icon,false,0,0, GameConsts.GOODSITEM);
			mi.ItemId = goodsId;
		}
	}
}

/*
 * Created by SharpDevelop.
 * User: xbhuang
 * Date: 2013/11/11
 * Time: 14:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using nh.ui.basePanel;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;

namespace nh.ui.talk
{
	/// <summary>
	/// 功能NPC对话面板
	/// </summary>
	public class NPCTalkPanel : PopupPanel
	{
		/// <summary>
		/// 背景框
		/// </summary>
		public GameObject BackGround;
		/// <summary>
		/// 半身图标
		/// </summary>
		public GameObject headIcon;
		/// <summary>
		/// NPC名字
		/// </summary>
		public GameObject nameLabel;
		/// <summary>
		/// 退出按钮
		/// </summary>
		public GameObject npcExitBut;
		/// <summary>
		/// NPC的废话
		/// </summary>
		public GameObject npcLabel;
		/// <summary>
		/// 对话框背景
		/// </summary>
		public GameObject talkBG;
		/// <summary>
		/// 功能按钮
		/// </summary>
		public GameObject talkBut;
		public NPCTalkPanel()
		{
			
		}
		public void UpdateNPCTalkPanel(NPCTalkBean bean){
			TangGame.Net.Npc npc = ActorCache.GetNpcById(bean.npcId);
			this.SetHeadIcon(npc.helfLengthPhoto);
			this.SetLabel(npc.talk);
			this.SetNameLable(npc.name);
			
			/// <summary>
			/// 按钮名字
			/// </summary>
			/// <param name="headIconId"></param>
			switch((NpcFunctionEnum)bean.npcType){
				//材料
				case NpcFunctionEnum.METERIALSTORE:
					this.SetTalkButLabel(StoreLang.MATERIALS_STORE_BTN);
					break;
				//药店
				case NpcFunctionEnum.DRUGSTORE:
					this.SetTalkButLabel(StoreLang.PHARMACY_BTN);
					break;
				//装备
				case NpcFunctionEnum.EQUIP:
					this.SetTalkButLabel(StoreLang.EQUIPMENT_STORE_BTN);
					break;
				//商城
				case NpcFunctionEnum.SHOPPINGMALL:
					this.SetTalkButLabel(StoreLang.INGOT_STORE_BTN);
					break;
				//神秘
				case NpcFunctionEnum.SHOP:
					this.SetTalkButLabel(StoreLang.MYSTERY_SHOP_BTN);
					break;
				//杂货
				case NpcFunctionEnum.VARIETYSTORE:
					this.SetTalkButLabel(StoreLang.GROCERY_STORE_BTN);
					break;
			}
			
		}
		/// <summary>
		/// 设置人物头像精灵
		/// </summary>
		/// <param name="headIconId">精灵头像ID</param>
		public void SetHeadIcon(string headIconId){
			this.headIcon.GetComponent<UISprite>().spriteName = headIconId;
		}
		/// <summary>
		/// 设置面板上NPC的名字
		/// </summary>
		/// <param name="str"></param>
		public void SetNameLable(string str){
			this.nameLabel.GetComponent<UILabel>().text = str;
		}
		public void SetLabel(string str){
			this.npcLabel.GetComponent<UILabel>().text = str;
		}
		/// <summary>
		/// 设置功能按钮的名字
		/// </summary>
		/// <param name="str"></param>
		public void SetTalkButLabel(string str){
			this.talkBut.GetComponentInChildren<UILabel>().text = str;
		}
	}
}

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
using nh.ui.mediator;

namespace nh.ui.talk
{
	/// <summary>
	/// 游戏对话面板
	/// </summary>
	public class MissionTalkPanel : PopupPanel
	{
		public GameObject headIcon;
		public GameObject missionBut;
		public GameObject missionTextLabel;
		public GameObject nameLabel;
		public GameObject talkBG;
		private TangGame.Net.Npc npc;
		private string[] talks;
		/// <summary>
		/// 对话索引，表示第几条对话
		/// </summary>
		private int talkIndex = 0;
		
		public int TalkIndex {
			get { return talkIndex; }
			set { talkIndex = value; }
		}
		public MissionTalkPanel()
		{
			
		}
		void Start(){
			NGUITools.AddWidgetCollider(talkBG);
		}
		public void UpdateMissionTalkPanel(MissionTalkBean bean){
			npc = ActorCache.GetNpcById(bean.npcId);
			if(bean.note != null && !bean.note.Equals("")&&bean.note.Length > 0){
				talks = bean.note.Split(TaskLang.NOTE_DELIMITER);
				this.NextDialogue();
			}else{
				Facade.Instance.SendNotification(NotificationIDs.ID_CLOSE_MISSION_TALK_PANEL);
			}
		}
		
		/// <summary>
		/// 显示下一个对话
		/// </summary>
		public void NextDialogue(){
			//如果对话索引大于对话数量则完成对话
			if(talks == null || talkIndex >= talks.Length)
			{
				Facade.Instance.SendNotification(NotificationIDs.ID_CLOSE_MISSION_TALK_PANEL);
			}
			else
			{
				string note = "";
				int markIndex = 0;
				string markStr = "";
				note = talks[talkIndex];
				char markChar = '#';
				if(note.Contains(markChar.ToString())){
					markIndex = note.IndexOf(markChar);
					markStr = note.Substring(markIndex,2);
					note = note.Substring(markIndex + 2,note.Length - (markIndex + 2));
				}
				switch(markStr)
				{
					case "#N":
						this.ShowNpcDialogue(note);
						break;
					case "#H":
						this.ShowHeroDialogue(note);
						break;
					default:
						this.ShowNpcDialogue(note);
						break;
				}
				talkIndex++;
			}
			
		}
		/// <summary>
		/// 显示NPC的对话
		/// </summary>
		/// <param name="talk"></param>
		public void ShowNpcDialogue(string talk){
			headIcon.GetComponent<UISprite>().spriteName = npc.helfLengthPhoto;
			nameLabel.GetComponent<UILabel>().text = npc.name;
			UILabel missionTextUILabel = missionTextLabel.GetComponent<UILabel>();
			//TODO
			//Erorr The object of type 'UILabel' has been destroyed but you are still trying to access it.
			missionTextUILabel.text = talk;
		}
		/// <summary>
		/// 显示自己英雄的对话
		/// </summary>
		/// <param name="talk"></param>
		public void ShowHeroDialogue(string talk){
			TangGame.Net.HeroNew hero = ActorCache.GetLeadingHero();
			headIcon.GetComponent<UISprite>().spriteName = hero.helfLengthPhoto;
			nameLabel.GetComponent<UILabel>().text = hero.name;
			missionTextLabel.GetComponent<UILabel>().text = talk;
		}
	}
}

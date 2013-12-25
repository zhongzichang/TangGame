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
	public class MissionAwardPanel : PopupPanel
	{
		public GameObject awardLabel;
		public GameObject expLabel;
		public GameObject goldLabel;
		public GameObject missionBut;
		public GameObject talkBG;
		public GameObject expValue;
		public GameObject goldValue;
		public GameObject itemGrid;
		private TangGame.Net.Npc npc;
		private TangGame.Xml.Task task;
		private string[] rewards;
		public MissionAwardPanel()
		{
			
		}
		public void UpdateMissionAwardPanel(MissionAwardBean bean){
			npc = ActorCache.GetNpcById(bean.npcId);
			task = Config.taskTable[bean.taskId];
			if(bean.taskState == TaskState.NONE){
        missionBut.GetComponentInChildren<UISprite>().spriteName = "accept";
			}
			if(bean.taskState == TaskState.UNTO){
        missionBut.GetComponentInChildren<UISprite>().spriteName = "finsh";
			}
			
			//获取奖励列表
			rewards = task.Reward.Split(TaskLang.ITEMS_DELIMITER);
			//如果奖励列表不为空循环取出奖励信息
			if(rewards.Length > 0){
				foreach(string reward in rewards){
					//如果奖励信息不为空则显示
					if(reward.Length == 0 ){
						continue;
					}
					//分解奖励信息
					string[] rewardInfo = reward.Split(TaskLang.ITEM_DELIMITER);
					int rewardTypeIndex = int.Parse(rewardInfo[0]);
					RewardTypeEnum rewardType = (RewardTypeEnum)rewardTypeIndex;
					int rewardNum = int.Parse(rewardInfo[1]);
					int rewardId = int.Parse(rewardInfo[2]);
					switch(rewardType){
						case RewardTypeEnum.EXP:
							this.SetExp(rewardNum);
							break;
						case RewardTypeEnum.SILVERINGOT:
							this.SetSilver(rewardNum);
							break;
						case RewardTypeEnum.MONEY:
							this.SetCoin(rewardNum);
							break;
						case RewardTypeEnum.GOLDINGOT:
							this.SetGold(rewardNum);
							break;
						case RewardTypeEnum.ITEM:
							this.AddGood(rewardNum,rewardId);
							break;
					}
				}
			}
			
		}
		/// <summary>
		/// 设置获得多少经验
		/// </summary>
		/// <param name="num"></param>
		public void SetExp(int num){
			this.expLabel.SetActive(true);
			this.expValue.SetActive(true);
			expValue.GetComponent<UILabel>().text = num.ToString();
		}
		/// <summary>
		/// 设置获得多少铜币
		/// </summary>
		/// <param name="num"></param>
		public void SetCoin(int num){
			this.goldLabel.SetActive(true);
			this.goldValue.SetActive(true);
			goldLabel.GetComponent<UILabel>().text = GlobalLang.COPPER;
			goldValue.GetComponent<UILabel>().text = num.ToString();
		}
		/// <summary>
		/// 设置金币
		/// </summary>
		/// <param name="num"></param>
		public void SetGold(int num){
			this.goldLabel.SetActive(true);
			this.goldValue.SetActive(true);
			goldLabel.GetComponent<UILabel>().text = GlobalLang.GOLDINGOT;
			goldValue.GetComponent<UILabel>().text = num.ToString();
		}
		/// <summary>
		/// 设置银币
		/// </summary>
		/// <param name="num"></param>
		public void SetSilver(int num){
			this.goldLabel.SetActive(true);
			this.goldValue.SetActive(true);
			goldLabel.GetComponent<UILabel>().text = GlobalLang.SILVERINGOT;
			goldValue.GetComponent<UILabel>().text = num.ToString();
		}
		
		/// <summary>
		/// 添加一个奖励物品
		/// </summary>
		/// <param name="rewardId">物品ID</param>
		/// <param name="rewardNum">物品数量</param>
		public void AddGood(int goodId,int rewardId){
			GameObject prefabs = PrefabCache.getPrefabs(typeof(HItem).Name);
			GameObject item = NGUITools.AddChild(itemGrid,prefabs);
			HItem hItem = item.GetComponent<HItem>();
			hItem.numLabel.text = goodId.ToString();
			itemGrid.GetComponent<UIGrid>().repositionNow = true;
		}
		
	}
}

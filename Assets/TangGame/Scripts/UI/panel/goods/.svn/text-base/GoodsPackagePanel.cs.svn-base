using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using nh.ui.basePanel;
using TangGame;
using TangGame.Net;
using TangGame.Xml;
using System;
using nh.ui.mediator;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.model.vo;
namespace nh.ui.panel
{
	/// <summary>
	/// 背包面板
	///create by huxiaobo
	/// </summary>
	public class GoodsPackagePanel : MonoBehaviour
	{
		public GameObject gainBut;		//获得按钮
		public GameObject tidyBut;		//整理按钮
		public GameObject bagGrid;		//背包格子容器
		public GameObject BigItem;		//道具图标
		public GameObject bindLabel;	//绑定文字
		public GameObject nameLabel;	//道具名字
		public GameObject itemCountLabel;//道具数量
		public GameObject typeLabel;	//道具类型
		public GameObject itemDes;		//道具描述
		public GameObject copperLabel;	//铜币
		public GameObject silverLabel;	//银币
		public GameObject goldLabel;	//金币
		public GameObject showBut;		//展示按钮
		public GameObject discardedBut;	//丢弃按钮
		public GameObject useBut;		//使用按钮
		public GameObject arrangeCooldown;//arrange cooldown
		private UISprite cooldownSprite;

		public GameObject dragPanel;
		private GameObject bagTable;
		private List<GameObject> itemTables;
		private int itemCount = 0;
		private GoodsPackagePanelMediator mediator;
		private int preClickItemPos = -1;
		private HItem preClickItem;
		
		public int PreClickItemPos {
			get { return preClickItemPos; }
			set { preClickItemPos = value; }
		}
		void Awake ()
		{
			mediator = new GoodsPackagePanelMediator(this);
			Facade.Instance.RegisterMediator(mediator);
		}
		void Start ()
		{
			itemTables = new List<GameObject>();
			bagTable = bagGrid.transform.Find("bagTable").gameObject;
			this.CreateItem(bagTable);
			itemTables.Add(bagTable);	
			this.InitPanel();		
			cooldownSprite = arrangeCooldown.GetComponent<UISprite>();
			//更新整理冷却显示
			HeroNew hero = ActorCache.GetLeadingHero();
			double now = GlobalFunction.GetCurrentTime();
			if (hero != null && hero.arrangeCooldown > now)//如果还未过期
			{			
				this.UpdateArrangeCooldown(hero.arrangeCooldown);
			}
			this.AddEvent();
//			Debug.LogWarning("GoodsPackPanel is Start");
		}
		/// <summary>
		/// 初始化面板显示
		/// </summary>
		private void InitPanel()
		{
			int page = 5;
			page--;
			for(int i = 0; i < page; i++)//根据玩家拥有的背包页数初始化页面
			{
				this.CreateGridTable();
			}
			
			this.UpdateHeroMoney();
			preClickItemPos = -1;
			//清空细节显示
			this.ShowItemDetail(-1, 0);	
			
			foreach(GoodsInfo info in GoodsCache.packDic.Values)
			{
				this.UpdateItemInfo(info);
			}
		}
		
		
		/// <summary>
		/// Creates itemTable
		/// </summary>
		private void CreateGridTable()
		{
			GameObject go = NGUITools.AddChild(bagGrid, bagTable);
			itemTables.Add(go);		
			bagGrid.GetComponent<UIGrid>().repositionNow = true;	
		}
		/// <summary>
		/// 创建背包道具
		/// </summary>
		/// <param name="table"></param>
		private void CreateItem(GameObject table)
		{
			GameObject prefabs = PrefabCache.getPrefabs(typeof(HItem).Name);
			for (int j = 0; j < 15; j++)
			{	
				GameObject item = NGUITools.AddChild(table, prefabs);
				UIDragScrollView uv = item.AddComponent<UIDragScrollView>();
				uv.scrollView = dragPanel.GetComponent<UIScrollView>();
				Vector3 localScale = item.transform.localScale;
				item.transform.localScale = new Vector3(localScale.x * 1.3f , localScale.y * 1.3f, localScale.z);
				HItem hItem = item.GetComponent<HItem>();//位置从零开始，开始叠加
				hItem.ClearData();
				hItem.ItemPos = itemCount;
				itemCount++;
				//hItem.numLabel.text = "n" + j;
				UIEventListener.Get(item).onClick+= OnItemClick;
			}
			table.GetComponent<UITable>().repositionNow = true;			
		}
		/// <summary>
		/// 更新金钱显示
		/// </summary>
		public void UpdateHeroMoney()
		{
			HeroNew hero = ActorCache.GetLeadingHero();
			long copper = hero.coin;
			long silver = hero.silver;
			long gold = hero.ingot;
			
			copperLabel.GetComponent<UILabel>().text = copper.ToString();
			silverLabel.GetComponent<UILabel>().text = silver.ToString();
			goldLabel.GetComponent<UILabel>().text = silver.ToString();
		}
		/// <summary>
		/// 更新道具显示
		/// </summary>
		/// <param name="info"></param>
		public void UpdateItemInfo(GoodsInfo info)
		{
			HItem item = this.GetHItemByPos(info.itemPos);
			if (item != null)
			{
				if (Config.itemTable.ContainsKey(info.itemIndex))
				{
					ItemData data = Config.itemTable[info.itemIndex];			
					item.ItemId = info.itemId;
					item.ItemIndex = info.itemIndex;
					item.UpdateShow(data.Icon, data.BindState == 0 ? false : true , info.itemNum, (int)info.itemCdTime, GameConsts.GOODSITEM);
					if (item.Equals(preClickItem))
						this.ShowItemDetail(info.itemIndex, info.itemNum);
				}
				
			}
		}
		/// <summary>
		/// 根据背包位置删除某个道具
		/// </summary>
		/// <param name="pos"></param>
		public void DeleteItemByPos(int pos)
		{
			HItem item = this.GetHItemByPos(pos);
			if (item != null)
			{
				if (item.ItemPos == PreClickItemPos)
					PreClickItemPos = 0;
				item.ClearData();
			}
		}
		//根据位置获取道具显示元件
		public HItem GetHItemByPos(int pos)
		{
			
			for (int i = 0; i < itemTables.Count; i++)
			{
				GameObject go = itemTables[i];
				HItem[] tfs = go.GetComponentsInChildren<HItem>();
				
				foreach(HItem hItem in tfs)
				{
					if (hItem.ItemPos == pos)
						return hItem;
				}
			}
			return null;	
		}
		/// <summary>
		/// 根据道具编号显示道具详细信息
		/// </summary>
		/// <param name="itemIndex"></param>
		public void ShowItemDetail(int itemIndex, int itemNum)
		{
			
			HItem icon = BigItem.GetComponent<HItem>();
			if (Config.itemTable.ContainsKey(itemIndex))
			{
				ItemData data = Config.itemTable[itemIndex];
				
				//显示道具大图标
				icon.UpdateShow(data.Icon, data.BindState == 1 ? true : false, itemNum, 0, GameConsts.GOODSITEM);
				//显示道具名字
				nameLabel.GetComponent<UILabel>().text = Config.GetItemColorName(data.Id);
				//显示道具数量，显示绑定与否
				itemCountLabel.GetComponent<UILabel>().text = GoodsLang.ITEM_NUM_STR + itemNum;
				bindLabel.GetComponent<UILabel>().text = (data.BindState != 0 ? GoodsLang.BINDING_ALREADY: "");
				
				typeLabel.GetComponent<UILabel>().text = Config.GetItemTypeString(data);
				//显示道具描述信息
				itemDes.GetComponent<UILabel>().text =  data.Note;
				//获取途径

			}
			else
			{
				//清空详细信息显示
				icon.ClearData();
				nameLabel.GetComponent<UILabel>().text = "";
				itemCountLabel.GetComponent<UILabel>().text = "";
				bindLabel.GetComponent<UILabel>().text = "";
				itemDes.GetComponent<UILabel>().text =  "";
			}
		}
		
		/// <summary>
		/// 物品点击处理
		/// </summary>
		/// <param name="obj"></param>
		private void OnItemClick(GameObject obj)
		{
			if (preClickItem != null)
				preClickItem.SetSelected(false);
			
			HItem item = obj.GetComponent<HItem>();
			item.SetSelected(true);
			preClickItemPos = item.ItemPos;
			preClickItem = item;
			ShowItemDetail(item.ItemIndex, item.ItemNum);
		}
		
		public void ClearPanel()
		{
			for (int i = 0; i < itemTables.Count; i++)
			{
				GameObject go = itemTables[i];
				HItem[] tfs = go.GetComponentsInChildren<HItem>();
				
				foreach(HItem hItem in tfs)
				{
					hItem.ClearData();
				}
			}
			//清空细节显示
			this.ShowItemDetail(-1, 0);	
		}
		
		#region
		private bool IsCoolDown = false;
		private double preTime;			//上次运行的时间毫秒
		private double CoolDownSpeed;	//冷却运行时间
		/// <summary>
		/// 更新背包整理冷却
		/// </summary>
		/// <param name="leaveTime">Leave time.</param>
		public void UpdateArrangeCooldown(double leaveTime)
		{
			if (leaveTime != 0)
			{
				double num = leaveTime - GlobalFunction.GetCurrentTime();
				cooldownSprite.fillAmount = 1;
				CoolDownSpeed = Convert.ToDouble(1) / num;
				preTime = GlobalFunction.GetCurrentTime();
				IsCoolDown = true;							
				tidyBut.GetComponent<UIButton>().isEnabled = false;
			}
		}
		
		
		//显示冷却
		
		void Update()
		{
			if (IsCoolDown)//如果正在冷却
			{
				double now = GlobalFunction.GetCurrentTime();
				double passTime = now - preTime;
				double moveSpeed = CoolDownSpeed * passTime;
				cooldownSprite.fillAmount -= (float)moveSpeed;
				preTime = now;
				//				Debug.LogWarning("过去" + passTime + "减少" + moveSpeed);
				if (cooldownSprite.fillAmount <= 0)
				{
					cooldownSprite.fillAmount = 0;
					tidyBut.GetComponent<UIButton>().isEnabled = true;
					IsCoolDown = false;
				}
				
			}

		}
		#endregion
		private void AddEvent()
		{
			if (gainBut != null)
				UIEventListener.Get(gainBut).onClick+= OnGainButClick;
			if (tidyBut != null)
			UIEventListener.Get(tidyBut).onClick+= OnTidyButClick;
			if (useBut != null)
			UIEventListener.Get(useBut).onClick+= OnItemUseButClick;
			if (showBut != null)
			UIEventListener.Get(showBut).onClick+= OnItemShowButClick;
			if (discardedBut != null)
			UIEventListener.Get(discardedBut).onClick+= OnDiscardedButClick;

		}

		private void OnGainButClick (GameObject obj)
		{
			
		}
		/// <summary>
		/// 背包整理
		/// </summary>
		/// <param name="obj">Object.</param>
		private void OnTidyButClick (GameObject obj)
		{
			HeroNew hero = ActorCache.GetLeadingHero ();
			double now = GlobalFunction.GetCurrentTime ();
			if (hero != null && hero.arrangeCooldown > now) {
				return;
			}
			TangNet.TN.Send (new SortPackRequest ());
		}
		/// <summary>
		/// 道具使用
		/// </summary>
		/// <param name="obj">Object.</param>
		private void OnItemUseButClick (GameObject obj)
		{
			//			GoodsPanel gp = m_Panel as GoodsPanel;
			if (PreClickItemPos >= 0) {
				HItem item = GetHItemByPos (PreClickItemPos);
				TangNet.TN.Send (new UseGoodsRequest (item.ItemIndex, item.ItemPos, 5));
			}
		}
		/// <summary>
		/// 道具展示
		/// </summary>
		/// <param name="obj">Object.</param>
		private void OnItemShowButClick (GameObject obj)
		{
			
		}
		/// <summary>
		/// 丢弃道具处理
		/// </summary>
		/// <param name="obj">Object.</param>
		private void OnDiscardedButClick (GameObject obj)
		{
			//			GoodsPanel gp = m_Panel as GoodsPanel;
			if (PreClickItemPos >= 0) {
				HItem item = GetHItemByPos (PreClickItemPos);
				
				if (Config.itemTable.ContainsKey (item.ItemIndex)) {
					ItemData data = Config.itemTable [item.ItemIndex];
					if (data.Discard == 1) {
						GlobalFunction.SendPopMessage(GoodsLang.CONFIRM_DIS_STR + data.Name + "?",MessageVo.OK_CACEL, "", NotificationIDs.ID_DiscardItemConfirm);
					}
				}
			}
		}
	}
}


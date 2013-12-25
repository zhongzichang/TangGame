/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/7
 * Time: 15:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangGame;

namespace nh.ui.basePanel
{
	/// <summary>
	/// 物品显示对象基类，包括了一些物品基础的控件
	/// create by huxiaobo
	/// </summary>
	public class HItem : MonoBehaviour
	{
		public UISprite bindSprite;		//物品绑定图标
		public UISprite itemSprite;		//物品图标
		public UISprite itemMask;		//冷却遮罩
		public UILabel  numLabel;		//数量文字
		public UISprite selectBorder;	//选中框
		private int itemNum;			//数量
		
		public int ItemNum {
			get { return itemNum; }
			set { itemNum = value; }
		}
		private int itemPos;			//道具所在的位置索引
		
		private bool isCoolDown;		//是否正在冷却
		private double preTime;			//上次运行的时间毫秒
		private double CoolDownSpeed;	//冷却运行时间
		private int itemIndex;
		private long itemId;
		
		public long ItemId {
			get { return itemId; }
			set { itemId = value; }
		}
		
		public int ItemIndex {
			get { return itemIndex; }
			set { itemIndex = value; }
		}
		
		public bool IsCoolDown {
			get { return isCoolDown; }
			set { isCoolDown = value; }
		}
		public int ItemPos {
			get { return itemPos; }
			set { itemPos = value; }
		}
		void Start()
		{
//			this.ClearData();
			NGUITools.AddWidgetCollider(this.gameObject);
//			this.gameObject.AddComponent<UIDragPanelContents>();
			this.SetSelected(false);
		}
		/// <summary>
		/// 清除道具数据显示
		/// </summary>
		public void ClearData()
		{
			ItemId = 0;
			ItemIndex = 0;
			ItemNum = 0;
			bindSprite.enabled = false;
			itemSprite.enabled = false;
			numLabel.text = "";
			this.ClearCoolDown();
		}
		
		/// <summary>
		/// 更新道具基础显示
		/// </summary>
		/// <param name="icon"></param>
		/// <param name="isBind"></param>
		/// <param name="num"></param>
		public void UpdateShow(int icon, bool isBind, int num, int cdTime, string type)
		{
			GameObject prefab = null;
			switch(type)
			{
			case GameConsts.GOODSITEM://道具
				prefab = PrefabCache.getIconPrefabs(GameConsts.ITEM_ATLAS, GameConsts.ITEM_PATH);
				break;
			case GameConsts.SKILLITEM://技能
				prefab = PrefabCache.getIconPrefabs(GameConsts.SKILL_ATLAS, GameConsts.SKILL_PATH);
				break;
			}
			UIAtlas atlas = prefab.GetComponent<UIAtlas>();
			itemSprite.atlas = atlas;
			itemSprite.spriteName = icon.ToString();
			itemSprite.enabled = true;
			
			if (!isBind)
				bindSprite.enabled = false;
			else
				bindSprite.enabled = true;
			ItemNum = num;
			if (num > 1)
				numLabel.text = num.ToString();
			else
				numLabel.text = "";
			//显示冷却
			if (cdTime != 0)
			{
//				CoolDownSpeed = 1 / cdTime;				
//				TimeSpan ts = DateTime.Now - DateTime.Parse("1970-1-1");				
//				preTime = ts.TotalMilliseconds;
//				IsCoolDown = true;	

				CoolDownSpeed = Convert.ToDouble(1) / cdTime;
				preTime = GlobalFunction.GetCurrentTime();
				IsCoolDown = true;		
			}	
		}
		/// <summary>
		/// 清除冷却显示
		/// </summary>
		private void ClearCoolDown()
		{
			itemMask.fillAmount = 0;
			IsCoolDown = false;
			CoolDownSpeed = 0;
			preTime = 0;
		}
		void Update()
		{
			if (IsCoolDown)//如果正在冷却
			{
				double now = GlobalFunction.GetCurrentTime();
				double passTime = now - preTime;
				double moveSpeed = CoolDownSpeed * passTime;
				itemMask.fillAmount -= (float)moveSpeed;
				preTime = now;
				//				Debug.LogWarning("过去" + passTime + "减少" + moveSpeed);
				if (itemMask.fillAmount <= 0)
				{
					itemMask.fillAmount = 0;
					IsCoolDown = false;
				}
				
			}
//			if (IsCoolDown)//如果正在冷却
//			{
//				TimeSpan ts = DateTime.Now - DateTime.Parse("1970-1-1");
//				
//				double now = ts.TotalMilliseconds;
//				double passTime = now - preTime;
//				double moveSpeed = CoolDownSpeed * passTime;
//				itemMask.fillAmount -= (float)moveSpeed;
//				if (itemMask.fillAmount <= 0)
//				{
//					itemMask.fillAmount = 0;
//					IsCoolDown = false;
//				}
//			
//			}
		}
		public void SetSelected(bool bo)
		{
			selectBorder.GetComponent<UISprite>().enabled = bo;
		}
	}
}

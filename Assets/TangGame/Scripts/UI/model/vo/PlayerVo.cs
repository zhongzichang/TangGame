using System;
using UnityEngine;
using System.Collections;
using TangGame.Net;

namespace nh.ui.model.vo
{
	public class PlayerVo{
		private int hp;
		/// <summary>
		/// 当前魔法值
		/// </summary>
		private int mp;
		/// <summary>
		/// 人物最大血量
		/// </summary>
		private int hpMax;
		/// <summary>
		/// 人物最大魔法值
		/// </summary>
		private int mpMax;
		/// <summary>
		/// 头像图标
		/// </summary>
		private int headIcon;
		private int updated;
		/// <summary>
		/// 等级
		/// </summary>
		private int level;
		/// <summary>
		/// 战斗模式
		/// </summary>
		private int mode;
		/// <summary>
		/// 金锭
		/// </summary>
		private long ingot;
		/// <summary>
		/// 当前经验值
		/// </summary>
		private long exp;
		/// <summary>
		/// 最大经验值
		/// </summary>
		private long expMax;
		/// <summary>
		/// 模式更新
		/// </summary>
		public int modeUpdated;
		/// <summary>
		/// 货币更新
		/// </summary>
		public int moneyUpdated;
		
		
		public long ExpMax {
			get { return expMax; }
			set { expMax = value; }
		}

		public long Exp {
			get { return exp; }
			set { exp = value; }
		}
		
		
		public long Ingot {
			get { return ingot; }
			set { ingot = value; }
		}
		
		public int Updated {
			get { return updated; }
			set { updated = value; }
		}
		public int Hp {
			get { return hp; }	
			set { hp = value; }
		}
		public int Mp {
			get { return mp; }
			set { mp = value; }
		}
		public int HpMax {
			get { return hpMax; }
		}
		public int MpMax {
			get { return mpMax; }
		}
		public int HeadIcon {
			get { return headIcon; }
		}
		public int Level{
			get { return level;}
		}
		public int Mode {
			get { return mode; }
			set { mode = value; }
		}
		/// 更新物品
		public void UpdateData(HeroNew hero)
		{
			Debug.Log("UpdateData " + headIcon);
			hp = hero.hp;
			mp = hero.mp;
//			headIcon = hero.headIcon;
			mpMax = hero.mpMax;
			hpMax = hero.hpMax;
			level=hero.level;
			mode=hero.portraitMode;
			ingot=hero.ingot;
			exp=hero.exp;
			expMax=hero.expMax;
			
			/// <summary>
			/// 更新标识
			/// </summary>
			/// <param name="loaclIndex"></param>
			/// <returns></returns>
			updated++;
			modeUpdated++;
			moneyUpdated++;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="loaclIndex"></param>
		/// <returns></returns>
		public bool UpDated(ref int loaclIndex){
			if(loaclIndex!=this.updated){
				loaclIndex=this.updated;
				return true;
			}
			return false;
		}
		public bool MoenyUpDated(ref int loaclIndex){
			if(loaclIndex!=this.moneyUpdated){
				loaclIndex=this.moneyUpdated;
				return true;
			}
			return false;
		}
		public bool ModeUpDated(ref int loaclIndex){
			if(loaclIndex!=this.modeUpdated){
				loaclIndex=this.modeUpdated;
				return true;
			}
			return false;
		}
		
		
		/// 获得一个新的物品
//		public static PlayerVo FromData(Hero hero)
//		{
//			PlayerVo player = new PlayerVo();
//			player.UpdateData(hero);
//			return player;
//		}
	}
}


		
		
		
		
		
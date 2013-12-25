using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using nh.ui.basePanel;
using TangGame;
using TangGame.Net;
using TangGame.Xml;
using System;
namespace nh.ui.panel
{
	/// <summary>
	/// 背包面板
	///create by huxiaobo
	/// </summary>
	public class GoodsPanel : BasePanel
	{
		public GameObject bagBut;		//背包按钮
		public GameObject shopBut;		//商店按钮
		public GameObject compoundBut;	//合成按钮
		public GameObject auctionBut;	//挂售按钮
		public GameObject temporaryBagBut;		//临时背包按钮

		void Start()
		{
			DynamicBindUtil.BindToggleObjects(bagBut);
		}

	}
}


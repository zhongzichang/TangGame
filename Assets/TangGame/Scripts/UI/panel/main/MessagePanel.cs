/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/12
 * Time: 14:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using nh.ui.model.vo;
using nh.ui.basePanel;

namespace nh.ui.main
{
	/// <summary>
	/// 弹出消息面板
	/// </summary>
	public class MessagePanel : BasePanel
	{
		public GameObject msgTitle;
		public GameObject msgContent;
		public GameObject okBut;
		public GameObject cancelBut;
		public GameObject oneOkBut;
		public MessagePanel()
		{
		}
		void Start()
		{
			NGUITools.AddWidgetCollider(this.gameObject);
			
		}
		public void UpdateMessage(MessageVo vo)
		{
			msgTitle.GetComponent<UILabel>().text = vo.title;
			msgContent.GetComponent<UILabel>().text = vo.content;
			if (vo.showMode == MessageVo.OK_CACEL)
			{
				okBut.SetActive(true);
				cancelBut.SetActive(true);
				oneOkBut.SetActive(false);
			}
			else
			{
				okBut.SetActive(false);
				cancelBut.SetActive(false);
				oneOkBut.SetActive(true);
			}
		}
	}
}

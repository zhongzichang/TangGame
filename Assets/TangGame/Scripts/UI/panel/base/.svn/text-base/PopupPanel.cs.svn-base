/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/4
 * Time: 20:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

namespace nh.ui.basePanel
{
	/// <summary>
	/// Description of PopupPanel.
	/// </summary>
	public class PopupPanel : BasePanel
	{
		private static PopupPanel preShowPanel = null;	
		public PopupPanel()
		{
		}
		
		/// <summary>
		/// 直接显示弹出面板，这个面板应该是被添加到舞台上过的
		/// </summary>
		override public void ShowPanel()
		{	
			if (preShowPanel)
				preShowPanel.HidePanel();			
			base.ShowPanel();
			preShowPanel = this;
		}
		/// <summary>
		/// 显示面板到某一个父容器上面
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		override public void ShowPanel(GameObject parent)
		{
			if (preShowPanel)
				preShowPanel.HidePanel();
			base.ShowPanel(parent);	
			preShowPanel = this;
		}
	}
}

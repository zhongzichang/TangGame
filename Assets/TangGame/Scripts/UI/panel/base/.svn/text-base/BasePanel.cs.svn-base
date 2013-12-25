using UnityEngine;
using System.Collections;

namespace nh.ui.basePanel
{
	/// <summary>
	/// 弹出面板基类
	/// create by huxiaobo
	/// 2013.11.1
	/// </summary>
	public class BasePanel : MonoBehaviour
	{
		//面板是否显示
		public bool m_IsShow {
			get { return gameObject.activeSelf; }
		}
		public void BindScriptFinish()
		{
			this.InitPanel();
		}
		virtual public void InitPanel()
		{
			Debug.LogWarning("InitPanel函数必须要由子类实现");
		}
		/// <summary>
		/// 直接显示弹出面板，这个面板应该是被添加到舞台上过的
		/// </summary>
		virtual public void ShowPanel()
		{		
      if (gameObject){
        gameObject.SetActive(true);    
      }
		}

		/// <summary>
		/// 显示面板到某一个父容器上面
		/// </summary>
		/// <param name='parent'>
		/// Parent.
		/// </param>
		virtual public void ShowPanel(GameObject parent)
		{
			if (gameObject == null || parent == null)
				return;		

			Transform t = gameObject.transform;
			t.parent = parent.transform;
			t.localPosition = Vector3.zero;
			t.localRotation = Quaternion.identity;
			t.localScale = Vector3.one;
			gameObject.layer = parent.layer;
		
			gameObject.SetActive(true);
		}

		/// <summary>
		/// 隐藏面板
		/// </summary>
		public void HidePanel()
		{
			if(gameObject.activeSelf){
        // please put SetActive into a Coroutine.
			  StartCoroutine(HidePanelRoutine());
      }
		}

		IEnumerator HidePanelRoutine()
		{
      if (gameObject == null) {
        yield return 0;
      }else{
        gameObject.SetActive(false);
      }
		}
	}
}


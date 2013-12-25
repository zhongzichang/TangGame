using UnityEngine;
using System.Collections;
using nh.ui.main;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;

public class ExpFlyEffect : MonoBehaviour {
//	
//	public GameObject expPanel;
	// 使用这个函数初始化
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void AtEffectFinish()
	{
		this.StartCoroutine(HideEffect());
		Facade.Instance.SendNotification(NotificationIDs.ID_ShowExpEffectFinish);
	}
	IEnumerator HideEffect()
	{
		yield return true;
		if (this.gameObject != null)
		{		
			this.gameObject.SetActive(false);
		}
	}
}

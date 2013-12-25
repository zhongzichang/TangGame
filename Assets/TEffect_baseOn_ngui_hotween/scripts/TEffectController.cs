using UnityEngine;
using System.Collections;

namespace zyhd.TEffect{
	[ExecuteInEditMode]
	public class TEffectController : MonoBehaviour {
	
		public GameObject atals;
		public GameObject prefab;
		public GameObject fontLabel;
		public GameObject itemPrefab;
		
		private int effNum = 0;
		private int logoNum = 0;
		private int textNum = 0;
		void Start () {
			MyCache.root = gameObject;
			MyCache.uiRoot = NGUITools.FindInParents<UIRoot>(gameObject);
			if(itemPrefab) MyCache.itemPrefab = itemPrefab;
			if(atals){
				MyCache.usedAtlas = atals.GetComponent<UIAtlas>();
			}
			if(fontLabel){
				MyCache.labelObj = fontLabel;
			}
			if(transform.parent){
				gameObject.layer = transform.parent.gameObject.layer;
			}
			if(gameObject.GetComponent<TETMono>() == null) gameObject.AddComponent<TETMono>();
		}
		
		// Update is called once per frame
		void Update () {
			if(effNum != MyCache.effQueueNum){
				effNum = MyCache.effQueueNum;
				while(MyCache.effQueue.Count > 0){
					TEffect eff = MyCache.effQueue.Dequeue () as TEffect;
					TEffectFactory.GetInstance().InitEffect(eff);
				}
			}
			if(logoNum != MyCache.logoQueueNum){
				logoNum = MyCache.logoQueueNum;
				while(MyCache.logoQueue.Count > 0){
					TEffect eff = MyCache.logoQueue.Dequeue () as TEffect;
					TEffectFactory.GetInstance().InitEffect(eff);
				}
			}
			if(textNum != MyCache.textQueueNum){
				logoNum = MyCache.textQueueNum;
				while(MyCache.textQueue.Count > 0){
					TEffect eff = MyCache.textQueue.Dequeue () as TEffect;
					TEffectFactory.GetInstance().ShowTextTEffect(eff);
				}
			}
		}
	}
}
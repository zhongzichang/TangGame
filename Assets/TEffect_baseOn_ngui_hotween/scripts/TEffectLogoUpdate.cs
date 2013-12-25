using UnityEngine;
using System.Collections;

namespace zyhd.TEffect{
	public class TEffectLogoUpdate : MonoBehaviour {
	
		[HideInInspector]public GameObject target;
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			if(target){
				Vector3 temp = Camera.main.WorldToViewportPoint(target.transform.position);
				transform.localPosition = new Vector3((temp.x-0.5f)*Screen.width ,(temp.y-0.5f)*Screen.height,0f);
			}
		}
	}
}

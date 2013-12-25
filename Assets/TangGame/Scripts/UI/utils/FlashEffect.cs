using UnityEngine;
using System.Collections;

public class FlashEffect : MonoBehaviour {

	float currentTime = 0;
	float totalTime = 1f;
//	float stepTime = 0.5f;
	
	float alphaValue = 1f;
	UISprite sp;
	void Start () {
		sp = transform.GetComponent<UISprite>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTime >= totalTime) currentTime = 0f;
		if(currentTime < totalTime){
			currentTime += Time.deltaTime;
			alphaValue =1f - currentTime / totalTime ;
			if(sp){
				sp.alpha = alphaValue;
			}
		}
	}
	
	void OnEnable(){
		sp = transform.GetComponent<UISprite>();
	}
}

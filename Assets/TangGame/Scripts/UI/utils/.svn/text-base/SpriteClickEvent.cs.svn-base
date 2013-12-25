using UnityEngine;
using System.Collections;

public class SpriteClickEvent : MonoBehaviour {
	
	private Object param;
	private SpriteEventType mType;
	// Use this for initialization
	bool addEvent = false;
	UIEventListener listener;
	private bool showTips = false;
	void Start () {
		listener = UIEventListener.Get (gameObject);
//		if(!addEvent && mType != null){
//			AddMyClickEvent ();
//			addEvent = true;
//		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	void AddMyClickEvent(){
		if(mType == null) return;
		switch(mType){
		case SpriteEventType.NameLink:
			listener.onClick += NameLinkClick;
			break;
		case SpriteEventType.GoodsLink:
			listener.onClick += GoodsLinkClick;
			break;
		}
	}
	public enum SpriteEventType{
		NameLink,GoodsLink
	}
	
	void NameLinkClick(GameObject obj){
		if(param == null) return;
		if(showTips) return;
		showTips = true;
		UILabel lab = param as UILabel;
		Debug.Log (NGUITools.StripSymbols (lab.text));
//		GameObject tips = NGUITools.AddChild(NGUITools.GetRoot (gameObject).transform.GetChild (0).GetChild (0).GetChild (1).gameObject);
		GameObject tips = NGUITools.AddChild (lab.gameObject,lab.gameObject);
		UILabel tip = tips.GetComponent<UILabel>();
		tip.depth = 11;
		tip.text = "点点点点，点你妹啊点";
		tips.transform.localPosition = new Vector3(30,-30,0);
		NGUITools.AddWidgetCollider (tips);
		UIEventListener.Get (tips).onClick += GoodsLinkClick;
	}
	void GoodsLinkClick(GameObject obj){
		GameObject.Destroy (obj);
		showTips = false;
	}
	public void SetClickEvent(SpriteEventType mType,Object param){
		if(listener ==null) listener = UIEventListener.Get (gameObject);
		this.param = param;
		switch(mType){
		case SpriteEventType.NameLink:
			listener.onClick += NameLinkClick;
			break;
		case SpriteEventType.GoodsLink:
			listener.onClick += GoodsLinkClick;
			break;
		}
	}
}

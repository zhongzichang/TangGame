/**
 * select Player effect event
 *
 * Date: 2013/11/21
 * Author: zzc
 */
using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using TangGame;

public class SelectPlayerEffectEvent : MonoBehaviour {
	
  [HideInInspector] public GameObject chat;
  [HideInInspector] public GameObject selectList;
  [HideInInspector] public UIGrid grid;
  //	[HideInInspector] public MonoBehaviour toDo;
  //	[HideInInspector] public long toDoId = 0;
  [HideInInspector] public string toDoId = "";
  UIEventListener listener;
  float time = 0;
  void Start () {
    listener = UIEventListener.Get (gameObject);
    listener.onClick += MyOnClick;
  }
	
  // Update is called once per frame
  void Update () {
	time += Time.deltaTime;
	if(time > 8){
		HideEffect();
	}
  }
	
  void MyOnClick(GameObject go){
    chat.SetActive (true);
    foreach(Transform tran in grid.gameObject.transform){
      Destroy(tran.gameObject);
    }
    SelectPlayerEffect.doEffect = false;
    SelectPlayerEffect.players.Clear ();
    selectList.GetComponentInChildren<UIScrollView>().SetDragAmount(0,0,false);
    selectList.SetActive (false);
    
    // edit by zzc
    // 修改冲刺逻辑
    BattleHelper.SprintTrace( long.Parse(toDoId) );
  }
  
  void HideEffect(){
  	if(NGUITools.GetActive(chat)) return;
  	chat.SetActive (true);
    foreach(Transform tran in grid.gameObject.transform){
      Destroy(tran.gameObject);
    }
    SelectPlayerEffect.doEffect = false;
    SelectPlayerEffect.players.Clear ();
    selectList.GetComponentInChildren<UIScrollView>().SetDragAmount(0,0,false);
    selectList.SetActive (false);
  }
}

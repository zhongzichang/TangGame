/**
 * Select Player Effect
 *
 * Date: ?
 * Author: yc
 *
 * Date: 2013/11/21
 * Edit: zzc
 * Desc: 修改因为冲刺使用的参数变化而引起的问题
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TangGame.View;
using Holoville.HOTween;
using TangNet;
using TangGame;
using TangUtils;
using TGX = TangGame.Xml;
using TGN = TangGame.Net;
using TS = TangScene;

public class SelectPlayerEffect : MonoBehaviour {

  //	[HideInInspector] public static ArrayList players = new ArrayList();
  [HideInInspector] public static List<long> players = new List<long>();
  //	private List<long> players = new List<long>();
  static private SelectPlayerEffect _instance = null;
	
  [HideInInspector] public static bool isgo = false;
  [HideInInspector] public static bool doEffect = false;
  public GameObject chatMain;
  public GameObject selectPlayerContent;
  public GameObject iconPrefab;
  public UIGrid playerList;
  public GameObject point1;
  public GameObject point2;
  public GameObject point3;
  GameObject itemRoot;
  ArrayList mList = new ArrayList();
	
  public static SelectPlayerEffect Instance {
    get {
      return _instance;
    }
  }
	
  void Start () {
    itemRoot = new GameObject("itemRoot");
    _instance = this;
  }
	
  public void DoEffect(){
    players = ActorCache.swipeHeroIds;
    //		Debug.Log (players.Count +":"+doEffect);
    if(players.Count < 1) return;
    if(!doEffect) DoEffectOO ();
  }
	
  // Update is called once per frame
  void Update () {

    //		if(players.Count > 0 && !doEffect){
    //			doEffect = true;
    //		}
  }
	
  //	void initPlayer(){
  //		if(LevelCache.swipedActorPlanes.Count == 0) return;
  //		doEffect = true;
  //		List<ActOnPlaneBehaviour>.Enumerator e = LevelCache.swipedActorPlanes.GetEnumerator ();
  //		while(e.MoveNext ()){
  ////			players.Add (e.Current.Actor);
  //			players.Add (e.Current);
  //		}
  //		DoEffect ();
  //	}
	
  void DoEffectOO(){

    doEffect = true;
    int count = players.Count;
    //		Debug.Log (count+"~~~~1");
    if(count == 1){

      ActorCache.targetActorId = players[0];
      BattleHelper.SprintTrace(players[0]);
      players.Clear ();
      doEffect = false;
      //			Debug.Log (count+"~~~~2");
      return;
    }
    //		Debug.Log (count+"~~~~3");
    foreach(long idToDo in players){
      GameObject icon = NGUITools.AddChild (gameObject,iconPrefab);
      icon.SetActive (true);
      IconPrefabContent ipc = icon.GetComponent<IconPrefabContent>();
      //			ipc.name.text = TangScene.TS.GetActorGameObject();
      ipc.name.text = ActorCache.actors[idToDo].name;
      ipc.level.text = "";
			
      icon.transform.localPosition = GetScreenPosition (TangScene.TS.GetActorGameObject(idToDo).transform.position);
      //			icon.AddComponent<UIPanel>();
      SelectPlayerEffectEvent se = icon.AddComponent<SelectPlayerEffectEvent>();
      se.chat = chatMain;
      se.selectList = selectPlayerContent;
      se.grid = playerList;
      se.toDoId = idToDo.ToString ();
      //			LevelCache.Actors.TryGetValue (vo.Id,out vo);
      mList.Add (icon);
		
    }	
    players.Clear ();
    SetAnimation ();
  }
  private Vector3 GetScreenPosition(Vector3 targetPosition){
    Vector3 temp = Camera.main.WorldToViewportPoint(targetPosition);
    return new Vector3((temp.x-0.5f)*Screen.width ,(temp.y-0.5f)*Screen.height,0f);
  }
  private void SetAnimation(){
		
    for(int i = 0;i < mList.Count;i++){
      TweenParms type1 = new TweenParms ();
      if(i == 0){
	type1.Prop ("localPosition", point1.transform.localPosition);
      }else if(i == 1){
	type1.Prop ("localPosition", point2.transform.localPosition);
      }else{
	type1.Prop ("localPosition", point3.transform.localPosition);
      }
      type1.Ease (EaseType.Linear);
      if(i == mList.Count-1){
	type1.OnComplete (AfterAnimation);
      }
      GameObject go = mList[i] as GameObject;
      HOTween.To (go.transform,0.36f,type1);
    }
  }

  void AfterAnimation(){
    chatMain.SetActive (false);
    selectPlayerContent.SetActive (true);
    foreach(GameObject go in mList){
      NGUITools.AddWidgetCollider( NGUITools.AddChild (playerList.gameObject,go));
      GameObject.Destroy(go);
			
      //			go.transform.parent = playerList.gameObject.transform;
      //			go.transform.localPosition = Vector3.zero;
      //			go.transform.localScale = Vector3.one;
      //			NGUITools.AddWidgetCollider (go);

    }
    PanelUtils.RepositionUnderBounds (playerList.transform);
    mList.Clear ();
    playerList.repositionNow = true;
  }             
}

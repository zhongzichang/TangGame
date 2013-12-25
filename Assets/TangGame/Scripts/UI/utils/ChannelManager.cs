using UnityEngine;
using System.Collections;
using TangGame.View;

public class ChannelManager : MonoBehaviour {

	private UIGrid mGrid;
	private UIScrollView itemList;
	private Queue mQueue;

	public UIGrid ChannelGrid{
		set{
			mGrid = value;
		}
		get{
			return mGrid;
		}
	}
	public Queue MyQueue{
		set{
			mQueue = value;
		}
		get{
			return mQueue;
		}
	}
	
//	bool updateChat = false;
//	int lastUpdated = -1;
	public Transform msgItem;
//	public delegate void ChannelUpdateDelegate();
	void OnEnable(){
		if(itemList){
			if(itemList.verticalScrollBar.barSize < 1) DragListViewToDown();
		}
	}
	void OnDisable(){
		
	}
	void Start () {
		itemList = gameObject.GetComponent<UIScrollView>();
		mGrid = gameObject.GetComponentInChildren<UIGrid>();
	}
	
	// Update is called once per frame
	void Update () {
		MsgListUpdateListener();
	}
	
	public void MsgListUpdateListener(){
    	float sv=itemList.verticalScrollBar.scrollValue;
        if(sv>0.9||sv==0) {
			while(mQueue .Count>0) {
				ChatVo chat;
				chat=mQueue.Dequeue() as ChatVo;
				AddMsgItem (ChatUtils.ParseChatVo (chat,msgItem.gameObject)) ;
			}
        }

    }
//	public void MsgListUpdateListener1(){
//    	float sv=itemList.verticalScrollBar.scrollValue;
//        if(sv>0.9||sv==0) {
//        	if(dth.ChatCache.GetUpdatedState(ref lastUpdated)) {
//	        	Queue queue=dth.ChatCache.queue;
//		        while(queue.Count>0) {
//			        dth.ChatVo chat;
//			        chat=queue.Dequeue() as dth.ChatVo;
//					AddMsgItem (ChatUtils.ParseChatVo (chat,msgItem.gameObject)) ;
//		        }
//	        }
//        }
//
//    }
	
	public void AddMsgItem(GameObject chatObj)
        {
			if(chatObj == null) return;
            PanelUtils.DelGridItem(mGrid,100);
			chatObj.transform.parent = mGrid.gameObject.transform;
			chatObj.transform.localPosition = Vector3.zero;
			chatObj.transform.localScale = Vector3.one; 
            chatObj.SetActive(true);
			foreach(Transform tr in chatObj.transform){
				tr.gameObject.SetActive (true);
			}
//            chatObj.AddComponent<UIDragPanelContents>();
            NGUITools.AddWidgetCollider(chatObj);
            PanelUtils.RepositionUnderBounds(mGrid.transform,mGrid.cellHeight);
			mGrid.repositionNow = true;
			if(itemList.verticalScrollBar.barSize < 1) DragListViewToDown();

        }
	public void DragListViewToDown(){
    	itemList.verticalScrollBar.scrollValue=1;
    }
}

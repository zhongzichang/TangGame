using UnityEngine;
using System.Collections;
using TangGame.View;
using nh.ui.cache;
namespace nh.ui.chat
{
    public class OneChatContentPanel:XBPanel
    {
        public new const string NAME="OneChatContentPanel";
        /// <summary>
        /// 消息列表窗口
        /// </summary>
        public UIScrollView msgList;
        /// <summary>
        /// 消息列表
        /// </summary>
		public GameObject ListAll;
		public GameObject ListHaojiao;
		public GameObject ListWorld;
		public GameObject ListSecret;
		public GameObject ListLeague;
		public GameObject ListTeam;
		public GameObject ListSystem;
		
        public UIGrid msgGrid;
		public UIGrid channelHaojiaolGrid;
		public UIGrid channelWorldGrid;
		public UIGrid channelSecretGrid;
		public UIGrid channelLeagueGrid;
		public UIGrid channelTeamGrid;
		public UIGrid channelSystemGrid;
        /// <summary>
        /// 消息滚动条
        /// </summary>
        public UIScrollBar oneContentScorllBar;
        /// <summary>
        /// 消息Item
        /// </summary>
        public Transform msgItem;
        OneChatContentPanelMediator mediator;
        int lastUpdated=-1;
		
//		short lastChannel = 0;
		short currentChannelToShow = 0;
		GameObject lastObj;
		GameObject currentObj;
//		UIGrid lastGrid;
//		UIGrid currentGrid;
		
        void Start()
        {
            mediator=new OneChatContentPanelMediator(this);
            PanelCache.ChatPanelTable.Add(NAME,mediator);
//          DragListViewToDown();
			lastObj = ListAll;
			currentObj = ListAll;
			
			ChannelManager cm = ListAll.AddComponent<ChannelManager>();
			cm.MyQueue = NewChatCache.chatAllQueue;
			cm.msgItem = this.msgItem;
			
			cm = ListWorld.AddComponent<ChannelManager>();
			cm.MyQueue = NewChatCache.chatWorldQueue;
			cm.msgItem = this.msgItem;
        }
        void Update()
        {
			if(currentChannelToShow != NewChatCache.currentChannel){
				ChangeChannel ();
				
			}
			DistributeChat ();
//            this.MsgListUpdateListener();
        }
		
		void DistributeChat(){
			if(lastUpdated != NewChatCache.update){
				lastUpdated = NewChatCache.update;
				while(NewChatCache.chatQueue.Count > 0){
					ChatVo chat = NewChatCache.chatQueue.Dequeue () as ChatVo;
					NewChatCache.chatAllQueue.Enqueue (chat);
					switch(chat.channel){
					case ChatVo.PROPS:
						NewChatCache.chatAllQueue.Enqueue (chat);
						break;
					case ChatVo.WORLD:
						NewChatCache.chatWorldQueue.Enqueue (chat);
						break;
					case ChatVo.SECRET:
						NewChatCache.chatSecretQueue.Enqueue (chat);
						break;
					case ChatVo.CLAN:
						NewChatCache.chatLeagueQueue.Enqueue (chat);
						break;
					case ChatVo.TEAM:
						NewChatCache.chatTeamQueue.Enqueue (chat);
						break;
					case ChatVo.SYSTEM:
						NewChatCache.chatSystemQueue.Enqueue (chat);
						break;
					}
				}
			}
		}
//        void OnEnable()
//        {
//            if(msgList.verticalScrollBar.barSize < 1) DragListViewToDown();
//        }
//        /// <summary>
//        /// 刷新ListView的监听
//        /// </summary>
//        public void MsgListUpdateListener()
//        {
//            float sv=msgList.verticalScrollBar.scrollValue;
//
//            if(sv>0.9||sv==0) {
//                if(dth.ChatCache.GetUpdatedState(ref lastUpdated)) {
//                    Queue queue=dth.ChatCache.queue;
//                    while(queue.Count>0) {
//                        dth.ChatVo chat;
//                        chat=queue.Dequeue() as dth.ChatVo;
////                      mediator.AddMsgItemForGridFormChatCache(chat);
//						AddMsgItem (ChatUtils.ParseChatVo (chat,msgItem.gameObject)) ;
//                    }
//                }
//            }
//
//        }
//        /// <summary>
//        /// 添加一个消息item到msg面板
//        /// </summary>
//        /// <param name="name"></param>
//        /// <param name="msg"></param>
//        public void AddMsgItem1(string str)
//        {
//            PanelUtils.DelGridItem(msgGrid,100);
//            GameObject obj=NGUITools.AddChild(msgGrid.gameObject,msgItem.gameObject);
//            obj.SetActive(true);
//            obj.transform.localScale=msgItem.transform.localScale;
//            UILabel label=obj.GetComponent<UILabel>();
//            label.text=str;
//            obj.AddComponent<UIDragPanelContents>();
//            NGUITools.AddWidgetCollider(obj);
//            PanelUtils.RepositionUnderBounds(msgGrid.transform,msgGrid.cellHeight);
//			msgGrid.repositionNow = true;
//			if(msgList.verticalScrollBar.barSize < 1) DragListViewToDown();
//
//			
//        }
//		
//		public void AddMsgItem(GameObject chatObj)
//        {
//			if(chatObj == null) return;
//            PanelUtils.DelGridItem(msgGrid,100);
//			chatObj.transform.parent = msgGrid.gameObject.transform;
//			chatObj.transform.localPosition = Vector3.zero;
//			chatObj.transform.localScale = Vector3.one; 
//            chatObj.SetActive(true);
//			foreach(Transform tr in chatObj.transform){
//				tr.gameObject.SetActive (true);
//			}
//            chatObj.AddComponent<UIDragPanelContents>();
//            NGUITools.AddWidgetCollider(chatObj);
//            PanelUtils.RepositionUnderBounds(msgGrid.transform,msgGrid.cellHeight);
//			msgGrid.repositionNow = true;
//			if(msgList.verticalScrollBar.barSize < 1) DragListViewToDown();
//
//        }
//        /// <summary>
//        /// 拖拽ListView到底部
//        /// </summary>
//        public void DragListViewToDown()
//        {
//            msgList.verticalScrollBar.scrollValue=1;
//        }
		
		void ChangeChannel(){
//			lastChannelToShow = currentChannelToShow;
			currentChannelToShow = NewChatCache.currentChannel;
			lastObj.SetActive (false);
			switch(currentChannelToShow){
			case 0:
				ListAll .SetActive (true);
				currentObj = ListAll;
				break;
			case 1:
				ListHaojiao .SetActive (true);
				currentObj = ListHaojiao;
				break;
			case 2:
				ListWorld .SetActive (true);
				currentObj = ListWorld;
				break;
			case 3:
				ListSecret .SetActive (true);
				currentObj = ListSecret;
				break;
			case 4:
				ListLeague .SetActive (true);
				currentObj = ListLeague;
				break;
			case 5:
				ListTeam .SetActive (true);
				currentObj = ListTeam;
				break;
			case 6:
				ListSystem .SetActive (true);
				currentObj = ListSystem;
				break;
			}
			lastObj = currentObj;
		}
		
		void OnDisable(){
			
		}
        #region==============================页面测试代码==============================
//      void OnGUI(){
//          if(GUILayout.Button("刷新界面")){
//              this.AddMsgItem("葫芦娃，葫芦娃， 一根藤上七朵花。风吹雨打，都不怕，啦啦啦啦。 叮当当咚咚当当，葫芦娃，叮当当咚咚当当，本领大，啦啦啦啦。 葫芦娃，葫芦娃，本领大。 葫芦娃，葫芦娃， 一根藤上七朵花。风吹雨打，都不怕，啦啦啦啦。 叮当当咚咚当当，葫芦娃，叮当当咚咚当当，本领大，啦啦啦啦。 葫芦娃，葫芦娃，本领大。");
//          }
//      }
        #endregion
    }
}
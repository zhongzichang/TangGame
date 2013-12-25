using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.main
{
public class MsgPanel : XBPanel
{
    public new const string NAME="MsgPanel";
//		public UIScrollView msgList;
    public UIGrid msgGrid;
    public Transform msgItem;
    MsgPanelMediator mediator;
    int lastInfoUpdated=-1;
    void Start()
    {
        mediator=new MsgPanelMediator(this);
        PanelCache.MainPanelTable.Add(NAME,mediator);
        UIEventListener listener=UIEventListener.Get(bgPanel.gameObject);
        NGUITools.AddWidgetCollider(bgPanel.gameObject);
        listener.onClick+=MsgGridClick;
        transform.Find("Background").gameObject.GetComponent<UISprite>().depth = 0;
//			StartCoroutine(PanelUtils.SetDragAmountBottom(msgList));
    }

    void Update()
    {
        MsgListUpdateListener();
    }
//		void OnGUI(){
//			if(GUILayout.Button("add Item")){
//				AddMsgItem("添加一个Item，第四范式大法师打法撒的发的撒发史蒂的撒发生地范德萨士大夫大撒的撒发大师傅少掉芬森大幅打撒的");
//			}
//		}
    public void MsgListUpdateListener()
    {
//        if(dth.ChatCache.GetInfoUpdatedState(ref lastInfoUpdated))mediator.AddMsgItemForGridFormChatCache(dth.ChatCache.info2);
    }
    public void MsgGridClick(GameObject obj)
    {
        PanelCache.IController.OpentUI(UIWindow.UICHAT);
        PureMVC.Patterns.Facade.Instance.SendNotification(TangGame.NotificationIDs.ID_DisableSceneClick);
    }
    /// <summary>
    /// 添加一个消息item到msg面板
    /// </summary>
    /// <param name="name"></param>
    /// <param name="msg"></param>
    public void AddMsgItem(string str)
    {
//			PanelUtils.DelGridItem(msgGrid,3);
        StartCoroutine(PanelUtils.DelGridItem(msgGrid,3));
        GameObject obj=NGUITools.AddChild(msgGrid.gameObject,msgItem.gameObject);
        obj.SetActive(true);
        obj.transform.localScale=msgItem.transform.localScale;
        UILabel label=obj.GetComponent<UILabel>();
        label.text=str;
        PanelUtils.RepositionOnBounds(msgGrid.transform);
//			StartCoroutine(PanelUtils.SetDragAmountBottom(msgList));
    }

    #region ==============================页面测试代码==============================
//		void OnGUI(){
//			if(GUILayout.Button("刷新界面")){
//				this.AddMsgItem("葫芦娃，葫芦娃， 一根藤上七朵花。风吹雨打，都不怕，啦啦啦啦。 叮当当咚咚当当，葫芦娃，叮当当咚咚当当，本领大，啦啦啦啦。 葫芦娃，葫芦娃，本领大。 葫芦娃，葫芦娃， 一根藤上七朵花。风吹雨打，都不怕，啦啦啦啦。 叮当当咚咚当当，葫芦娃，叮当当咚咚当当，本领大，啦啦啦啦。 葫芦娃，葫芦娃，本领大。");
//			}
//		}
    #endregion
}
}

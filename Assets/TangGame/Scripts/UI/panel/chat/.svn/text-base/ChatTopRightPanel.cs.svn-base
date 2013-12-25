using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.chat
{
public class ChatTopRightPanel:XBPanel
{
    public new const string NAME="ChatTopRightPanel";
    public UIButton closePanelButton;
    ChatTopRightPanelMediator mediator;
    GameObject panel;
    void Start()
    {
        mediator=new ChatTopRightPanelMediator(this);
        PanelCache.ChatPanelTable.Add(NAME,mediator);
        UIEventListener.Get(closePanelButton.gameObject).onClick+= ClosePanelButtonClick;
        panel = transform.parent.parent.parent.gameObject;
//        TopRightPanelMediator mMedia = new TopRightPanelMediator(this);
        PureMVC.Patterns.Facade.Instance.RegisterMediator(new ChatTopRightPanelMediator(this));
    }
    void Update(){
    	
    }
    public void ClosePanelButtonClick(GameObject obj)
    {
        PanelCache.IController.OpentUI(UIWindow.UIMAIN);
        PureMVC.Patterns.Facade.Instance.SendNotification(TangGame.NotificationIDs.ID_EnableSceneClick);
    }
}
}
using UnityEngine;
using System.Collections;
using nh.ui.cache;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;
using nh.ui.model.vo;
namespace nh.ui.main
{
public class TopLeftButtonPanel : XBPanel
{
    public new const string NAME="TopLeftButtonPanel";
    public UIScrollView mainMenuButtonList;
    public UIGrid mainMenuButtonGrid;
    public UIButton mainMenuButton;
    TopLeftButtonPanelMediator mediator;

    void Start()
    {
        mediator=new TopLeftButtonPanelMediator(this);
        PanelCache.MainPanelTable.Add(NAME,mediator);
        UIEventListener.Get(mainMenuButton.gameObject).onClick+= OnMenuButtonClick;
    }
    public void OnMenuButtonClick(GameObject obj)
    {
//        PanelCache.IController.OpentUI(UIWindow.UIMENU);
		  IFacade facade = Facade.Instance;
		  facade.SendNotification(NotificationIDs.ID_OPenMainGamePanel);
//			facade.SendNotification(NotificationIDs.ID_ShowUIEffect, "expEffect");
//			facade.SendNotification(NotificationIDs.ID_ShowOrHideTargetHeadPanel);
//			facade.SendNotification(NotificationIDs.ID_ShowInfoMessage, "this is a info");
//		  MessageVo vo = new MessageVo();
//		  vo.title = "����һ������";
//		  vo.content = "�ö�ö�����";
//		  vo.showMode = MessageVo.OK_CACEL;
//		  		  facade.SendNotification(NotificationIDs.ID_ShowPopupMessage, vo);
    }
}
}

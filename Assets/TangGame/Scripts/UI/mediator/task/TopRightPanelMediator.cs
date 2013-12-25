using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.task
{
public class TopRightPanelMediator
{
    TopRightPanel panel;
    public TopRightPanelMediator(TopRightPanel viewComponent)
    {
        panel=viewComponent;
        UIEventListener.Get(panel.closePanelButton.gameObject).onClick+= ClosePanelButtonClick;
    }
    public void ClosePanelButtonClick(GameObject obj)
    {
        Debug.Log("Close the Panel");
        PanelCache.IController.OpentUI(UIWindow.UIMAIN);
    }
}
}


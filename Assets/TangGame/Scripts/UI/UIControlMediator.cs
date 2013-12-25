using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui
{
public class UIControlMediator : MonoBehaviour
{
    public Transform uiChat;
    public Transform uiMain;
    public Transform uiMenu;
    public Transform uiTask;
    void Awake()
    {
        PanelCache.IController=this;
        OpentUI(UIWindow.UIMAIN);
    }
    /// <summary>
    /// 打开指定UI窗口
    /// </summary>
    /// <param name="uiWindow"></param>
    public void OpentUI(UIWindow uiWindow)
    {
    	Transform openUi=uiMain;
        switch(uiWindow)
        {
        case UIWindow.UICHAT:
            openUi=uiChat;
            break;
        case UIWindow.UIMAIN:
            openUi=uiMain;
            break;
        case UIWindow.UIMENU:
            openUi=uiMenu;
            break;
        case UIWindow.UITASK:
            openUi=uiTask;
            break;
        }
        if(openUi.gameObject.activeSelf)return;
    	StartCoroutine(OpenUIRoutine(openUi));
    }
    
    IEnumerator OpenUIRoutine(Transform openUi)
    {
    	yield return 0;
        
        CloseAllUI();
        openUi.gameObject.SetActive(true);
    }

    /// <summary>
    /// 关闭所有UI窗口
    /// </summary>
    public void CloseAllUI()
    {
        PanelCache.IController.uiChat.gameObject.SetActive(false);
        PanelCache.IController.uiMain.gameObject.SetActive(false);
        PanelCache.IController.uiMenu.gameObject.SetActive(false);
        PanelCache.IController.uiTask.gameObject.SetActive(false);
    }

}
/// <summary>
/// UI窗口枚举
/// </summary>
public enum UIWindow
{
    UICHAT,UIMAIN,UIMENU,UITASK
}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using nh.ui.cache;
using dthbs;

namespace nh.ui.task
{
public class BodyPanel:XBPanel
{
    public new const string NAME="BodyPanel";
    public UIPanel contentPanel;
    public UIPanel oneMenuPanel;
    public UIScrollView oneMenuList;
    public UIGrid oneMenuGrild;
    /// <summary>
    /// item�ؼ�
    /// </summary>
    public Transform NormalButton;
    /// <summary>
    /// δ������ť
    /// </summary>
    public UIButton missedButton;
    /// <summary>
    /// �ѽ�����ť
    /// </summary>
    public UIButton receivedButton;

    BodyPanelMediator mediator;

    void Start()
    {
        mediator=new BodyPanelMediator(this);
        PanelCache.TaskPanelTable.Add(NAME,mediator);
//        this.mediator.RefreshMenuItems(dth.TaskCache.received);
        UIEventListener.Get(receivedButton.gameObject).onClick+=ReceivedButtonClick;
        UIEventListener.Get(missedButton.gameObject).onClick+=MissedButtonClick;
    }
    /// <summary>
    /// ������������������ʾ
    /// </summary>
    /// <param name="bl"></param>
    public void SetContentPanelActive(bool bl)
    {
        this.contentPanel.gameObject.SetActive(bl);
    }
    public ContentPanel GetContentPanel()
    {
        return this.contentPanel.GetComponent<ContentPanel>();
    }

    /// <summary>
    /// �ѽ�����ť�������
    /// </summary>
    /// <param name="obj"></param>
    private void ReceivedButtonClick(GameObject obj)
    {
//        this.mediator.RefreshMenuItems(dth.TaskCache.received);
//        this.GetContentPanel().Mediator.DefaultReceivedTaskInfo();
    }
    /// <summary>
    /// δ������ť�������
    /// </summary>
    /// <param name="obj"></param>
    private void MissedButtonClick(GameObject obj)
    {
//        this.mediator.RefreshMenuItems(dth.TaskCache.can);
//        this.GetContentPanel().Mediator.DefaultCanTaskInfo();
    }
    public void RefreshListAndDragAmountTop()
    {
        this.oneMenuGrild.repositionNow=true;
        StartCoroutine(PanelUtils.SetDragAmountTop(this.oneMenuList));
    }
}
}

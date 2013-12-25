using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.task
{
public class TopRightPanel:XBPanel
{
    public new const string NAME="TopRightPanel";
    public UIButton closePanelButton;
    TopRightPanelMediator mediator;
    void Start()
    {
        mediator=new TopRightPanelMediator(this);
        PanelCache.TaskPanelTable.Add(NAME,mediator);
    }
}
}
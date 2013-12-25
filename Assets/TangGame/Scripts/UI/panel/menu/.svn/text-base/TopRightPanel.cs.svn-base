using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.menu
{
public class TopRightPanel:XBPanel
{
    public new const string NAME="TopRightPanel";
    public UIButton closePanelButton;
    TopRightPanelMediator mediator;
    void Start()
    {
        mediator=new TopRightPanelMediator(this);
        PanelCache.MenuPanelTable.Add(NAME,mediator);
    }
}
}
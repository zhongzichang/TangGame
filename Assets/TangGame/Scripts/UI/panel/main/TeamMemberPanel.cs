using UnityEngine;
using System.Collections;

namespace nh.ui.main
{
public class TeamMemberPanel:XBPanel
{
    public new const string NAME="TeamMemberPanel";
    public UIScrollView teamMemberList;
    public UIGrid teamMemberGrid;
    public Transform TeamMemberItem;
    void Start()
    {
//			PanelCache.MainPanelTable.Add(NAME,this);
    }
}
}

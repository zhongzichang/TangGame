using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.chat
{
public class MenuPanel:XBPanel
{
    public new const string NAME="MenuPanel";
    void Start()
    {
        PanelCache.ChatPanelTable.Add(NAME,this);
    }
}
}
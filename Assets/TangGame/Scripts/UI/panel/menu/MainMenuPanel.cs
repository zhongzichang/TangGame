using UnityEngine;
using System.Collections;
using nh.ui.cache;
namespace nh.ui.menu
{
public class MainMenuPanel:XBPanel
{
    public new const string NAME="MainMenuPanel";
    public UIScrollView mainMenuList;
    public UIGrid mainMenuGrid;
    public UIButton button1;
    public UIButton button2;
    public UIButton button3;
    public UIButton button4;
    public UIButton button5;
    void Start()
    {
        PanelCache.MenuPanelTable.Add(NAME,this);
    }
}
}
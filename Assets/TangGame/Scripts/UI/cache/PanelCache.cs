using UnityEngine;
using System.Collections;
using nh.ui.cache;

namespace nh.ui.cache
{
public class PanelCache
{
    private static  UIControlMediator controller;
    public static int msgItemCountMax=200;
    public static UIControlMediator IController
    {
        get
        {
            return controller;
        }
        set
        {
            controller = value;
        }
    }
    private static Hashtable mainPanelTable=new Hashtable();
    private static Hashtable chatPanelTable=new Hashtable();
    private static Hashtable menuPanelTable=new Hashtable();
    private static Hashtable taskPanelTable=new Hashtable();

    public static Hashtable TaskPanelTable
    {
        get
        {
            IController.OpentUI(UIWindow.UITASK);
            return taskPanelTable;
        }
        set
        {
            taskPanelTable = value;
        }
    }
    public static Hashtable MainPanelTable
    {
        get
        {
            IController.OpentUI(UIWindow.UIMAIN);
            return mainPanelTable;
        }
        set
        {
            mainPanelTable = value;
        }
    }
    public static Hashtable ChatPanelTable
    {
        get
        {
            IController.OpentUI(UIWindow.UICHAT);
            return chatPanelTable;
        }
        set
        {
            chatPanelTable = value;
        }
    }
    public static Hashtable MenuPanelTable
    {
        get
        {
            Debug.Log("---------------MenuPanelTable");
            IController.OpentUI(UIWindow.UIMENU);
            return menuPanelTable;
        }
        set
        {
            menuPanelTable = value;
        }
    }
}
}

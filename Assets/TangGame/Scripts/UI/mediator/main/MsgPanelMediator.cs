using UnityEngine;
using System.Collections;

namespace nh.ui.main
{
public class MsgPanelMediator
{
    MsgPanel panel;
    public MsgPanelMediator(MsgPanel viewComponent)
    {
        panel=viewComponent;
    }


    public void AddMsgItemForGridFormChatCache(TangGame.View.ChatVo info1)
    {
        string info="";
        if(info1==null)return;
        info=ChatUtils.ParseChat(info1);
        panel.AddMsgItem(info);

    }

}
}

using UnityEngine;
using System.Collections;
using TangGame;
using TangGame.Net;
using TangGame.View;
using nh.ui.cache;
namespace nh.ui.chat
{
public class MainMenuPanelMediator
{
    MainMenuPanel panel;
    public MainMenuPanelMediator(MainMenuPanel panel)
    {
        this.panel=panel;
    }
    public void SendChatMsg()
    {
        string text = this.panel.GetInputMsg();
        if(!string.IsNullOrEmpty(text)){
				nh.ui.cache.NewChatCache.faceNum = 0;
//				foreach(GoodsVo goods in this.showGoodsList){//处理展示物品
//					string temp = "[" + goods.goodsBase.name + "]";//展示的物品也给替换了
//					//链接->#W:FF00FFFF:玩家ID,物品数据库ID,物品基础ID:物品名称#
//					text = text.Replace(temp, "#W:" + Common.GOODS_HTML_COLOR[goods.goodsBase.grade] + "FF:" + PlayerCache.player.id + "," + goods.id + "," + goods.goodsBase.id + ":" +  "【" + goods.goodsBase.name + "】#");
//				}
//				if(text.IndexOf('@') != -1){
//					NetworkCache.AddRequest(new SendMakeMsgRequest(dth.ChatVo.AREA, text.Replace("@", "")));//临时添加MAKE
//				}else{
            string whisper = null;
//					if(int.Parse(panel.channelBtn.id) == dth.ChatVo.SECRET){
//						whisper = panel.whisper.text;
//					}
//            text=ChatUtils.ChatInputReplace(text);
//            NetworkCache.AddRequest(new SendChatMsgRequest(ChatVo.WORLD, text, whisper));	
			TangNet.TN.Send (new SendChatMsgRequest(ChatVo.WORLD, text, whisper));
            this.panel.InputBoxTextClear();
            Debug.Log(text);

//				}
        }
    }
}
}

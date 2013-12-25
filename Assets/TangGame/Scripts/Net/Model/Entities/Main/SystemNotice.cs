using System;
using TangNet;
namespace TangGame.Net
{
public class SystemNotice
{

    /*
     * NetData net;
    	if(type == 1){
    		 net = NetData.createPushNetData("noticeSys");
    	}else{
    		 net = NetData.createPushNetData("notice");
    	}
    	ObjectData data = net.createObjectData();
    	data.putData(type);
    	data.putData(msgId);
    	data.putData(num);
    	ObjectData strData = data.createObjectData();
    	if(paraStr != null && paraStr.length > 0){
    		for(String str : paraStr){
    			strData.putData(str);
    		}
    	}
    	data.putData(strData);
    	net.putObjectData(data);
    	*/

    public short type;
    public short msgId;
    public short num;
    public string[] texts;

    public static SystemNotice Parse(MsgData data)
    {

        SystemNotice notice = new SystemNotice();
        notice.type = data.GetShort(0);
        notice.msgId = data.GetShort(1);
        notice.num = data.GetShort(2);

        MsgData textsData = data.GetMsgData(3);
        if(textsData != null)
        {
            notice.texts = new string[textsData.Size];
            for(int i=0; i< textsData.Size; i++)
            {
                notice.texts[i] = textsData.GetString(i);
            }
        }

        return notice;
    }
}
}


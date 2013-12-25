using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using TangGame.View;
public class ChatUtils : MonoBehaviour
{
	static string[] results;
	static int[] indexs;
	static string[] temps;
	static string[] linkResults;
	static string[] linkType;
	static string[] linkTemps;
	public static string linkSpriteName = "down";
	
	static private int FONT_SIZE = 24;
	
	/// 解析聊天信息
    public static string ParseChat1(ChatVo chat)
    {
        string result = "";
        if(chat.channel < 10 && chat.channel > 0)
        {
            result += "[" + ChatLang.CHANNEL_NAME_S[chat.channel] + "]";
        }//频道判断
        if(!string.IsNullOrEmpty(chat.fromName))
        {
            result += chat.fromName + GlobalLang.ZH_RISK;
        }

        string[] arr = chat.content.Split('#');
        foreach(string str in arr)
        {
            if(string.IsNullOrEmpty(str))
            {
                continue;
            }
            string[] tempArr = str.Split(':');
            if(tempArr.Length > 1)
            {
                result += TangUtils.TextUtil.PackColorText(tempArr[1].Substring(0, 6), tempArr[tempArr.Length - 1]);
            }
            else
            {
                result += str;
            }
        }
        return result;
    }

//	void OnGUI(){
//		if(GUILayout.Button("Hit Me!")){
//			ChatInputReplace("123456啊啊大叫覅额#R阿福额ir#c00fff sdjfkldsj #c00fffdsjkfhjdksah#c00fff dsfdsf");
//
//		}
//	}


    /// <summary>
    /// 解析聊天输入字符串
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ChatInputReplace(string str)
    {
        string[] stringArray = str.Split('#');
        string result = stringArray[0];
        for(int idx=1; idx<stringArray.Length; idx++)
        {
            string s = stringArray[idx].Insert(0, "#");
            string ss = ReplaceColor(s);
            result += ss;
        }
        Debug.Log(result);
        return result;
    }
    /// <summary>
    /// 解析16进制颜色字符
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    private static string ReplaceColor(string s)
    {
        string pattern = "#([0-9a-fA-F]{6})(.+)";
        string replacement="[$1]$2[-]";
        string newString = Regex.Replace(s, pattern, replacement);
        newString=ReplaceColor2(newString);
        return newString;
    }
    /// <summary>
    /// 解析简写颜色字符
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    private static string ReplaceColor2(string str)
    {
        int sSub=str.IndexOf('#');
        if(sSub<0)return str;
        string s=str.Substring(sSub+1,1);
        string color=GetColorAccordingABC(s);
        if(color==s)return str;
        string pattern = "#[YWGBR]{1}(.+)";
        string replacement="["+color+"]$1[-]";
        string newString=Regex.Replace(str, pattern, replacement);
        return newString;
    }
    private static string GetColorAccordingABC(string str)
    {
        Color color=Color.grey;
        switch(str)
        {
        case "Y":
            color=Color.yellow;
            break;
        case "W":
            color=Color.white;
            break;
        case "G":
            color=Color.green;
            break;
        case "B":
            color=Color.blue;
            break;
        case "R":
            color=Color.red;
            break;
        default:
            break;
        }
        if(color==Color.grey)return str;
//        return NGUITools.EncodeColor(color);
        return NGUIText.EncodeColor(color);
    }
	
	public static string ParseChat(ChatVo chat){
		string text = "";
		short channel = chat.channel;
    	string fromName = chat.fromName;
//    	long fromId = chat.fromId;
    	string content = chat.content;
    	int vipLevel = chat.vipLevel;
		text += ChannelColorAndText (channel);
		if(vipLevel > 0) text += "[FF9A00]VIP" + vipLevel +"[-] ";
		text += "[00FFFF]" +fromName+"[-]"+ GlobalLang.ZH_RISK + content;
		return text;
	}
	private static string ChannelColorAndText(short channel){
		string text = "";
		switch(channel){
		case ChatVo.WORLD:
			text = "[FFFF00]"+GlobalLang.ZH_BRACKETS_L + ChatLang.WORLD+ GlobalLang.ZH_BRACKETS_R+"[-]";
			break;
		case ChatVo.PROPS:
			text = "[FF9A00]" + GlobalLang.ZH_BRACKETS_L +ChatLang.HAOJIAO+ GlobalLang.ZH_BRACKETS_R+"[-]";
			break;
		case ChatVo.SECRET:
			text = "[FF00FF]" + GlobalLang.ZH_BRACKETS_L +ChatLang.SECRET+ GlobalLang.ZH_BRACKETS_R+"[-]";
			break;
		case ChatVo.CLAN:
			text = "[00FF00]" + GlobalLang.ZH_BRACKETS_L +ChatLang.CLAN+ GlobalLang.ZH_BRACKETS_R+"[-]";
			break;
		case ChatVo.TEAM:
			text = "[0000FF]" + GlobalLang.ZH_BRACKETS_L +ChatLang.TEAM+ GlobalLang.ZH_BRACKETS_R+"[-]";
			break;
		case ChatVo.SYSTEM:
			text = "[FF0000]" + GlobalLang.ZH_BRACKETS_L +ChatLang.SYSTEM+ GlobalLang.ZH_BRACKETS_R+"[-]";
			break;
		}
		return text;
	}
	
	public static GameObject ParseChatVo(ChatVo chat,GameObject label){
		if(chat == null) return null;
		GameObject chatItem = new GameObject("chatItem");
		short channel = chat.channel;
    	string fromName = chat.fromName;
//    	long fromId = chat.fromId;
    	string content = chat.content;
    	int vipLevel = chat.vipLevel;
		int len = 0;

		//channel show ----------------------
		string text = ChannelColorAndText(channel);
		if(vipLevel > 0) text += "[FF9A00]VIP" + vipLevel +"[-] ";
		UILabel lab = AddLabel (ref chatItem,label,len,text);
//		UILabel lab = NGUITools.AddChild (chatItem,label).GetComponent<UILabel>();
//		lab.maxLineCount = 1;
//		lab.gameObject.transform.localPosition = new Vector3(len,0,0);
//		lab.gameObject.transform.localScale = label.transform.localScale;
//		lab.text = text;
//		lab.lineWidth = GetLabelLength (text,lab,false);
		len += lab.lineWidth;
		
		// name show ---------------------
		text = "[00FFFF]" +fromName+"[-]"+ GlobalLang.ZH_RISK;
		lab = AddLabel (ref chatItem,label,len,text);
//		lab = NGUITools.AddChild (chatItem,label).GetComponent<UILabel>();
//		lab.maxLineCount = 1;
//		lab.gameObject.transform.localPosition = new Vector3(len,0,0);
//		lab.gameObject.transform.localScale = label.transform.localScale;
//		lab.text = "[00FFFF]" +fromName+"[-]"+ GlobalLang.ZH_RISK;
//		lab.lineWidth = GetLabelLength (lab.text,lab,false);
		
//		UISprite sp = NGUITools.AddSprite (chatItem,nh.ui.cache.NewChatCache.faceAtlas,"");
//		sp.pivot = UIWidget.Pivot.TopLeft;
//		sp.gameObject.transform.localPosition = new Vector3(len,0,1);
//		sp.gameObject.transform.localScale = new Vector3(lab.lineWidth,lab.gameObject.transform.localScale.y,1);
//		len += lab.lineWidth;
		UISprite sp = AddSprite (ref lab,len,ref chatItem,linkSpriteName,true);
//		Vector3 vv = sp.gameObject.transform.localScale;
		sp.width = lab.width - 24;
		SpriteClickEvent sce = sp.gameObject.AddComponent<SpriteClickEvent>();
		sce.SetClickEvent (SpriteClickEvent.SpriteEventType.NameLink,lab);
//		sce.param = lab;
//		sce.mType = SpriteClickEvent.SpriteEventType.NameLink;
		
		len += lab.lineWidth;
		//chat show -------------------
//		lab = AddLabel (ref chatItem,label,len,content);
		    //get faces
		MatchCollection mc = nh.ui.cache.NewChatCache.faceRegex.Matches (content);
		if(mc != null && mc.Count > 0){
			results = new string[mc.Count];
			for(int i = 0;i < mc.Count;i++){
//				indexs = new int[mc.Count];
				string spriteName = mc[i].Value.Replace("&","");

				if(nh.ui.cache.NewChatCache.faceAtlas.GetListOfSprites ().Contains (spriteName)){
					results[i] = spriteName;
//					indexs[i] = mc[i].Index;
					content = content.Replace (mc[i].Value,"(|)");
				}
			}

			temps = content.Split (new string[]{"(|)"},System.StringSplitOptions.None);
			if(temps.Length > 0 && temps != null){

				for(int i = 0; i < temps.Length ;i++){
					if(!string.IsNullOrEmpty(temps[i])){
//						lab = AddLabel (ref chatItem,label,len,temps[i]);
//						len += lab.lineWidth + 6;
						//get link
//						MatchCollection mc1 = nh.ui.cache.NewChatCache.linkRegex.Matches (temps[i]);
////						Debug.LogError (mc1.ToString ());
//						if(mc1 != null && mc1.Count > 0){
//							linkResults = new string[mc1.Count];
//							linkType = new string[mc1.Count];
//							for(int j = 0;j < mc1.Count;j++){
//								string[] link = mc1[j].Value.Replace ("[link]","").Split ('@');
////								string aa = mc1[j].Value.Replace ("[link]","");
////								Debug.LogError("aa:" + aa);
////								string[] link = aa.Split ('@');
//								linkType[j] = link[0];
//								linkResults[j] = link[1];
//								temps[i] = temps[i].Replace(mc1[j].Value,"(|)");
//							}
//							linkTemps = temps[i].Split (new string[]{"(|)"},System.StringSplitOptions.None);
//							if(linkTemps.Length > 0 && linkTemps != null){
//								for(int k = 0; k < linkTemps.Length ;k++){
//									if(!string.IsNullOrEmpty(linkTemps[k])){
//										lab = AddLabel (ref chatItem,label,len,linkTemps[k]);
//										len += lab.lineWidth;
//									}
//									if(k < linkResults.Length && !string.IsNullOrEmpty (linkResults[k])){
//										lab = AddLabel (ref chatItem,label,len,linkResults[k]);
//										sp = AddSprite (ref lab,len,ref chatItem,linkSpriteName,true);
//										len += lab.lineWidth;
//										//add link event
////										switch(){
////											
////										}
//									}
//								}
//							}
//						}else{
//							lab = AddLabel (ref chatItem,label,len,temps[i]);
//							len += lab.lineWidth + 6;
//						}
						ParseLink (temps[i],ref linkResults,ref linkType,ref linkTemps,ref lab,ref sp,ref len,ref chatItem,label);
					}
					if(i < results.Length && !string.IsNullOrEmpty(results[i])){
						sp = AddFaceSprite (lab.height,len,ref chatItem,results[i],false);
						len += (int)(sp.width) + 6;
					}
					
				}
			}
		}else{
//			lab = AddLabel (ref chatItem,label,len,content);
			ParseLink (content,ref linkResults,ref linkType,ref linkTemps,ref lab,ref sp,ref len,ref chatItem,label);
		}
		
		return chatItem;
	}
	private static void ParseLink(string toParse,ref string[] linkResults,ref string[] linkType,ref string[] linkTemps,ref UILabel lab,
					ref UISprite sp,ref int len,ref GameObject chatItem,GameObject label ){
		MatchCollection mc1 = nh.ui.cache.NewChatCache.linkRegex.Matches (toParse);
		if(mc1 != null && mc1.Count > 0){
			linkResults = new string[mc1.Count];
			linkType = new string[mc1.Count];
			for(int j = 0;j < mc1.Count;j++){
				string[] link = mc1[j].Value.Replace ("[link]","").Split ('@');
				linkType[j] = link[0];
				linkResults[j] = link[1];
				toParse = toParse.Replace(mc1[j].Value,"(|)");
			}
			linkTemps = toParse.Split (new string[]{"(|)"},System.StringSplitOptions.None);
			if(linkTemps.Length > 0 && linkTemps != null){
				for(int k = 0; k < linkTemps.Length ;k++){
					if(!string.IsNullOrEmpty(linkTemps[k])){
						lab = AddLabel (ref chatItem,label,len,linkTemps[k]);
						len += lab.lineWidth;
					}
					if(k < linkResults.Length && !string.IsNullOrEmpty (linkResults[k])){
						lab = AddLabel (ref chatItem,label,len,linkResults[k]);
						sp = AddSprite (ref lab,len,ref chatItem,linkSpriteName,true);
						len += lab.lineWidth;
						//add link event ---------------------
						SpriteClickEvent.SpriteEventType type = (SpriteClickEvent.SpriteEventType)(int.Parse(linkType[k]));
						switch(type){
						case SpriteClickEvent.SpriteEventType.GoodsLink:
							SpriteClickEvent sce = sp.gameObject.AddComponent<SpriteClickEvent>();
							sce.SetClickEvent (SpriteClickEvent.SpriteEventType.NameLink,lab);
//							sce.param = lab;
//							sce.mType = SpriteClickEvent.SpriteEventType.NameLink;
							break;
						}
					}
				}
			}
		}else{
			lab = AddLabel (ref chatItem,label,len,toParse);
			len += lab.lineWidth + 6;
		}
	}
	
	private static int GetLabelLength(string str,UILabel lab,bool colored){
		if(colored){
//			return (int)(lab.font.CalculatePrintedSize(str, FONT_SIZE, true, UIFont.SymbolStyle.Colored).x * lab.gameObject.transform.localScale.y+ 2);
			return lab.width + 1;
		}else{
//			return (int)(lab.font.CalculatePrintedSize(str, FONT_SIZE, true, UIFont.SymbolStyle.Uncolored).x * lab.gameObject.transform.localScale.y+2);
//			return (int)(lab.relativeSize.x * lab.gameObject.transform.localScale.x);
			return lab.width + 1;
		}
	}
	private static UILabel AddLabel(ref GameObject parent,GameObject prefab,int len,string text){
		UILabel lab = NGUITools.AddChild (parent,prefab).GetComponent<UILabel>();
		lab.maxLineCount = 1;
		lab.gameObject.transform.localPosition = new Vector3(len,0,0);
		lab.gameObject.transform.localScale = prefab.transform.localScale;
		lab.text = text;
		lab.lineWidth = GetLabelLength (text,lab,false);
		return lab;
	}
	private static UISprite AddSprite(ref UILabel lab,int len,ref GameObject parent,string spriteName,bool addCollider){
		UISprite sp = NGUITools.AddSprite (parent,nh.ui.cache.NewChatCache.faceAtlas,spriteName);
		sp.pivot = UIWidget.Pivot.TopLeft;
		sp.gameObject.transform.localPosition = new Vector3(len,-6,-1);
		sp.gameObject.transform.localScale = new Vector3(1,1,1);
		sp.width  = lab.width;
		sp.height = lab.height;
		sp.depth = 9;
		sp.color = Color.green;
		if(addCollider) {
			BoxCollider box = NGUITools.AddWidgetCollider (sp.gameObject);
//			box.size = new Vector3(1f,1f,3f);
		}
		return sp;
	}
	private static UISprite AddFaceSprite(float size,int len,ref GameObject parent,string spriteName,bool addCollider){
		UISprite sp = NGUITools.AddSprite (parent,nh.ui.cache.NewChatCache.faceAtlas,spriteName);
		sp.pivot = UIWidget.Pivot.TopLeft;
		sp.gameObject.transform.localPosition = new Vector3(len,0,0);
//		sp.gameObject.transform.localScale = new Vector3(size,size,1);
//		sp.width = (int)size;
//		sp.height = (int)size;
		sp.width = 36;
		sp.height = 32;
		if(addCollider) {
			BoxCollider box = NGUITools.AddWidgetCollider (sp.gameObject);
//			box.size = new Vector3(1f,1f,3f);
		}
		return sp;
	}
}

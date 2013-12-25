using UnityEngine;
using System.Collections;
using nh.ui.cache;
using TangGame.View;
namespace nh.ui.chat
{
	public class MainMenuPanel:XBPanel
	{
	    public new const string NAME="MainMenuPanel";
	    public UIButton bagSelectButton;
	    public UIButton currentChannelButton;
	    public UIButton FaceButton;
	    public UIInput InputBox;
	    public UIButton SendMsgButton;
	    MainMenuPanelMediator mediator;
		
		public GameObject facesObj;
		public UIAtlas faceAtlas;
		GameObject faceRoot;
		
		short toShowChannel =0;
		public short chatToSent = NewChatCache.index[0];
		UILabel lab;
		
	    void Start()
	    {
	        mediator =new MainMenuPanelMediator(this);
	        PanelCache.ChatPanelTable.Add(NAME,mediator);
	        UIEventListener.Get(SendMsgButton.gameObject).onClick+=SendMsgButtonClick;
			UIEventListener.Get(FaceButton.gameObject).onClick+=FaceButtonClick;
			UIEventListener.Get(bagSelectButton.gameObject).onClick+=BagSelectButtonClick;
			
			lab = currentChannelButton.gameObject.GetComponentInChildren<UILabel>();
			
			faceRoot = new GameObject("faceRoot");
			faceRoot.transform.parent = facesObj.transform;
			faceRoot.transform.localScale = Vector3.one;
			faceRoot.transform.localPosition = new Vector3(0f,0f,-2f);
			faceRoot.SetActive (false);
			InitFaces();
	    }
		void Update(){
			if(toShowChannel != NewChatCache.currentChannel){
				toShowChannel = NewChatCache.currentChannel;
				chatToSent = NewChatCache.index[toShowChannel];
				lab.text = ChatLang.BUTTON_SHOW_CHANNEL[this.toShowChannel];
				lab.color = NewChatCache.buttonTextColor[this.toShowChannel];
			}

		}
		
	    public void SendMsgButtonClick(GameObject obj)
	    {
	        mediator.SendChatMsg();
	    }
//		public short channel;
//    public string fromName;
//    public long fromId;
//    public string content;
//    public int vipLevel;
		public void FaceButtonClick(GameObject obj)
	    {
			faceRoot.SetActive (!NGUITools.GetActive (faceRoot));
	    }
		public void BagSelectButtonClick(GameObject obj)
	    {
			ChatVo chat = new ChatVo();
			chat.channel = ChatVo.WORLD;
			chat.fromName = "ssssssss";
			chat.fromId = 1;
			chat.content = "say:-----------------aaaaa";
			chat.vipLevel = 6;
	        NewChatCache.Add (chat);
	    }
	    public string GetInputMsg()
	    {
	        return InputBox.text;
	    }
	    public void InputBoxTextClear()
	    {
	        InputBox.text="";
	    }
		
		void InitFaces(){
			if(faceAtlas){
				NewChatCache.faceAtlas = faceAtlas;
				NewChatCache.faces = faceAtlas.GetListOfSprites ().ToArray ();
				float countX = 0;
				float countY = FaceButton.gameObject.transform.localScale.y/2 + 20;
				for(int i = 0,length = NewChatCache.faces.Length;i < length;i++){
					if(ChatUtils.linkSpriteName.Equals (NewChatCache.faces[i])) continue;
					UISprite sp = NGUITools.AddSprite (faceRoot,faceAtlas,NewChatCache.faces[i]);
					sp.gameObject.transform.localScale = new Vector3(40,40,1);
					sp.gameObject.transform.localPosition = new Vector3(countX,countY,0f);
					NGUITools.AddWidgetCollider(sp.gameObject).size = Vector3.one;
					UIEventListener.Get (sp.gameObject).onClick += FaceSpriteClick;
					countX += 40;
					if((i+1) % 3 == 0 && i != 0){
						countY += 40;
						countX = 0;
					}
				}
			}
			
		}
		
		void FaceSpriteClick(GameObject obj){
			faceRoot.SetActive(false);
			//that sent a msg to notice use is best
			
			if(NewChatCache.faceNum > 2) return;
			if(InputBox.text.Length > 22) return;
			InputBox.text += @"&" + obj.GetComponent<UISprite>().spriteName + @"&";
			NewChatCache.faceNum = NewChatCache.faceRegex.Matches (InputBox.text).Count;
	        
	    }
	}
}
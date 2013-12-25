/**
 * Login Panel
 *
 * Date: ?
 * Author: lite
 *
 * Date: 2013/11/20
 * Edit: zzc
 * Desc: 整理代码
 */
using UnityEngine;
using System;
using System.Collections;
using TangGame;
using TangGame.Net;

namespace  TangGame
{
  public class LoginPanel : ViewPanel
  {
		public GameObject username;
		public GameObject password;
		public GameObject remember;
		public GameObject login;
		public GameObject register;

    private UIInput usernameInput;
    private UIInput passwordInput;
    private UIToggle rememberToggle;
    
		private bool enablePlayerConfig = false;

    void Start()
    {
      UIEventListener.Get(login).onClick += OnLoginButtonClicked;
			UIEventListener.Get(register).onClick += OnRegisterButtonClicked;
      OnInit();
    }
    
    private void OnInit()
    {
			usernameInput = username.GetComponent<UIInput>();
			passwordInput = password.GetComponent<UIInput>();
			rememberToggle = remember.GetComponent<UIToggle>();

			if(enablePlayerConfig){
	      usernameInput.value = PlayerConfig.GetString("USERNAME");
	      passwordInput.value = PlayerConfig.GetString("PASSWORD");
				bool isRemember = PlayerConfig.GetBool("REMEMVERME");
	      rememberToggle.value = isRemember;
			}
    }
    
    private void OnLoginButtonClicked(GameObject obj)
    {
      string username = usernameInput.value;
      string password = passwordInput.value;

      // 记住
      RememberUsernameAndPassword(username, password);

      // 发送
      TangNet.TN.Send(new LoginRequest(username, password));
    }

    private void OnRegisterButtonClicked(GameObject go)
    {
      string username = usernameInput.value;
      string password = passwordInput.value;

      // 记住
      RememberUsernameAndPassword(username, password);
      // 发送
      TangNet.TN.Send(new RegisterRequest(username, password, "I Come In Game"));
    }
    
    private void RememberUsernameAndPassword(string username, string password)
    {
			if(enablePlayerConfig){
	      bool isRemember = rememberToggle.value;
	      
	      if (isRemember) {
	        PlayerConfig.SetString("PASSWORD", password);
	      } else {
	        PlayerConfig.SetString("PASSWORD", "");
	      }
	      
	      PlayerConfig.SetString("USERNAME", username);
	      PlayerConfig.SetBool("REMEMVERME", isRemember);
	      PlayerConfig.Flush();
			}

      LoginPanelCache.Username = username;
      LoginPanelCache.Password = password;

    }
    
  }
}

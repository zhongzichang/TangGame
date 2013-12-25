/**
 * Loading Panel Behaviour
 *
 * Date: 2013/11/29
 * Author: zzc
 */
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TangGame.View;

namespace TangGame
{
  public class WelcomePanelBhvr : MonoBehaviour
  {

    public GameObject loadingPanel;
    public GameObject errorPanel;

    public UISprite progressSprite;
    public UILabel messageLabel;
    public UILabel progressLabel;

    public UILabel errorLabel;
    public GameObject oneOkBut;

    void Start ()
    {
      Facade.Instance.RegisterMediator (new WelcomePanelMediator (gameObject));
      UIEventListener.Get(oneOkBut).onClick += OnOKButtonClicked;
    }

    void OnDestroy ()
    {
      Facade.Instance.RemoveMediator (WelcomePanelMediator.NAME);
    }

    public void UpdateMessage (string value)
    {
      if (messageLabel != null){
        messageLabel.text = value;
      }
    }

    public void UpdateProgress (float progress)
    {
      if (progressSprite != null) {
        progressSprite.fillAmount = progress;
        if(progressLabel!=null){
          progressLabel.text = string.Format("{0}%", (int)progress*100);
        }
      }
    }

    public void UpdateErrorMessage (string value)
    {
      if (errorLabel != null){
        errorLabel.text = value;
      }      
      errorPanel.SetActive(true);
    }
    
    public void ShowLoadingPanel(){
      loadingPanel.SetActive(true);
    }

    public void HideLoadingPanel(){
      loadingPanel.SetActive(false);
    }

    private void OnOKButtonClicked(GameObject go){
      errorPanel.SetActive(false);
    }

  }
}
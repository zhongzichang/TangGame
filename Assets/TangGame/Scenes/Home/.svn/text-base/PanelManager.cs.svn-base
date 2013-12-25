using System;
using UnityEngine;
using System.Collections;
using nh.ui.model.vo;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangGame
{
  public class PanelManager : MonoBehaviour
  {
    private static PanelManager _instance = null;
    private Stack panelStack = new Stack ();
    private string currPanel;
    private GameObject root;
    private Hashtable panels = new Hashtable();

    public GameObject Root {
      get { return root;}
      set {
        root = value;
        BindPanels ();
      }
    }

    public static PanelManager Instance {
      get {
        if (_instance != null) 
          return _instance;
        
        var obj = new GameObject ("_PanelManager");
        obj.transform.localPosition = Vector3.zero;
        _instance = obj.AddComponent<PanelManager> ();

        return _instance;
      }
    }

    void Start ()
    {
//      currPanel = typeof(LoginPanel).Name;
    }
    
    IEnumerator SwithPanelRoutine ()
    {
      yield return null;
      foreach (Transform obj in root.transform) {
        if (obj.GetComponent (currPanel) != null) {
          Show (obj.gameObject);
        } else {
          Hide (obj.gameObject);
        }
      }
    }
    
    private void BindPanels ()
    {
      foreach (Transform panel in root.transform) {
        ViewPanel viewPanel = BindPanel (panel.gameObject);
        panels[panel.name] = viewPanel;
      }
    }

    private ViewPanel BindPanel (GameObject panelObject)
    {
      Hashtable controls = new Hashtable ();
      ViewPanel panel = panelObject.GetComponent (panelObject.name) as ViewPanel;
      if (panel == null) {
        panel = panelObject.AddComponent (panelObject.name) as ViewPanel;
      }

      if (panel == null)
        return null;

      foreach (Transform t in panel.GetComponentsInChildren<Transform>(true)) {
        controls [t.name] = t.gameObject;
      }

      System.Reflection.FieldInfo[] fields = panel.GetType ().GetFields ();       
      foreach (System.Reflection.FieldInfo field in fields) {
        if (field == null)
          continue;
        if (!field.IsPublic)
          continue;

        GameObject go = controls [field.Name] as GameObject;
        if (go == null)
          continue;

        field.SetValue (panel, go); 
      }
      return panel;
    }

//     Debug please uncomment OnGUI
//    void OnGUI ()
//    {
//      if (GUILayout.Button ("Joystick")) {
//        InputManager.Instance.GestureEnabled = true;
//        InputManager.Instance.JoystickEnabled = true;
//      }
//      if (GUILayout.Button ("Bind")) {
//        BindPanels ();
//      }
//      if (GUILayout.Button ("LoadingPanel")) {
//        ShowPanel<LoadingPanel> ();
//      }
//      if (GUILayout.Button ("LoginPanel")) {
//        ShowPanel<LoginPanel> ();
//      }
//      if (GUILayout.Button ("RegisterPanel")) {
//        ShowPanel<RegisterPanel> ();
//      }
//      if (GUILayout.Button ("ServerListPanel")) {
//        ShowPanel<ServerListPanel> ();
//      }
//      if (GUILayout.Button ("ServerConfirmPanel")) {
//        ShowPanel<ServerConfirmPanel> ();
//      }
//    }

    public void ShowPanel<TViewPanel> () where TViewPanel : ViewPanel
    {
      currPanel = typeof(TViewPanel).Name;
      StartCoroutine (SwithPanelRoutine ());
    }

    public ViewPanel GetPanel(string panelName)
    {
      return panels[panelName] as ViewPanel;
    }

    public void Back ()
    {
      currPanel = panelStack.Pop () as string;
    }
    
    public void EnterGame (int mapId)
    {
      Hide(GetPanel(currPanel).gameObject);
      PureMVC.Patterns.Facade.Instance.SendNotification(TangGame.NtftNames.TG_LOADING_START);
      PureMVC.Patterns.Facade.Instance.SendNotification(TangGame.NtftNames.TG_LOADING_MESSAGE, LoadingLang.LOAING_SCENE);
      TangScene.TS.LoadScene (mapId);
    }

    private void Hide (GameObject go)
    {
      if (!go.activeSelf)
        return;
      go.SetActive (false);
      panelStack.Push (go.name);
    }
    
    private void Show (GameObject go)
    { 
      if (go.activeSelf)
        return;
      go.SetActive (true);
    }
    
    private string GetLastPanel ()
    {
      if (panelStack.Count == 0)
        return null;
      return panelStack.Peek () as string;     
    }
    
  }
}

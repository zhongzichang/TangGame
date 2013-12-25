using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;

namespace TangGame
{
  public class NpcTaskMarkBhvr : MonoBehaviour
  {

    public GameObject npcTaskMarkObj;
    public Animator animator;
    public TangGame.Net.Npc npc;
    private IFacade facade = PureMVC.Patterns.Facade.Instance;
    // Use this for initialization
    void Start ()
    {
      GameObject npcTaskMarkPrefab = Resources.Load (GameConsts.PREFABS_SCENE_NPC_TASK_TAG) as GameObject;
      if (npcTaskMarkPrefab != null) {

        npcTaskMarkObj = NGUITools.AddChild (this.gameObject, npcTaskMarkPrefab);
        npcTaskMarkObj.transform.localPosition = npcTaskMarkPrefab.transform.localPosition;
        npcTaskMarkObj.transform.localRotation = npcTaskMarkPrefab.transform.localRotation;

      }

      animator = npcTaskMarkObj.GetComponent<Animator> ();
      if (animator == null || npcTaskMarkPrefab == null) {
        Destroy (this);
        if (npcTaskMarkObj != null)
          Destroy (npcTaskMarkObj);
      }
      
      //给NPC添加人物标识
      facade.SendNotification (NpcTaskMarkCmd.NAME, npc);
      
    }
    /// <summary>
    /// 设置为隐藏
    /// </summary>
    public void SetHideAnima ()
    {
      animator.SetInteger ("it", 0);
    }
    /// <summary>
    /// 设置成可接标签
    /// </summary>
    public void SetAcceptTag ()
    {
      if (animator == null)
        return;
      animator.SetInteger ("it", 1);
    }
    //设置为已接未完成的标记
    public void UnCompletedTag(){
      if(animator == null)
        return;
      animator.SetInteger("it",3);
    }
    /// <summary>
    /// 设置成完成标签
    /// </summary>
    public void SetCompleteTag ()
    {
      if (animator == null)
        return;
      animator.SetInteger ("it", 2);
    }
  }
}
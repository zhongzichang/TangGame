/**
 * auto nav helper
 *
 * Date: 2013/11/23
 * Author: zzc
 */
using TS = TangScene;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace TangGame
{
  public class AutoNavHelper
  {

    /// <summary>
    ///   开始自动寻路
    /// </summary>    
    public static void Start ()
    {
      // 如果在自动挂机，则取消自动挂机
      if( BattleCache.onHook )
        Facade.Instance.SendNotification(NtftNames.TG_UNHOOK);
      
      // 确保追踪取消
      TS.TS.CancelTrace(ActorCache.leadingActorId);
      // 确保角色选择取消
      TS.TS.UnselectActor();
      
      AutoNavCache.isActive = true;

      switch (AutoNavCache.mode) {
      case AutoNavCache.Mode.searchActor:
        NavToActor ();
        break;
      case AutoNavCache.Mode.searchScene:
        if (AutoNavCache.targetPosition == Vector3.zero)
          NavToScene ();
        else
          NavToPos ();
        break;
      }
    }

    /// <summary>
    ///   中止自动寻路
    /// </summary>
    public static void Terminate ()
    {
      AutoNavCache.isActive = false;
      AutoNavCache.targetPosition = Vector3.zero;
      AutoNavCache.targetActorConfigId = 0;
      AutoNavCache.portalQueue.Clear ();
      Facade.Instance.SendNotification (NtftNames.AUTO_NAV_TERMINATED);
    }

    private static void NavToActor ()
    {
      if (AutoNavCache.portalQueue.Count > 0) {

        // 下一个传送门的位置

        int portalId = AutoNavCache.portalQueue.Dequeue ();
        TS.Portal portal = TS.SceneHelper.GetPortal (portalId);
        if (portal != null) {
          TS.TS.ActorNavigate (new TS.MoveBean (ActorCache.leadingActorId, portal.localPosition));
          // 打开自动寻路显示
          Facade.Instance.SendNotification (NtftNames.AUTO_NAV_STARTED);
        }
      } else {
        Net.Npc npc = ActorCache.GetNpcByConfigId(AutoNavCache.targetActorConfigId);
        // 获取追踪人物
        TS.TS.ActorTrace (ActorCache.leadingActorId, npc.id);
        // 打开自动寻路显示
        Facade.Instance.SendNotification (NtftNames.AUTO_NAV_STARTED);
      }
    }

    private static void NavToScene ()
    {
      if (AutoNavCache.portalQueue.Count > 0) {

        // 下一个传送门的位置

        int portalId = AutoNavCache.portalQueue.Dequeue ();
        TS.Portal portal = TS.SceneHelper.GetPortal (portalId);
        if (portal != null) {
          TS.TS.ActorNavigate (new TS.MoveBean (ActorCache.leadingActorId, portal.localPosition));
          // 打开自动寻路显示
          Facade.Instance.SendNotification (NtftNames.AUTO_NAV_STARTED);
        }
      } else {
        // 关闭自动寻路显示
        Facade.Instance.SendNotification (NtftNames.AUTO_NAV_TERMINATED);
      }
      
    }

    private static void NavToPos ()
    {
      if (AutoNavCache.portalQueue.Count > 0) {

        // 下一个传送门的位置

        int portalId = AutoNavCache.portalQueue.Dequeue ();
        TS.Portal portal = TS.SceneHelper.GetPortal (portalId);
        if (portal != null) {
          TS.TS.ActorNavigate (new TS.MoveBean (ActorCache.leadingActorId, portal.localPosition));
          // 打开自动寻路显示
          Facade.Instance.SendNotification (NtftNames.AUTO_NAV_STARTED);
        }
      } else {
        // 获取人物的位置
        TS.TS.ActorNavigate (new TS.MoveBean (ActorCache.leadingActorId, AutoNavCache.targetPosition));
        // 打开自动寻路显示
        Facade.Instance.SendNotification (NtftNames.AUTO_NAV_STARTED);

      }
      
    }

  }
}
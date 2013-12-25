/*
 * Created by emacs
 * Date: 2013/10/9
 * Author: zzc
 */
using System;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangScene
{
  public class TS
  {

    /// <summary>
    /// TS GameObject 名字
    /// </summary>
    public const string GOBJ_NAME = "TS";
    
    /// <summary>
    /// 是否同步执行
    /// </summary>
    public static bool syncExecute = true;
    
    
    /// <summary>
    /// PureMVC Facade
    /// </summary>
    public static IFacade facade = Facade.Instance;

    #region Properties


    /// <summary>
    ///   当前场景ID
    /// </summary>
    public static int CurrentSceneId
    {
      get
      {
        return LevelBhvr.SceneId;
      }
    }


    /// <summary>
    ///   获取当前场景配置信息
    /// </summary>
    public static Scene CurrentScene
    {
      get
      {
        
        if( Game.sceneTable.ContainsKey( CurrentSceneId ) )
        {
          return Game.sceneTable[ CurrentSceneId ];
        }
        return null;
      }

    }

    
    /// <summary>
    ///   被控制的角色ID
    /// </summary>
    public static long ControlledActorId {
      get
      {
        return Cache.controlledActorId;
      }
    }

    /// <summary>
    ///   被选中的角色ID
    /// </summary>
    public static long SelectedActorId
    {
      get
      {
        return Cache.selectedActorId;
      }
    }



    /// <summary>
    ///   确保场景中存在 TS GameObject
    /// </summary>
    public static GameObject EnsureTSGobj ()
    {

      if (Cache.tsGobj == null) {
        Cache.tsGobj = GameObject.Find (GOBJ_NAME);
        if (Cache.tsGobj == null)
          Cache.tsGobj = NewTSGobj ();
      }

      return Cache.tsGobj;

    }

    #endregion

    #region SceneMethods

    /// <summary>
    ///   加载场景
    /// <param name="sceneId">需要加载的场景ID</param>
    /// </summary>
    public static void LoadScene (int sceneId)
    {
      LevelBhvr.SceneId = sceneId;
    }


    // load assetbundle -------

    /// <summary>
    ///   加载 AssetBundle
    /// </summary>
    public static void LoadAssetBundle (string name,
                                        Tang.ResourceLoader.LoadCompleted loadCompletedHandler
                                       )
    {
      LoadAssetBundle (name, loadCompletedHandler, null);
    }

    /// <summary>
    ///   加载 AssetBundle
    /// </summary>
    public static void LoadAssetBundle (string name,
                                        Tang.ResourceLoader.LoadCompleted loadCompletedHandler,
                                        Tang.ResourceLoader.LoadFailure loadFailureHandler
                                       )
    {
      LoadAssetBundle (name, loadCompletedHandler, loadFailureHandler, null);
    }

    /// <summary>
    ///   加载 AssetBundle
    /// </summary>
    public static void LoadAssetBundle (string name,
                                        Tang.ResourceLoader.LoadCompleted loadCompletedHandler,
                                        Tang.ResourceLoader.LoadFailure loadFailureHandler,
                                        Tang.ResourceLoader.LoadBegan loadBeganHandler)
    {
      Tang.ResourceLoader.Enqueue (Tang.ResourceUtils.GetAbFilePath (name),
                                   loadCompletedHandler, loadFailureHandler,
                                   loadBeganHandler);
    }

    // load XML file -------
    
    /// <summary>
    ///   加载 XML 文件
    /// </summary>
    public static void LoadXml(string name ,
                               Tang.ResourceLoader.LoadCompleted loadCompletedHandler )
    {
      LoadXml(name, loadCompletedHandler, null);
    }

    /// <summary>
    ///   加载 XML 文件
    /// </summary>
    public static void LoadXml(string name ,
                               Tang.ResourceLoader.LoadCompleted loadCompletedHandler,
                               Tang.ResourceLoader.LoadFailure loadFailureHandler)
    {
      LoadXml(name, loadCompletedHandler, loadFailureHandler, null);
    }

    /// <summary>
    ///   加载 XML 文件
    /// </summary>
    public static void LoadXml (string name,
                                Tang.ResourceLoader.LoadCompleted loadCompletedHandler,
                                Tang.ResourceLoader.LoadFailure loadFailureHandler,
                                Tang.ResourceLoader.LoadBegan loadBeganHandler)
    {
      Tang.ResourceLoader.Enqueue( Tang.ResourceUtils.GetXmlFilePath (name),
                                  loadCompletedHandler,
                                  loadFailureHandler,
                                  loadBeganHandler);
    }

    #endregion

    #region ActorMethods

    /// <summary>
    ///   角色进入场景
    /// </summary>
    public static void ActorEnter (Actor actor)
    {
      if( syncExecute )
        facade.SendNotification(ActorEnterCmd.NAME, actor);
      else
        Cache.notificationQueue.Enqueue (new Notification (ActorEnterCmd.NAME, actor));
    }

    /// <summary>
    ///   角色离开场景
    /// </summary>
    public static void ActorExit (long actorId)
    {
      if( syncExecute )
        facade.SendNotification(ActorExitCmd.NAME, actorId);
      else
        Cache.notificationQueue.Enqueue (new Notification (ActorExitCmd.NAME, actorId));
    }

    /// <summary>
    ///   角色走动
    /// </summary>
    public static void ActorNavigate (MoveBean bean)
    {
      if( syncExecute )
        facade.SendNotification(ActorNavigateCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue (new Notification (ActorNavigateCmd.NAME, bean));
    }

    /// <summary>
    ///   角色瞬移
    /// </summary>
    public static void ActorShift (MoveBean bean)
    {
      if( syncExecute )
        facade.SendNotification(ActorShiftCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue( new Notification( ActorShiftCmd.NAME, bean) );
    }

    /// <summary>
    ///   准备攻击，只有某些技能才有起手动作 (需要提供再检查流程)
    /// </summary>
    public static void ReadyAttack(AttackBean bean)
    {
      //      Cache.notificationQueue.Enqueue (new Notification (ActorReadyAttackCmd.NAME, bean));
    }

    /// <summary>
    ///   攻击
    /// </summary>
    public static void Attack (AttackBean bean)
    {
      if( syncExecute )
        facade.SendNotification(ActorAttackCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue (new Notification (ActorAttackCmd.NAME, bean));
    }

    /// <summary>
    ///   攻击结果处理
    /// </summary>
    public static void AttackResult (AttackResultBean bean)
    {
      if( syncExecute )
        facade.SendNotification(ActorAttackResultCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue (new Notification (ActorAttackResultCmd.NAME, bean));
    }

    /// <summary>
    ///   切换控制的角色
    /// </summary>
    public static void SwitchControlledActor (long actorId)
    {
      if (Cache.controlledActorId != actorId){
        if( syncExecute )
          facade.SendNotification(SwitchControlledActorCmd.NAME, actorId);
        else
          Cache.notificationQueue.Enqueue (new Notification (SwitchControlledActorCmd.NAME, actorId));
      }
    }

    /// <summary>
    ///   切换选择的角色
    /// </summary>
    public static void SwitchSelectedActor (long actorId)
    {
      if (Cache.selectedActorId != actorId){
        if( syncExecute )
          facade.SendNotification(SwitchSelectedActorCmd.NAME, actorId);
        else
          Cache.notificationQueue.Enqueue (new Notification (SwitchSelectedActorCmd.NAME, actorId));
      }
    }

    /// <summary>
    ///   取消角色选择
    /// </summary>
    public static void UnselectActor ()
    {
      if (Cache.selectedActorId != 0 && Cache.actors.ContainsKey (Cache.selectedActorId)){
        if( syncExecute )
          facade.SendNotification(UnselectActorCmd.NAME);
        else
          Cache.notificationQueue.Enqueue (new Notification (UnselectActorCmd.NAME));
      }
      
    }

    /// <summary>
    ///   修改角色速度
    /// </summary>
    public static void ChangeActorSpeed (long actorId, float speed)
    {
      if (Cache.actors.ContainsKey (actorId))
      {
        ChangeSpeedBean bean = new ChangeSpeedBean (actorId, speed);
        if( syncExecute )
          facade.SendNotification(ChangeActorSpeedCmd.NAME, bean);
        else
          Cache.notificationQueue.Enqueue (new Notification (ChangeActorSpeedCmd.NAME, bean));
      }
    }

    /// <summary>
    ///   移动角色（用于摇杆 bean.vector3 < Vector3.one）
    /// <param name="bean">传递需要移动的信息</param>
    /// </summary>
    public static void ActorMove (MoveBean bean)
    {
      if( syncExecute )
        facade.SendNotification(ActorMoveCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue (new Notification (ActorMoveCmd.NAME, bean));
    }

    /// <summary>
    ///   角色跟踪
    /// </summary>
    public static void ActorTrace(long tracerId, long targetId)
    {
      TraceBean bean = new TraceBean(tracerId, targetId);
      if( syncExecute )
        facade.SendNotification(ActorTraceCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue( new Notification( ActorTraceCmd.NAME, bean ));
    }

    /// <summary>
    ///   角色跟踪
    /// </summary>
    public static void ActorTrace(long tracerId, long targetId, float cacheDistance, float startDistance)
    {
      TraceBean bean = new TraceBean(tracerId, targetId, cacheDistance, startDistance);
      if( syncExecute )
        facade.SendNotification(ActorTraceCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue( new Notification( ActorTraceCmd.NAME, bean ));
    }

    /// <summary>
    ///   角色重新跟踪
    /// </summary>
    public static void ActorReTrace(long tracerId )
    {
      if( syncExecute )
        facade.SendNotification( ActorReTraceCmd.NAME, tracerId);
      else
        Cache.notificationQueue.Enqueue( new Notification( ActorReTraceCmd.NAME, tracerId ));
    }


    /// <summary>
    ///   取消跟踪
    /// </summary>
    public static void CancelTrace( long tracerId )
    {
      if( syncExecute )
        facade.SendNotification(CancelTraceCmd.NAME, tracerId);
      else
        Cache.notificationQueue.Enqueue( new Notification( CancelTraceCmd.NAME, tracerId ));
    }

    /// <summary>
    ///   取消控制角色
    /// </summary>
    public static void UncontrollActor()
    {
      if( syncExecute )
        facade.SendNotification(UncontrollActorCmd.NAME);
      else
        Cache.notificationQueue.Enqueue( new Notification( UncontrollActorCmd.NAME) );
    }

    /// <summary>
    ///   冲刺
    /// </summary>
    public static void Sprint(long sourceId, long targetId)
    {
      SprintBean bean = new SprintBean( sourceId, targetId);
      if( syncExecute )
        facade.SendNotification(SprintCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue( new Notification( SprintCmd.NAME, bean ) );
    }

    /// <summary>
    ///   冲刺
    /// </summary>
    public static void Sprint(long sourceId, long targetId, Vector3 destination)
    {
      SprintBean bean = new SprintBean( sourceId, targetId, destination);
      if( syncExecute )
        facade.SendNotification(SprintCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue( new Notification( SprintCmd.NAME, bean) );
    }

    /// <summary>
    ///   冲刺
    /// </summary>
    public static void Sprint(long sourceId, Vector3 destination)
    {
      SprintWithPosBean bean = new SprintWithPosBean( sourceId, destination);
      if( syncExecute )
        facade.SendNotification( SprintWithPosCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue( new Notification( SprintWithPosCmd.NAME, bean) );
    }
    
    /// <summary>
    ///   冲刺
    /// </summary>
    public static void Sprint(long sourceId, Vector3 destination, float speed)
    {
      SprintWithPosBean bean = new SprintWithPosBean( sourceId, destination, speed);
      if( syncExecute )
        facade.SendNotification(SprintWithPosCmd.NAME, bean);
      else
        Cache.notificationQueue.Enqueue( new Notification( SprintWithPosCmd.NAME, bean) );
    }

    /// <summary>
    ///   僵直
    /// </summary>
    public static void Stagnant(long[] actorIds, float secondTime)
    {
      StagnantBean bean = new StagnantBean( actorIds, secondTime  );
      if( syncExecute )
        facade.SendNotification(StagnantCmd.NAME, bean);
      else
       Cache.notificationQueue.Enqueue( new Notification( StagnantCmd.NAME, bean) );
    }

    /// <summary>
    ///   死亡
    /// </summary>
    public static void ActorDie(long actorId)
    {
      if( syncExecute )
        facade.SendNotification( ActorDieCmd.NAME, actorId );
      else
        Cache.notificationQueue.Enqueue( new Notification( ActorDieCmd.NAME, actorId ) );
    }

    /// <summary>
    ///   重生
    /// </summary>
    public static void ActorRelive(long actorId)
    {
      if( syncExecute )
        facade.SendNotification(ActorReliveCmd.NAME, actorId);
      else
        Cache.notificationQueue.Enqueue( new Notification( ActorReliveCmd.NAME, actorId ) );
    }
    


    #endregion
    #region StagePropertyMethods
    

    public static void StagePropertyEnter (StageProperty stageProperty)
    {
      
      // TODO
      
    }

    public static void StagePropertyExit (long stagePropertyId)
    {
      // TODO
    }
    
    
    #endregion
    #region EffectMethods
    
    
    public static void PlayEnviromentEffect (int effectId, int seconds)
    {
      // TODO
    }

    
    #endregion
    #region GetMethods

    public static GameObject GetActorGameObject(long actorId)
    {
      if( Cache.actors.ContainsKey(actorId) )
        return Cache.actors[ actorId ];
      else
        return null;
    }
    
    /// <summary>
    /// 获取距离指定角色最近的其他角色的ID
    /// </summary>
    /// <param name="sourceId">角色ID</param>
    /// <param name="actorType">角色类型</param>
    /// <param name="visible">是否在屏幕上可见</param>
    /// <returns>距离最近的角色ID，如果找不到返回0</returns>
    public static long GetClosestActorId(long sourceId, ActorType actorType, bool visible){
      
      long targetId = 0L;
      float minDistance = 10000F;
      
      GameObject sourceActoGobj = null;
      if( Cache.actors.ContainsKey( sourceId ) ) {
        
        sourceActoGobj = Cache.actors[sourceId];
        
        foreach( GameObject gobj in Cache.actors.Values ){
          SpriteAnimate spriteAnimate = gobj.GetComponent<SpriteAnimate>();
          ActorBhvr actorBhvr = gobj.GetComponent<ActorBhvr>();
          
          if( spriteAnimate != null && actorBhvr != null && 
              spriteAnimate.visible == visible && 
              actorBhvr.actorType == actorType ){
            
             float distance = Vector3.Distance (sourceActoGobj.transform.localPosition, gobj.transform.localPosition);

              if (distance < minDistance) {
                minDistance = distance;
                targetId = actorBhvr.id;
              }
          }
        }
      }
      
      return targetId;
    }
    
    /// <summary>
    /// 获取正在追踪的角色ID
    /// </summary>
    /// <param name="sourceId">角色ID</param>
    /// <returns>正在追踪的角色ID</returns>
    public static long GetTraceActorId(long sourceId){
      GameObject sourceGobj = GetActorGameObject(sourceId);
      long targetId = 0L;
      if( sourceGobj != null ){
        TracerBhvr tracerBhvr = sourceGobj.GetComponent<TracerBhvr>();
        if( tracerBhvr != null && tracerBhvr.enabled ){
          targetId = tracerBhvr.targetId;
        }
      }
      return targetId;
    }
    
    /// <summary>
    /// 判断指定的角色是否存在场景中
    /// </summary>
    /// <param name="actorId">角色ID</param>
    /// <returns></returns>
    public static bool Exist(long actorId){
      return Cache.actors.ContainsKey(actorId);
    }
    

    #endregion

    private static GameObject NewTSGobj ()
    {
      GameObject gobj = new GameObject ();
      gobj.name = GOBJ_NAME;
      gobj.AddComponent<TsBhvr> ();
      gobj.AddComponent<LevelBhvr> ();
      gobj.AddComponent<Tang.ResourceLoader> ();
      gobj.AddComponent<ClearActorsOutOfEyeshotBhvr>();
      return gobj;
    }
  }
}
/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/12/7
 * Time: 2:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;
using UnityEngine;

namespace TangGame
{
  /// <summary>
  /// Description of AutoNavCmd.
  /// </summary>
  public class AutoNavCmd : SimpleCommand
  {
    
    public override void Execute(INotification notification)
    {
      
      // 如果指令缓存打开，缓存这条命令
      if( InstructionCache.isInstructionCached ){
        InstructionCache.instructionQueue.Enqueue(notification);
        return;
      }
      
      // 确保取消跟踪
      TangScene.TS.CancelTrace(ActorCache.leadingActorId);
      
      object body = notification.Body;
      if( body is ActorAutoNavBean ){
        
        // 寻路到目标角色
        ActorAutoNavBean bean = body as ActorAutoNavBean;
        AutoNavCache.mode = AutoNavCache.Mode.searchActor;
        AutoNavCache.targetActorConfigId = bean.actorConfigId;
        if( bean.portalIds != null )
          AutoNavCache.portalQueue = new Queue<short>(bean.portalIds);
        else
          AutoNavCache.portalQueue.Clear();
        
        AutoNavHelper.Start();
        
      } else if( body is PosAutoNavBean ) {
        
        // 寻路到位置
        PosAutoNavBean bean = body as PosAutoNavBean;
        AutoNavCache.mode = AutoNavCache.Mode.searchScene;
        AutoNavCache.targetPosition = bean.pos;
        if( bean.portalIds != null )
          AutoNavCache.portalQueue = new Queue<short>(bean.portalIds);
        else
          AutoNavCache.portalQueue.Clear();
        
        AutoNavHelper.Start();
        
      } else if( body is SceneAutoNavBean ) {
        
         // 寻路到场景
        PosAutoNavBean bean = body as PosAutoNavBean;
        AutoNavCache.mode = AutoNavCache.Mode.searchScene;
        AutoNavCache.targetPosition = Vector3.zero;
        if( bean.portalIds != null ){
          AutoNavCache.portalQueue = new Queue<short>(bean.portalIds);
          AutoNavHelper.Start();
        }
        else
          AutoNavCache.portalQueue.Clear();
        
      }
    }
  }
}

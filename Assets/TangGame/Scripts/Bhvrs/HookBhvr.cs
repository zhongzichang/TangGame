/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/12/6
 * Time: 10:08
 * 
 * 挂机组件，挂在人物身上后，该人物将自动打怪
 */
using System;
using UnityEngine;
using System.Collections;
using TS = TangScene;

namespace TangGame
{
  /// <summary>
  /// Description of HookBhvr.
  /// </summary>
  [RequireComponent(typeof(TS.CharacterStatusBhvr))]
  [RequireComponent(typeof(TS.TracerBhvr))]
  [RequireComponent(typeof(TS.ActorBhvr))]
  public class HookBhvr : MonoBehaviour
  {
    /// <summary>
    /// 检查周期
    /// </summary>
    public const float PERIOD = 1F;
    
    private TS.CharacterStatusBhvr characterStatusBhvr;
    private TS.TracerBhvr tracerBhvr;
    private TS.ActorBhvr actorBhvr;
    
    void Awake(){
      characterStatusBhvr = GetComponent<TS.CharacterStatusBhvr>();
      tracerBhvr = GetComponent<TS.TracerBhvr>();
      actorBhvr = GetComponent<TS.ActorBhvr>();
    }
    
    void OnEnable(){
      StartCoroutine(CoUpdate());
    }
    
    void OnDisable(){
      tracerBhvr.enabled = false;
    }
    
    private IEnumerator CoUpdate(){
      
      while( enabled ){
        
        // 空闲
        if( characterStatusBhvr.Status == TS.CharacterStatus.idle ){
          
          if( !tracerBhvr.enabled ){
              
              BattleHelper.AutoTrace(actorBhvr.id);
              
          }
        }
        yield return new WaitForSeconds(PERIOD);
      }
    }
  }
}

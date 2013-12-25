/**
 * 角色状态控制组件
 * 
 * Date: 2013/9/23
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using Tang;

namespace TangScene
{

  /// <summary>
  ///   角色状态控制
  /// </summary>
  [ ExecuteInEditMode ]
  public class CharacterStatusBhvr : MonoBehaviour
  {

    public delegate void StatusChange(CharacterStatus status);
    // 状态开始时回调
    public StatusChange statusStartHandler;
    // 状态结束时回调
    public StatusChange statusEndHandler;

    /// <summary>
    ///   角色状态，在*inspector*中使用
    /// </summary>
    public CharacterStatus m_status = CharacterStatus.idle;

    private SpriteAnimate spriteAnimate;
    private ActorBhvr actorBhvr;

    void Start()
    {
      spriteAnimate = GetComponent<SpriteAnimate>();
      if( spriteAnimate != null )
	{
	  spriteAnimate.lateLastFrameHandler += LateLastFrame;
	  spriteAnimate.currentIndexChange += LateCurrentIndexChange;
	}

      actorBhvr = GetComponent<ActorBhvr>();

    }

    /// <summary>
    ///   角色状态，被脚本使用
    /// </summary>
    public CharacterStatus Status
    {
      get
	{
	  return m_status;
	}
      set
	{
	  if( m_status != value )
	    {

	      CharacterStatus before = m_status;

	      if( statusEndHandler != null )
		statusEndHandler(m_status);

	      m_status = value;

	      if( statusStartHandler != null )
		statusStartHandler(m_status);

	      // send notification for status changed
	      if( actorBhvr != null )
		Facade.Instance.SendNotification(NtftNames.ACTOR_STATUS_CHANGED,
						 new CharacterStatusChangedBean( actorBhvr.id, 
										 before, 
										 m_status ));
	      
	    }
	}
    }


    /// <summary>
    ///   当播放到最后一帧时被调用
    /// </summary>
    public void LateLastFrame(SpriteAnimation spriteAnimation)
    {
      if( Status == CharacterStatus.attack )
	Status = CharacterStatus.idle;

      else if( Status == CharacterStatus.sprintBrake )
	Status = CharacterStatus.idle;

      else if( Status == CharacterStatus.die )
	spriteAnimate.spriteAnimation.Suspend();
      
    }

    
    public void LateCurrentIndexChange(int index)
    {
      if( Status == CharacterStatus.attack )
	{
	  // 在这一帧发出攻击到达消息
	  if( index == 6 )
	    Facade.Instance.SendNotification(NtftNames.ATTACK_HIT, actorBhvr.id );
	}
    }


  }
}
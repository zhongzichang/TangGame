/**
 * Trace Fly behaviour
 * Date: 2013/11/7
 * Author: zzc
 */

using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TangScene;
using Ta = Tang;


namespace TangEffect
{

  [ RequireComponent(typeof(SpriteAnimate)) ]
  public class TraceFlyBhvr : MonoBehaviour
  {

    public const float DEFAULT_SPEED = 200F;
    public const float OFFSETZ = 50F;
    public const float DISAPPEAR_DISTANCE = 50F;

    public long actorId;
    public long targetId;
    public float speed;
    public byte tokenCode;

    private GameObject targetGobj;
    private Navigable targetNavigable;
    private Vector3 targetLocalPosition;
    private SpriteAnimate spriteAnimate;
    private Transform myTransform;

    void Start()
    {

      // 获取目标对象
      targetGobj = TS.GetActorGameObject(targetId);

      if( targetGobj == null )
	{
	  Destroy( gameObject );
	  return;
	}

      // 获取目标对象的组件
      targetNavigable = targetGobj.GetComponent<Navigable>();
      if( targetNavigable == null)
	{
	  Destroy( gameObject );
	  return;
	}

      // 释放者
      GameObject actorGobj = TS.GetActorGameObject(actorId);
      if( actorGobj == null )
	{
	  Destroy( gameObject );
	  return;
	}

      // 缓存 transform
      myTransform = transform;

      // 动画控制组件
      spriteAnimate = GetComponent<SpriteAnimate>();
      spriteAnimate.lateSpriteReadyHandler += LateSpriteReady;

      // 设置特效当前位置
      Vector3 sourceRootPosition = actorGobj.transform.localPosition;
      myTransform.localPosition = new Vector3( sourceRootPosition.x, 
					     sourceRootPosition.y, sourceRootPosition.z + OFFSETZ);

      // 监控目标对象的位置变化
      targetNavigable.localPositionChangeHandle += OnTargetLocalPositionChange;
      Vector3 targetRootPosition = targetNavigable.transform.localPosition;
      targetLocalPosition = new Vector3(targetRootPosition.x, targetRootPosition.y, targetRootPosition.z + OFFSETZ);
      
    }

    void LateUpdate()
    {

      if( targetGobj == null )
	{
	  Destroy( gameObject );
	}
      else
	{

	  float distance = Vector3.Distance( myTransform.localPosition, targetLocalPosition);
	  float fraction = Time.deltaTime * speed / distance;
								     
	  if( distance < DISAPPEAR_DISTANCE )
	    {
	      // 命中目标
	      Cache.notificationQueue.Enqueue( new Notification( NtftNames.HIT, 
								 new HitBean( actorId, targetId, tokenCode)) );

	      Destroy(gameObject);
	    }
	  else
	    {
	      myTransform.localPosition = Vector3.Lerp( myTransform.localPosition, 
						      targetLocalPosition, fraction );
	    }

	}

    }

    void OnTriggerEnter( Collider trigger )
    {
      if( trigger == targetGobj.collider )
	{
	  // 命中目标
	  Cache.notificationQueue.Enqueue( new Notification( NtftNames.HIT, 
							    new HitBean( actorId, targetId, tokenCode)) );
	  Destroy( gameObject );
	}
	
    }

    private void OnTargetLocalPositionChange(Vector3 localPosition)
    {
      targetLocalPosition = localPosition;
    }

    private void LateSpriteReady(Ta.TTSprite sprite)
    {
      // 调整方向
      spriteAnimate.spriteAnimation.transform.localRotation
	= Quaternion.FromToRotation(Vector3.right,  (targetLocalPosition-myTransform.localPosition).normalized );
    }

  }
}
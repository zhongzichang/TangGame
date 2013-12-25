/**
 * Action Binding Bhvr
 * Date: 2013/11/5
 * Author: zzc
 */

using UnityEngine;
using TangScene;


namespace TangEffect {


  /// <summary>
  ///   与角色的动作进行绑定，该特效必须含有状态／方向／精灵资源三个组件
  /// </summary>
  [RequireComponent(typeof(CharacterStatusBhvr))]
  [RequireComponent(typeof(Directional))]
  [RequireComponent(typeof(SpriteAnimate))]
  public class ActionBindingBhvr : MonoBehaviour
  {

    
    /// <summary>
    ///   绑定的角色ID
    /// </summary>
    public long actorId;

    protected GameObject bindingGobj;

    protected CharacterStatusBhvr targetStatusBhvr = null;
    protected Directional targetDirectional = null;
    protected SpriteAnimate targetSpriteAnimate = null;
    protected Navigable targetNavigable = null;

    protected CharacterStatusBhvr statusBhvr = null;
    protected Directional directional = null;
    protected SpriteAnimate spriteAnimate = null;
    
    protected void Start()
    {

      // 获取角色对象
      bindingGobj = TS.GetActorGameObject(actorId);

      if( bindingGobj == null )
	{
	  Destroy( gameObject );
	  return;
	}

      
      // 获取目标对象的组件
      targetStatusBhvr = bindingGobj.GetComponent<CharacterStatusBhvr>();
      targetDirectional = bindingGobj.GetComponent<Directional>();
      targetSpriteAnimate = bindingGobj.GetComponent<SpriteAnimate>();
      targetNavigable = bindingGobj.GetComponent<Navigable>();

      if( targetStatusBhvr == null || targetDirectional == null || 
	  targetSpriteAnimate == null || targetNavigable == null )
	{
	  Destroy( gameObject );
	  return;
	}

      // 监控目标对象的状态，方向，帧变化
      targetStatusBhvr.statusStartHandler += OnTargetStatusChange;
      targetDirectional.directionChangeHandler += OnTargetDirectionChange;
      targetSpriteAnimate.spriteAnimation.currentIndexChange += OnTargetAnimationCurrentIndexChange;
      targetNavigable.localPositionChangeHandle += OnTargetLocalPositionChange;

      // 获取当前特效组件
      statusBhvr = GetComponent<CharacterStatusBhvr>();
      directional = GetComponent<Directional>();
      spriteAnimate = GetComponent<SpriteAnimate>();

      // 初始化当前特效对象的状态，方向和帧索引
      statusBhvr.Status = targetStatusBhvr.Status;
      directional.Direction = targetDirectional.Direction;
      spriteAnimate.spriteAnimation.currentIndex = targetSpriteAnimate.spriteAnimation.currentIndex;
      transform.localPosition = bindingGobj.transform.localPosition;

      LateStart();

    }

    protected void OnDestroy()
    {

      if( targetStatusBhvr != null )
	targetStatusBhvr.statusStartHandler -= OnTargetStatusChange;
      if( targetDirectional != null )
	targetDirectional.directionChangeHandler -= OnTargetDirectionChange;
      if( targetSpriteAnimate != null )
	targetSpriteAnimate.spriteAnimation.currentIndexChange -= OnTargetAnimationCurrentIndexChange;
      if( targetNavigable != null )
	targetNavigable.localPositionChangeHandle -= OnTargetLocalPositionChange;
      
      
    }

    
    protected virtual void LateStart()
    {
      // do nothing
    }


    protected virtual void OnTargetStatusChange(CharacterStatus status)
    {
      statusBhvr.Status = status;
    }

    protected virtual void OnTargetDirectionChange(EightDirection direction)
    {
      directional.Direction = direction;
    }

    protected virtual void OnTargetAnimationCurrentIndexChange(int index)
    {
      spriteAnimate.spriteAnimation.currentIndex = index;
      if( index > spriteAnimate.spriteAnimation.MaxIndex )
	{
	  transform.localScale = Vector3.zero;
	  Destroy( gameObject );
	}
    }

    protected virtual void OnTargetLocalPositionChange(Vector3 localPosition)
    {
      transform.localPosition = localPosition;
    }


  }
  
}
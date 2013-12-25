/**
 * Binding Behaviour
 * Date: 2013/11/9
 * Author: zzc
 */

using UnityEngine;
using TangScene;
using Tang;

namespace TangEffect
{

  [ RequireComponent( typeof(SpriteAnimate) ) ]
  public class BindingBhvr : MonoBehaviour
  {

    /// <summary>
    ///   绑定的角色目标
    /// </summary>
    public long targetId;

    private GameObject targetGobj = null;
    private Navigable targetNavigable = null;
    private SpriteAnimate spriteAnimate = null;

    void Start()
    {

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

      spriteAnimate = GetComponent<SpriteAnimate>();
      if( spriteAnimate == null )
	{
	  Destroy( gameObject );
	  return;
	}

      // 监控目标对象的位置变化
      targetNavigable.localPositionChangeHandle += OnTargetLocalPositionChange;

      // 初始化当前特效对象位置
      transform.localPosition = targetGobj.transform.localPosition;

      // 注册最后一帧的处理
      spriteAnimate.lateLastFrameHandler += LateLastFrame;

      //spriteAnimate.spriteAnimation.currentIndexChange += OnSpriteIndexChange;

    }

    void OnDestroy()
    {
      if( targetNavigable != null )
	targetNavigable.localPositionChangeHandle -= OnTargetLocalPositionChange;
      if( spriteAnimate != null )
	spriteAnimate.lateLastFrameHandler -= LateLastFrame;
    }

    private void OnTargetLocalPositionChange(Vector3 localPosition)
    {
      transform.localPosition = localPosition;
    }

    private void LateLastFrame(SpriteAnimation spriteAnimation)
    {
      Destroy( gameObject );
    }

    /*
    private void OnSpriteIndexChange( int index )
    {
      if( spriteAnimate.spriteAnimation.MaxIndex == index )
	{
	  Destroy( gameObject );
	}
    }*/

  }
}
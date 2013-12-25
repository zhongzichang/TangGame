/**
 *
 * Play on active
 * 当游戏对象是活动的时候将播放动画
 * Date: 2013/11/28
 * Author: zzc
 */

using UnityEngine;
using Tang;

namespace TangScene
{

  [ RequireComponent( typeof(SpriteAnimate) ) ]
  public class PlayOnActive : MonoBehaviour
  {

    private SpriteAnimation spriteAnimation = null;

    void Awake()
    {
      SpriteAnimate spriteAnimate = GetComponent<SpriteAnimate>();
      if( spriteAnimate != null )
	{
	  spriteAnimation = spriteAnimate.spriteAnimation;
	  spriteAnimation.playOnStart = true;

	}

      
    }
    
    void OnEnable()
    {
      if( spriteAnimation != null )
	spriteAnimation.Play();
    }

    void OnDisable()
    {
      if( spriteAnimation != null )
	spriteAnimation.Stop();
    }
    

  }
}
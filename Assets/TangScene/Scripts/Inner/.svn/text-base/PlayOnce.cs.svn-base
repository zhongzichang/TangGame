/**
 *
 * Play once
 *
 * 当前动画只播放一次
 *
 * Date: 2013/11/28
 * Author: zzc
 */

using UnityEngine;
using Tang;

namespace TangScene
{
  [ RequireComponent( typeof(SpriteAnimate) ) ]
  public class PlayOnce : MonoBehaviour
  {
    private SpriteAnimation spriteAnimation = null;
    
    void Awake()
    {
      SpriteAnimate spriteAnimate = GetComponent<SpriteAnimate>();
      if( spriteAnimate != null )
	{
	  spriteAnimation = spriteAnimate.spriteAnimation;
	  spriteAnimation.playOnStart = true;
	  spriteAnimation.loop = 0;

	  spriteAnimate.lateLastFrameHandler = LateLastFrame;	  
	}

    }

    void LateLastFrame(SpriteAnimation spriteAnimation)
    {
      gameObject.SetActive(false);
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
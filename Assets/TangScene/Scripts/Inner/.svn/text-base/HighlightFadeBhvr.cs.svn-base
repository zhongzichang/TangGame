/**
 *
 * highlight behaviour
 *
 * Date: 2013/10/28
 * Author: zzc
 */
using UnityEngine;

namespace TangScene
{
  public class HighlightFadeBhvr : MonoBehaviour
  {

    public const float FADE_PERIOD = 2F;
    public const float FADE_UNIT_TIME = 0.2F;

    private float remainTime = 0;
    private int lastLevel = 0;

    private SpriteAnimate spriteAnimate = null;

    void Update()
    {

      remainTime -= Time.deltaTime;
      
      if( remainTime > 1 )
	{
	  int level = (int) ( remainTime / FADE_UNIT_TIME );
	  if(level < lastLevel)
	    {
	      spriteAnimate.ChangeSpecularLevel(level);
	      lastLevel = level;
	    }
	}
      else
	{
	  spriteAnimate.RevertSpecular();
	  this.enabled = false;
	}
      
    }

    void OnEnable()
    {

      if( spriteAnimate == null )
	spriteAnimate = GetComponent<SpriteAnimate>();

      remainTime = FADE_PERIOD;
      lastLevel = (int) (FADE_PERIOD / FADE_UNIT_TIME);

    }
  }
}
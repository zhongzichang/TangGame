/**
 * Animation factory
 * Date: 2013/11/7
 * Author: zzc
 */

using Tang;
using TangScene;

namespace Tang
{
  public class AnimationFactory
  {

    /// <summary>
    ///   创建一个简单动画
    /// <param name="playOnStart">创建后即播放</param>
    /// <param name="assetSetId">资源集ID</param>
    /// </summary>
    public static TsAnimation SimpleAnimation(bool playOnStart, int assetSetId)
    {
      return SimpleAnimation(-1, playOnStart, assetSetId );
    }


    /// <summary>
    ///   创建一个简单动画
    /// </summary>
    public static TsAnimation SimpleAnimation(int loop, bool playOnStart, int assetSetId)
    {
      
      TsAnimation animation = new TsAnimation();
      animation.playOnStart = playOnStart;
      animation.loop = loop;
      
      TsLayer layer = new TsLayer();
      layer.name = BodyLayer.NAME;
      
      TsSprite sprite = new TsSprite();
      sprite.name = assetSetId.ToString();

      layer.sprite = sprite;
      animation.layers = new TsLayer[]{ layer };

      return animation;

    }
  }
}
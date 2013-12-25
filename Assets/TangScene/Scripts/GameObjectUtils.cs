/**
 * Created by emacs
 * Date: 2013/10/12
 * Author: zzc
 */
using UnityEngine;

namespace TangScene
{
  public class GameObjectUtils
  {

    public static void DestroyChildren(Transform transform)
    {
      foreach(Transform child in transform)
	{
#if UNITY_EDITOR
	  GameObject.DestroyImmediate( child.gameObject );
#else
	  GameObject.Destroy( child.gameObject );
#endif
	}
    }
  }
}
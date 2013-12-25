/**
 * Created by emacs
 * Date: 2013/10/10
 * Author: zzc
 */

using UnityEngine;
using Tang;

namespace TangScene
{
  public class Selectable : MonoBehaviour
  {

    private SpriteAnimate spriteAnimate;

    void Start()
    {
      spriteAnimate = GetComponent<SpriteAnimate>();
      if( spriteAnimate != null )
	spriteAnimate.lateSpriteReadyHandler += LateSpriteReady;

    }

    void OnEnable()
    {
      // 开启碰撞器
      MeshCollider[] colliders = GetComponentsInChildren<MeshCollider>();
      for(int i=0; i<colliders.Length; i++ )
	{
	  colliders[i].enabled = true;
	}
    }

    void OnDisable()
    {
      // 停用碰撞器
      MeshCollider[] colliders = GetComponentsInChildren<MeshCollider>();
      for(int i=0; i<colliders.Length; i++ )
	{
	  colliders[i].enabled = false;
	}
      
    }
    
    public void LateSpriteReady(TTSprite sprite)
    {

      if( sprite.GetComponent<MeshCollider>() == null )
	{
	  MeshFilter mf = sprite.GetComponent<MeshFilter>();
	  if( mf != null )
	    {
	      MeshCollider mc = sprite.gameObject.AddComponent<MeshCollider>();
#if UNITY_EDITOR
	      mc.sharedMesh = mf.sharedMesh;
#else
	      mc.sharedMesh = mf.mesh;
#endif
	      mc.isTrigger = true;

	      if( !enabled )
		{
		  mc.enabled = false;
		}
	    }
	}

      
    }
  }
}
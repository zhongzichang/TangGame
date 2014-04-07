/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/8/12
 * Time: 17:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using UnityEditor;

namespace Tang
{
  /// <summary>
  /// Description of AnimationGenerator.
  /// </summary>
  public class AnimationGenerator
  {
		
		
    /// <summary>
    /// 生成 NPC 动画
    /// </summary>
    /// <param name="gobj">npc 的 prefab</param>
    public static void GenerateAnimation(GameObject obj){
			
      string spritePrefabPath = AssetDatabase.GetAssetPath(obj);
      string[] splits = spritePrefabPath.Split(new Char[]{'/'});
      if(splits.Length > 4){
				
	string animationsDir = String.Join("/", splits, 0, splits.Length - 4) + "/Animations";
				
	// 判断该对象是不是
	TASprite sprite = obj.GetComponent<TASprite>();

	if(sprite != null) {
					
	  GameObject animationObj = new GameObject();
	  animationObj.name = obj.name;
	  SpriteAnimation animation = animationObj.AddComponent<SpriteAnimation>();
					
	  // animation.
	  SpriteLayer clothesLayer = new BodyLayer(obj.GetComponent<TASprite>());
	  animation.PutLayer(clothesLayer);
	  animation.DestroyChildren();
	  animation.playOnStart = true;
					
	  string prefabPath = animationsDir + "/" + animationObj.name + ".prefab";
	  UnityEngine.Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath);
	  PrefabUtility.ReplacePrefab(animationObj, prefab, ReplacePrefabOptions.ConnectToPrefab);
					
	  // destory game object
	  GameObject.DestroyImmediate(animationObj);
					
	}
      }
    }
  }
}

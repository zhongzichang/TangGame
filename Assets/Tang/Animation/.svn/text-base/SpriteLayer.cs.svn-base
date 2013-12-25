/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/8/6
 * Time: 17:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

namespace Tang
{
  /// <summary>
  /// Description of SpriteLayer.
  /// </summary>
  [Serializable]
  public class SpriteLayer
  {

    public string name; // 名称
    public TTSprite spritePrefab; // 精灵的 prefab
    public int frameDelay; // 延迟多少帧后开始播放，相对于上级动画
    public bool hiddenBeforeBegin; // 在开始之前隐藏
    public bool hiddenAfterEnd; // 该 sprite 播放完成后是否隐藏

    public SpriteLayer(string name){
      this.name = name;
    }
  }

}

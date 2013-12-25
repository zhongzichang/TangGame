/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/12/7
 * Time: 2:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

namespace TangGame
{
  /// <summary>
  /// Description of PosAutoNavBean.
  /// </summary>
  public class PosAutoNavBean : SceneAutoNavBean
  {
    public Vector3 pos;
    
    public PosAutoNavBean(Vector3 pos, short[] portalIds) : base(portalIds)
    {
      this.pos = pos;
    }
  }
}

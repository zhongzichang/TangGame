using UnityEngine;
using System.Collections;

namespace TangUtils{
  public class GridUtil{
    public const int WIDTH = 32;
    public const int HEIGHT = 16;
    /// <summary>
    /// 格子坐标转世界坐标
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public static Vector3 PointToVector3(Point point){
      return new Vector3(point.x*WIDTH,0,-point.y*HEIGHT);
    }
    /// <summary>
    /// 格子坐标转世界坐标
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static Vector3 PointToVector3(int x,int y){
      return new Vector3(x*WIDTH,0,-y*HEIGHT);
    }
    /// <summary>
    /// 世界坐标转换格子坐标
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    public static Point Vector3ToPoint( Vector3 position){
			
      int x = (int)(position.x / WIDTH);
      int y = -(int)(position.z / HEIGHT);
			
      return new Point(x,y);
			
    }
    /// <summary>
    /// 格子距离转换为客户端距离
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static float SeverToClientDistance(float distance){
      return WIDTH * distance;
    }
  }
}

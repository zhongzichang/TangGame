/*
 * Created by emacs
 * Date: 2013/9/11
 * Author: zzc
 */

using UnityEngine;

namespace TangScene
{
  public class ShowClickPosition : MonoBehaviour
  {
    public Vector3 position = Vector3.zero;
    public Vector2 grid = Vector2.zero;

    public void OnSceneClick(Vector3 position)
    {
      this.position = position;
      this.grid = new Vector2( (int) position.x / Grid.WIDTH, 
			       (int)( -position.z / Grid.HEIGHT ));
    }

    void Start()
    {
      CommonDelegates.locationHandler += OnSceneClick;
    }

  }
}
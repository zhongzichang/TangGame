using UnityEngine;
using System.Collections;


namespace TangScene
{
  
  [ExecuteInEditMode]
  public class SceneryBhvr : MonoBehaviour {

    private SceneGridsBhvr sceneGridsBhvr;

    // Use this for initialization
    void Start () {

      Vector3 position = transform.localPosition;

      if( position.y < 0 )
	transform.localPosition = new Vector3(position.x, 0F, position.z);
    }


  }
}

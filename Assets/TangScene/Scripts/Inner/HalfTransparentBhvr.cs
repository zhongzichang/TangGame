using UnityEngine;
using System.Collections;

namespace TangScene
{

  [RequireComponent( typeof(MeshCollider) ),
   RequireComponent( typeof(Locational) )]
  public class HalfTransparentBhvr : MonoBehaviour
  {

    private MeshFilter mf;
    private MeshCollider mc;

    // Use this for initialization
    void Start () {

      mf = GetComponent<MeshFilter>();
      mc = GetComponent<MeshCollider>();

      mc.isTrigger = true;

#if UNITY_EDITOR
      mc.sharedMesh = mf.sharedMesh;
#else
      mc.sharedMesh = mf.mesh;
#endif

      transform.localPosition = new Vector3(0,3,0);

    }

    void OnTriggerEnter( Collider collider )
    {
      collider.SendMessage("OnBecameHalfTransparent");
    }

    void OnTriggerExit( Collider collider )
    {
      collider.SendMessage("OnBecameReal");
    }

  }

}
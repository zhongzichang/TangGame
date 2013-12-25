using UnityEngine;

namespace TangScene
{
  public class TsBhvr : MonoBehaviour
  {

 
    void Start()
    {

      DontDestroyOnLoad(gameObject);
 
    }

    void OnApplicationQuit()
    {
      Cache.isShuttingDown = true;
    }
 
  }
}
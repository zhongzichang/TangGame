/**
 * do not destroy on load
 *
 * Date: 2013/11/23
 * Author: zzc
 */

using UnityEngine;

namespace TangGame
{

  public class DontDestroyOnLoad : MonoBehaviour
  {
    void Start()
    {
      DontDestroyOnLoad( gameObject );
    }
  }
  
}
/**
 * Loop Destroy behaviour
 * Date: 2013/11/11
 * Author: zzc
 */

using UnityEngine;

namespace TangEffect
{
  public class LoopDestroyBhvr : MonoBehaviour
  {
    public int m_loop = 0;

    public int loop
    {
      get
	{
	  return m_loop;
	}
      set
	{
	  
	  m_loop = value;
	  if( m_loop == -1 )
	    Destroy( gameObject);
	  
	}
    }
    
  }
}
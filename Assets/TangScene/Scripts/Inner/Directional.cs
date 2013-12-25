/**
 * Created by emacs
 * 
 * Date: 2013/9/23
 * Author: zzc
 */

using UnityEngine;

namespace TangScene
{

  [ ExecuteInEditMode ]
  public class Directional : MonoBehaviour
  {


    public delegate void DirectionChange(EightDirection direction);
    public DirectionChange directionChangeHandler;

    public EightDirection m_direction;

    public EightDirection Direction
    {
      get
	{
	  return m_direction;
	}
      set
	{
	  m_direction = value;
	  if( directionChangeHandler != null )
	    directionChangeHandler( m_direction );
	}
    }
    
  }
}
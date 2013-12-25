/**
 * Created by emacs
 *
 * Date: 2013/9/30
 * Author: zzc
 */

using UnityEngine;
using System.Collections.Generic;

namespace Tang
{
  public class ComponentSelector
  {
    public static List<T> Filter<T>(Transform transform) where T : Component
    {
      List<T> componentList = new List<T>();

      if( transform.childCount > 0 )
	{
	  foreach( Transform child in transform )
	    {
	      T component = child.GetComponent<T>(); 
	      if( component != null )
		componentList.Add(component );

	      componentList.AddRange( Filter<T>(child) );
	    }
	}
      return componentList;
    }   
  }
}
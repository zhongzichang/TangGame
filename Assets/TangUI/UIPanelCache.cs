/**
 * UI Panel Cache
 * Author: zzc
 * Date: 2014/4/3
 */
using System.Collections.Generic;
using UnityEngine;

namespace TangUI
{
  public class UIPanelCache
  {

    private Dictionary<string,List<GameObject>> table = 
      new Dictionary<string, List<GameObject>> ();

    public GameObject GetInactiveGobj (string name)
    {
      if( table.ContainsKey(name) )
	{
	  foreach(GameObject gobj in table[name])
	    {
	      if( !gobj.activeSelf )
		return gobj;
	    }
	}
      return null;
    }

    public void Put (string name, GameObject gobj)
    {
      if (table.ContainsKey (name)) {
	table [name].Add (gobj);
      } else {
	List<GameObject> list = new List<GameObject> ();
	list.Add (gobj);
	table.Add (name, list);
      }
    }

  }
}
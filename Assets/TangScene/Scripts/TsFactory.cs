/*
 * Created by emacs
 * Date: 2013/9/13
 * Author: zzc
 */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace TangScene
{
  public class TsFactory
  {

    private static TsFactory instance = null;
    private Dictionary<Type, CreateGobj> methodTable = new Dictionary<Type, CreateGobj>();

    
    public static TsFactory Instance
    {
      get
	{
	  return instance;
	}
    }

    public static TsFactory NewInstance()
    {
      TsFactory factory = new TsFactory();
      
      return factory;
    }
    
    private delegate GameObject CreateGobj(TsObject tsobj);
    
    private TsFactory()
    {
      
    }

    public GameObject NewGobj(TsObject tsobj)
    {
      Type type = tsobj.GetType();
      if( methodTable.ContainsKey( type ) )
	{
	  return methodTable[type](tsobj);
	}
      return null;
    }

    private void Init()
    {
      
    }


    private GameObject CreatePortalGobj(Portal portal)
    {
      return null;
    }

    private GameObject CreateStageGobj(Stage stage)
    {
      return null;
    }

    private GameObject CreateSceneryGobj(Scenery scenery)
    {
      return null;
    }


  }
}
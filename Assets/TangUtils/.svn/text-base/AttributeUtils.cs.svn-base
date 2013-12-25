/**
 * Created by emacs
 * Date: 2013/10/15
 * Author: zzc
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace TangUtils
{

  public class AttributeUtils
  {

    private static readonly object m_syncObj = new object();
    private static bool isInitialized = false;
    // attribute type => type
    private static Dictionary<Type, List<Type>> attributeTypeTable = new Dictionary<Type, List<Type>>();
    
    public static List<Type> GetTypesWith<TAttribute>( bool inherit ) where TAttribute : System.Attribute
    {
      lock( m_syncObj )
	{
	  if( !isInitialized )
	    {
	      InitAttributeTypeTable(true);
	    }
	  isInitialized = true;
	}

      Type key = typeof( TAttribute );
      if( attributeTypeTable.ContainsKey( key ) )
	return attributeTypeTable[key];
      else
	return null;
    }


    private static void InitAttributeTypeTable(bool inherit)
    {
      foreach( Assembly assembly in AppDomain.CurrentDomain.GetAssemblies() )
	{
	  foreach( Type type in assembly.GetTypes() )
	    {
	      object[] attributes =  type.GetCustomAttributes( inherit );
	      if( attributes.Length > 0 )
		{
		  foreach( object attribute in attributes )
		    {
		      Type attributeType = attribute.GetType();
		      if( attributeTypeTable.ContainsKey( attributeType ) )
			{
			  List<Type> typeList = attributeTypeTable[attributeType];
			  typeList.Add( type);
			}
		      else
			{
			  List<Type> typeList = new List<Type>();
			  typeList.Add( type );
			  attributeTypeTable.Add( attributeType, typeList );
			}
		    }
		}
	    }
	}
    }
  }
}
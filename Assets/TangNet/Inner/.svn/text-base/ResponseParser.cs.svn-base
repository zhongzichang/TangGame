/*
 * Response parser
 *
 * User: zzc
 * Date: 2013/3/18
 *
 * Reconstruct - use Attribute for Response
 * Edit: zzc 
 * Date: 2013/10/25
 * 
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TangUtils;

namespace TangNet
{
  /// <summary>
  /// Description of ResponseParser.
  /// </summary>
  public class ResponseParser
  {

    protected Dictionary<string, MethodInfo> callbackMap = new Dictionary<string, MethodInfo>();
    protected Dictionary<string, MethodInfo> callbackWithCodeMap = new Dictionary<string, MethodInfo>();

    public ResponseParser()
    {
      List<Type> typeList = AttributeUtils.GetTypesWith<ResponseAttribute>( true );
      if( typeList != null )
	foreach( Type type in typeList )
	  {
	    RegisterResponse(type);
	  }
    }

    protected void RegisterResponse(Type type)
    {
			
      object[] objs = type.GetCustomAttributes(true);
			
      foreach( object obj in objs )
	{
	  if( obj is ResponseAttribute )
	    {

	      MethodInfo method = type.GetMethod("Parse", new Type[] { typeof(MsgData)} );

	      string methodName = ((ResponseAttribute)obj).GetName();

	      if( method != null )
		callbackMap[ methodName ] = method;
	      
	      method = type.GetMethod("Parse", new Type[] {typeof(short), typeof(MsgData)} );
	      if( method != null )
		callbackWithCodeMap[ methodName ] = method;
	      
	    }

	}
    }


    public virtual Response Parse(string name, MsgData data)
    {
      return Parse(name, 0, data);
    }

    public virtual Response Parse(string name, short statusCode, MsgData data)
    {

      // if status == 0
      if( statusCode == 0 )
	{
	  if( callbackMap.ContainsKey( name ) )
	    return callbackMap[name].Invoke(null, new MsgData[] {data}) as Response;

	  else if( callbackWithCodeMap.ContainsKey( name ) )
	    return callbackWithCodeMap[name].Invoke(null, new object[]{statusCode, data}) as Response;

	}
      else
	{
	  // 其他状态码
	  if( callbackWithCodeMap.ContainsKey( name ) )
	    return callbackWithCodeMap[name].Invoke(null, new object[]{statusCode, data}) as Response;
	}
	return null;
    }
  }
}

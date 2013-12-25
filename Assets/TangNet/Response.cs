/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/18
 * Time: 20:58
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangNet
{

  [ System.AttributeUsage( System.AttributeTargets.Class ) ]
  public class ResponseAttribute : System.Attribute
  {
    private string name;
    public ResponseAttribute(string name)
    {
      this.name = name;
    }

    public string GetName()
    {
      return name;
    }
  }


  /// <summary>
  /// Description of Response.
  /// </summary>
  public class Response
  {
    
    public const short DEFAULT_STATUS_CODE = 0;

    private string name;
    private short statusCode;

    public string Name
    {
      get
        {
	  return name;
        }
      set
	{
	  name = value;
	}
    }

    public short StatusCode
    {
      get
	{
	  return statusCode;
	}
      set
	{
	  statusCode = value;
	}
    }


    public Response(string name)
    {
      this.name = name;
      this.statusCode = DEFAULT_STATUS_CODE;
    }
    

    public Response(string name, short statusCode)
    {
      this.name = name;
      this.statusCode = statusCode;
    }

  }
}

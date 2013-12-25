using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  /// <summary>
  /// Description of ToMapResult.
  /// </summary>
  [Response(NAME)]
  public class ToMapResult : Response
  {

    public const string NAME = "toMap_RESULT";
    public short mapId;
    public short x;
    public short y;
		public string mapName;

    public ToMapResult () : base(NAME)
    {
    }

    public static ToMapResult Parse (MsgData data)
    {

      ToMapResult result = new ToMapResult ();
      result.mapId = data.GetShort(0);
      result.x = data.GetShort(1);
      result.y = data.GetShort(2);
			result.mapName = data.GetString(3);
      return result;


    }
  }
}
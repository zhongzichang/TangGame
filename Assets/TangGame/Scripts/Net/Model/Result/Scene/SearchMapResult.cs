/// <summary>
/// xbhuang
/// 2013/11/22
/// </summary>
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TangNet;

namespace TangGame.Net{
  [Response(NAME)]
  public class SearchMapResult : Response{
    public const string NAME = "searchMap_RESULT";
    public short mapId;
    public List<short> portalIds;
    public SearchMapResult () : base(NAME)
    {
      portalIds = new List<short>();
    }
    public static SearchMapResult Parse(MsgData data){
      int index = 0;
      SearchMapResult result= new SearchMapResult();
      result.mapId = data.GetShort(index++);
      MsgData portalIdsMsg = data.GetMsgData(index++);
      for(int i = 0;i < portalIdsMsg.Size; i++){
        result.portalIds.Add(portalIdsMsg.GetShort(i));
      }
      return result;
    }
  }
}
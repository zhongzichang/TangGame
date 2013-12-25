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
  public class SearchNpcResult : Response{
    public const string NAME = "searchNPC_RESULT";
    public int npcId = 0;
    public List<short> portalIds;
    public SearchNpcResult () : base(NAME)
    {
      portalIds = new List<short>();
    }
    public static SearchNpcResult Parse(MsgData data){
      int index = 0;
      SearchNpcResult result= new SearchNpcResult();
      result.npcId = data.GetInt(index++);
      MsgData mapIdsMsg = data.GetMsgData(index++);
      for(int i = 0;i < mapIdsMsg.Size; i++){
        result.portalIds.Add(mapIdsMsg.GetShort(i));
      }
      return result;
    }
  }
}
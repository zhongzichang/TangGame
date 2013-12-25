using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class ShowVeinResult : Response
{
    public const string NAME = "showVein_RESULT";

    public List<Vein> veinList = new List<Vein>();
    public Hashtable acupointTable = new Hashtable();

    public ShowVeinResult() : base(NAME)
    {
    }

    public static ShowVeinResult Parse(MsgData data)
    {

        ShowVeinResult result = new ShowVeinResult();

        for(int i = 0; i < data.Size; i++)
        {
            MsgData msgData = data.GetMsgData(i);

            Vein vein = new Vein();
            vein.id = msgData.GetShort(0);
            vein.type = msgData.GetShort(1);
            MsgData acupointData = msgData.GetMsgData(2);

            result.veinList.Add(vein);

            List<Acupoint> acupointList = new List<Acupoint>();
            int index = 0;
            Acupoint temp = null;
            while(index < acupointData.Size)
            {
                temp = new Acupoint();
                temp.id = acupointData.GetShort(index++);
                temp.position = acupointData.GetShort(index++);
                acupointList.Add(temp);
            }
            int type = vein.type;
            result.acupointTable[type] = acupointList;
        }


        return result;
    }
}
}

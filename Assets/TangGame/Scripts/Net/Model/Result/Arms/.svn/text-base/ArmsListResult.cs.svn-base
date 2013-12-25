/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// 帮会列表信息
public class ArmsListResult : Response
{
    public const string NAME = "armsList_RESULT";

    public int page = 1;
    public int pageTotal = 1;
    public List<Arms> armsList = new List<Arms>();


    public ArmsListResult() : base(NAME)
    {
    }

    public static ArmsListResult Parse(MsgData data)
    {
        ArmsListResult result = new ArmsListResult();

        if(data == null)
        {
            return result;
        }

        int index = 0;
        result.page = data.GetShort(index++);
        result.pageTotal = data.GetShort(index++);

        MsgData armsData = data.GetMsgData(index++);
        for(int i = 0; i < armsData.Size; i++)
        {
            result.armsList.Add(Arms.Parse(armsData.GetMsgData(i)));
        }

        return result;
    }
}
}

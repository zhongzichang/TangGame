/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 家族信息
public class ArmsMessageResult : Response
{
    public const string NAME = "armsMessage_RESULT";

    public Arms arms = new Arms();
    public int leaderGenre;//帮主流派
    public int leaderLevel;//帮主等级
    public string leaderSeat;//帮主所在地，暂无
    public string leaderTitle;//帮主称号，暂无
    public int officer;//主玩家在帮会的职位
    public bool isApplyMv;//1:闪2：不闪

    public ArmsMessageResult() : base(NAME)
    {
    }

    public static ArmsMessageResult Parse(MsgData data)
    {
        ArmsMessageResult result = new ArmsMessageResult();
        int index = 0;
        Arms arms = result.arms;

        arms.id = data.GetLong(index++);//帮会编号
        arms.name = data.GetString(index++);//帮会名字
        arms.leaderId = data.GetLong(index++);//帮主编号
        arms.leaderName = data.GetString(index++);//帮主名字

        result.leaderGenre = data.GetShort(index++);//帮主流派
        result.leaderLevel = data.GetShort(index++);//帮主等级
        result.leaderSeat = data.GetString(index++);//帮主所在地，暂无
        result.leaderTitle = data.GetString(index++);//帮主称号，暂无


        arms.campId = data.GetShort(index++);//所属阵营
        arms.flag = data.GetShort(index++);//旗帜
        arms.cloths = data.GetShort(index++);//服装
        arms.describe = data.GetString(index++);//公告

        arms.memberSize = data.GetShort(index++);//帮会人数
        arms.maxPeople = data.GetShort(index++);//帮会人数最大值
        arms.welfare = data.GetShort(index++);//帮会长福利


        data.Get(index++); //领地资源
        data.GetInt(index++);// level
        data.GetInt(index++); // actionValue
        data.GetInt(index++);//liveness

//			this.territoryIdList = [];
//			this.territoryNameList = [];
//			var tempArr:Array = data.GetString(index++).split(";");
//
//			for each(var str:String in tempArr)
//			{
//				if(str)
//				{
//					var strArr:Array = str.split(",");
//					if(strArr.length > 1)
//					{
//						this.territoryIdList.push(int(strArr[0]));//驻守领地
//						this.territoryNameList.push(String(strArr[1]));//领地名称
//					}
//				}
//			}
//
//			this.depot.decode(data.getMsgData(index++));//仓库数据

        result.officer = data.GetShort(index++);//主玩家在帮会的职位
        result.isApplyMv = data.GetInt(index++) == 1;//1:闪2：不闪
        return result;
    }
}
}

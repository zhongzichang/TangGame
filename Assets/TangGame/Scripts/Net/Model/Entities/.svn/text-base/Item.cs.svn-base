/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/7
 * Time: 13:14
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of Item.
/// </summary>
public class Item
{
    public int itemId;
    /** 条件 编号 */
    public long id;
    /** 条件 名称 */
    public string name;
    /** 条件 类型 */
    public short type;
    /** 条件 数量 */
    public int num;
    /** 条件 字符串 */
    public string str;
    /** 原始条件数量 */
    public int oldNum;

    public Item()
    {

    }
    public static Item Parse(MsgData data)
    {
        int index=0;
        Item mItem=new Item();
        while(index < data.Size)
        {
            mItem.itemId=data.GetInt(index++);
            mItem.num=data.GetInt(index++);
        }
        return mItem;
    }
}
}

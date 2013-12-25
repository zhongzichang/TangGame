/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 23:10
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Achieve.
/// </summary>
public class Achieve
{
    /** 编号 */
    private long id;
    /** 名称 */
    private string name;
    /** 介绍 */
    private string node;
    /** 显示类别 */
    private short showType;
    /** 类别 */
    private short searchType;
    /** 图片 */
    private short img;
    /** 成就点数 */
    private int points;
    /** 完成数量 */
    private int num;
    /** 条件 */
    private List<Item> condition;
    /** 奖励 */
    private List<Item> reward;
    private int version;

}
}

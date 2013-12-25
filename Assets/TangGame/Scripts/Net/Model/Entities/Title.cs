/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 17:25
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Title.
/// </summary>
public class Title
{
    public int id;
    public string name;
    /** 称号描述 */
    public string info;
    /** 附加属性 */
    public List<Effect> effectList;
}
}

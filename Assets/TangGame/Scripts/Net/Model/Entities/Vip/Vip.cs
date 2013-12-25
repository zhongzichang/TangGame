/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 18:26
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Vip.
/// </summary>
public class Vip
{
    public int id;
    public short level;
    public int days;
    public string featureStr;
    public Dictionary<short, Feature> featureMap;
}
}

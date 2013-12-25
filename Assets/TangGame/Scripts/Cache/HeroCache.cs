/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/4
 * Time: 18:46
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using TangGame.View;
using TGN = TangGame.Net;

namespace TangGame
{
/// <summary>
/// Description of HeroCache.
/// </summary>
public class HeroCache
{
    // charactor hero list
    public static List<TGN.SimpleHero> heroList = null;
    public static TGN.HeroNew player = null;
    public static Boolean updated=false;

    public static void Reset()
    {
        heroList = null;
        player = null;
        updated=false;
    }
}
}

/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:05
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of NewMailNoticePush.
/// </summary>
public class NewMailNoticePush : Response
{
    public const string NAME = "newMailNotice_PUSH";

    public NewMailNoticePush() : base(NAME)
    {

    }

    public static NewMailNoticePush Parse(MsgData data)
    {
        Debug.Log(">>====NewMailNoticePush====");
        return new NewMailNoticePush();
    }
}
}

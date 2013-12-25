/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 0:56
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新快捷栏
/// </summary>
public class UpdateShortcutKeyPush : Response
{
    public const string NAME = "updateShortcutKey_PUSH";

    public string shortcutKeys;
    public UpdateShortcutKeyPush() : base(NAME)
    {
    }
    public static UpdateShortcutKeyPush Parse(MsgData data)
    {
        UpdateShortcutKeyPush push = new UpdateShortcutKeyPush();
        push.shortcutKeys = data.GetString(0);
        return push;

    }
}
}

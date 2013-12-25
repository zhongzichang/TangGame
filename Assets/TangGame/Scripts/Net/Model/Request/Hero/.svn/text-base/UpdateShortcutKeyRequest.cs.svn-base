using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class UpdateShortcutKeyRequest : Request
{
    private string shortcutKeys;
    public UpdateShortcutKeyRequest(string shortcutKeys)
    {
        this.shortcutKeys=shortcutKeys;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.UPDATE_SHORTCUT_KEY);

            data.PutString(shortcutKeys);
            return data;
        }
    }
}
}

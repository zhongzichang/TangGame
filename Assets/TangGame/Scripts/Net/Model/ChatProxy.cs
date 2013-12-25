using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class ChatProxy
{

    public const int TYPE = 0x0300;
    /** 聊天 */
    public const int S_CHAT_MSG = TYPE + 0x0001;
    /** 展示聊天道具 */
    public const int S_SHOW_GOODS = TYPE + 0x0002;

}
}

using System;
using System.Text;
using PureMVC.Patterns;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class LoginProxy
{
    /** 第三方登陆请求 */
    public const short S_EXTERNAL_LOGIN = 0x0101;
    /** 直接登陆请求 */
    public const short S_INSIDE_LOGIN = 0x0102;
    /** 从QQ平台登陆 */
    public const short S_QQ_LOGIN = 0x0113;
    /** 注册用户 */
    public const short S_REGEDIT_USER = 0x0107;
    /** GM登陆 */
    public const short S_GM_LOGIN = 0x0109;
    /** 第三方重连 */
    public const short S_RECONNECT_1 = 0x0111;
    /** 直接重连 */
    public const short S_RECONNECT_2 = 0x0112;
    /** 获取角色 */
    public const short S_GET_HERO = 0x0108;

    /** 获取角色列表 */
    public const short S_HERO_LIST = 0x0103;
    /** 进入游戏 */
    public const short S_ENTER_GAME = 0x0104;
    /** 创建角色 */
    public const short S_CREATE_HERO = 0x0105;
    /** 删除角色 */
    public const short S_DELETE_HERO = 0x0106;
    /** 玩家是否成年 */
    public const short HERO_ADULT_MSG = 0x0114;
}
}


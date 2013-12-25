using UnityEngine;
using System.Collections;

namespace TangGame
{
/// 提示信息缓存,不弹出让玩家确认
public class PromptCache
{

    public static int updated = 0;
    public static string msg = "";
    public static Color color;

    /// 显示提示信息
    public static void Show(string data)
    {
        msg = data;
        color = ColorUtil.RED;
        updated++;
    }

    /// 显示提示信息
    public static void Show(string data, Color tColor)
    {
        msg = data;
        color = tColor;
        updated++;
    }

}
}
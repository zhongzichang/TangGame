using UnityEngine;
using System.Collections;
using TangGame.View;

namespace TangGame
{
/// 信息缓存
public class MessageCache
{

    public static int updated = 0;
    public static Queue msgQueue = new Queue();

    /// 添加一个信息提示
    public static void Add(PopMessageVo msg)
    {
        msgQueue.Enqueue(msg);
        updated++;
    }

}
}
/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using UnityEngine;
using System.Collections;
using TangGame.View;

namespace TangGame
{
/// 公告信息
public class NoticeCache
{

    /// 基础数据
    public static Hashtable list = new Hashtable();

    public static int updated = 0;
    /// 公告队列
    public static Queue queue = new Queue();

    /// 添加一个公告到缓存中，以便排列显示
    public static void Add(NoticeVo notice)
    {
        queue.Enqueue(notice);
        updated++;
    }

}
}
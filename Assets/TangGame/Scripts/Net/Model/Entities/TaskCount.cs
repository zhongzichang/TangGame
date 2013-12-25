/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 23:07
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of TaskCount.
/// </summary>
public class TaskCount
{
    /** 编号 */
    private long id;
    /** 名称 */
    private string name;
    /** 接取任务数量 */
    private int acceptNum;
    /** 删除任务数量 */
    private int delNum;
    /** 完成任务数量 */
    private int finishNum;
    /** 是否需要更新 */
    private bool isUpdate;
}
}

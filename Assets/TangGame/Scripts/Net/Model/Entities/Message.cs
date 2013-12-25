/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 11:09
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of Message.
/// </summary>
public class Message
{
    /** 当前对话npcId */
    public long npcId;
    /** 当前对话npc名称 */
    public string npcName;
    /** 当前对话npc图标 */
    public short npcIcon;
    /** 描述 */
    public string talk;
    /** 选项字符串(xxx$funName$type;xxx$funName$type)(type>-1:直接关闭面板 1:弹出接取任务面板 2:弹出完成任务面板) */
    public string options;
}
}

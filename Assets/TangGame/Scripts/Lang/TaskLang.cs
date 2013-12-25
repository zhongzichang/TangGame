using UnityEngine;
using System.Collections;
using System.Xml;

/// 文字
public class TaskLang
{
	/// <summary>
	/// 对话文本分割符
	/// </summary>
	public const char NOTE_DELIMITER = '|';
	/// <summary>
	/// Items分割符
	/// </summary>
	public const char ITEMS_DELIMITER = ';';
	/// <summary>
	/// Item分割符
	/// </summary>
	public const char ITEM_DELIMITER = ',';

  /// <summary>
  /// 分号分隔符
  /// </summary>
  public const char SEMICOLON_DELIMITER = ':';

    ///任务
    public const string TASK = "任务";
    ///主线
    public const string MAINLINE = "主线";
    ///支线
    public const string EXTENSION = "支线";
    ///日常
    public const string DAILY = "日常";
    ///其他
    public const string OTHER = "其他";
    ///已接任务
    public const string RECEIVED_TASK = "已接任务";
    ///未接任务
    public const string MISSED_TASK = "未接任务";
    ///任务详情
    public const string TASK_DETAIL = "详情";
    ///任务目标
    public const string TASK_TARGET = "目标：";
    ///任务描述
    public const string TASK_DESC = "描述：";
    ///任务奖励
    public const string TASK_AWARD = "奖励：";

    ///{0}说：
    public const string TASK_SAY = "{0}说：";
    ///铜币：
    public const string TASK_MONEY = "铜币：";
    ///经验：
    public const string TASK_EXP = "经验：";
    ///接受任务
    public const string TASK_RECEIVE = "接受任务";
    ///完成任务
    public const string TASK_COMPLETE = "完成任务";
    ///完成任务[{0}]
    public const string COMPLETE_XX_TASK = "完成任务[{0}]";
    /// <summary>
    /// 任务失败
    /// </summary>
    public const string TASK_FAILS="[c00fff](任务失败)[-]";

}

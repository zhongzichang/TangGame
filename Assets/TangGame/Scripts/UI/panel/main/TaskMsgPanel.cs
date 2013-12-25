using UnityEngine;
using System.Collections;
using nh.ui.cache;
using PureMVC.Interfaces;
using System.Collections.Generic;
using TangGame.Xml;

namespace nh.ui.main
{
  public class TaskMsgPanel : XBPanel
  {
    public new const string NAME = "TaskMsgPanel";
    /// <summary>
    /// 飞行按钮
    /// </summary>
    public UIButton flyButton;
    /// <summary>
    /// 隐藏按钮
    /// </summary>
    public UISprite hideButton;
    /// <summary>
    /// 任务追踪按钮
    /// </summary>
    public UISprite taskMsgButton;
    /// <summary>
    /// 任务追踪信息
    /// </summary>
    public UILabel taskInfoLabel;
    /// <summary>
    /// 任务名称
    /// </summary>
    public UILabel taskNameLabel;
    /// <summary>
    /// 任务图标
    /// </summary>
    public UISprite taskSprite;
    /// <summary>
    ///  剩余飞行次数
    /// </summary>
    public UILabel reNumOfFlyLabel;
    /// <summary>
    /// 显示任务追踪面板
    /// </summary>
    public Transform ShowBut;
    
    
    public Animator animator;
    TaskMsgMediator taskMsgMediator;
    private IFacade facade = PureMVC.Patterns.Facade.Instance;
    //    dth.TaskVo lastTrackingTask=null;
  
    void Start ()
    {
      taskMsgMediator = new TaskMsgMediator (this);
      facade.RegisterMediator (taskMsgMediator);
      taskMsgMediator.AddEvent ();
      taskMsgMediator.RefreshTrackingTask ();
      // TODO 飞行功能没有，屏蔽掉
      this.flyButton.gameObject.SetActive (false);
      animator = GetComponent<Animator>();
    }
    /// <summary>
    /// 更新追踪任务任务面板信息
    /// </summary>
    /// <param name="task">Task.</param>
    public void UpdateTrackTaskPanelInfo (TangGame.Xml.Task task)
    {
//      //获取当前的任务列表
//      List<TangGame.Net.HeroTask> heroTaskList = new List<TangGame.Net.HeroTask> (TangGame.TaskCache.HeroTaskDictionary.Values);
//      //根据配置ID反向查找到英雄任务
//      TangGame.Net.HeroTask heroTask = heroTaskList.Find (delegate (TangGame.Net.HeroTask htk) {
//        return htk.taskConfigId == task.Id;
//      });
      TangGame.Net.HeroTask heroTask = TangGame.TaskCache.GetTaskById(task.Id);
      this.SetTaskNameLabel (task);
      this.SetTaskTargetLabel (heroTask, task);
    }
    /// <summary>
    /// 设置任务名字以及类型
    /// </summary>
    public void SetTaskNameLabel (TangGame.Xml.Task xmlTask)
    {
      this.taskNameLabel.text = GameUtils.GetTaskType (xmlTask) + GameUtils.TaskReplace (xmlTask.Name);
    }


    /// <summary>
    /// 设置任务内容
    /// </summary>
    public void SetTaskTargetLabel (TangGame.Net.HeroTask heroTask, TangGame.Xml.Task xmlTask)
    {
      string str = "";
      if (heroTask == null) {
        str = xmlTask.Can_answer_that;
        this.taskInfoLabel.text = GameUtils.ReplaceColor (str);
        return;
      }
      switch (heroTask.state) {
      case TaskState.NONE:
        str = xmlTask.Can_answer_that;
        break;
      case TaskState.UNDO:
        str = xmlTask.In_chinese_characters;
        if (xmlTask.conditionItem.completeTaskConditionType != CompleteTaskConditionType.NPC) {
          str += heroTask.condition.num + "/" + heroTask.condition.oldNum;
        }
        break;
      case TaskState.UNTO:
        str = xmlTask.Complete_the_word;
        break;
      default:
        break;
      }
      str = GameUtils.ReplaceColor (str);
      this.taskInfoLabel.text = GameUtils.TaskReplace (str);
    }
    /// <summary>
    /// 设置飞行次数
    /// </summary>
    /// <param name="num"></param>
    public void SetReNumOfFlyLabel (int num)
    {
      this.reNumOfFlyLabel.text = GlobalLang.REMNUM.Replace ("{0}", num.ToString ());
    }
  }
}

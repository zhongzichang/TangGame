using UnityEngine;
using System.Collections;
using nh.ui.data;

namespace nh.ui.task
{
public class ContentPanelMediator : MonoBehaviour
{
		
		
    ContentPanel panel;
//    dth.TaskVo task;
//    dth.TaskBaseVo taskBase;
    public ContentPanelMediator(ContentPanel panel)
    {
        this.panel=panel;
//        DefaultReceivedTaskInfo();
//        UIEventListener.Get(this.panel.taskInfoPanel.gameObject).onClick+=TaskInfoPanelClick;
    }
		/*
    /// <summary>
    /// 默认已接任务信息
    /// </summary>
    public void DefaultReceivedTaskInfo()
    {
        if(dth.TaskCache.received.Count>0)
        {
            long taskId=dth.TaskCache.received[0].taskBase.id;
            SetReceivedTaskData(taskId);
        }
    }
    /// <summary>
    /// 默认未接任务信息
    /// </summary>
    public void DefaultCanTaskInfo()
    {
        if(dth.TaskCache.can.Count>0)
        {
            long taskId=dth.TaskCache.can[0].taskBase.id;
            SetCanTaskData(taskId);
        }
    }
    /// <summary>
    /// 设置未接任务信息
    /// </summary>
    /// <param name="id"></param>
    public void SetCanTaskData(long id)
    {
        dth.TaskVo task=dth.TaskCache.GetCanTaskById(id);
        if(task==null)return;
        this.SetTaskData(task);
    }
    /// <summary>
    /// 设置已接任务信息
    /// </summary>
    /// <param name="id"></param>
    public void SetReceivedTaskData(long id)
    {
        dth.TaskVo task=dth.TaskCache.GetReceivedTaskById(id);
        if(task==null)return;
        this.SetTaskData(task);
    }
    /// <summary>
    /// 设置任务信息
    /// </summary>
    /// <param name="task"></param>
    private void SetTaskData(dth.TaskVo task)
    {
        this.task=task;
        this.taskBase=task.taskBase;
        bool hasAward = (taskBase.coin>0&&taskBase.exp>0);
        bool hasGoodAward = (taskBase.awardGoods.Count!=0);
        this.panel.SetRewardPanelActive(hasAward);
        this.panel.SetGoodInfoPanelActive(hasGoodAward);
        this.panel.SetTaskRewardGoodListActive(hasGoodAward);
        this.panel.rewardPanel.gameObject.SetActive(hasAward);
        this.panel.goodInfoPanel.gameObject.SetActive(hasGoodAward);
        this.panel.taskRewardGoodList.gameObject.SetActive(hasGoodAward);
        this.RefreshInfoView();
        this.RefreshRewardLabel();
        this.ClearTaskRewardItems();
        this.panel.RefreshTrackButton(this.task);
        if(hasGoodAward)this.RefreshGoodList();
    }

    /// <summary>
    /// 刷新任务引导说明
    /// </summary>
    public void RefreshInfoView()
    {
        if(task.taskBase.isDel!=1)this.panel.SetCanelButtonActive(false);
        this.panel.SetTaskNameLabel(task.taskBase.name,task);
        //未接描述、追踪
        if(task.receiveState==0&&task.state==0)
        {
            this.panel.SetTaskInfoLabel(taskBase.unGetDesc,task);
            this.panel.SetTaskTargetLabel(taskBase.unGetTrack,task);
        }
        //已接描述、未完成追踪
        if(task.receiveState==1&&task.state==0)
        {
            this.panel.SetTaskInfoLabel(taskBase.unDesc,task);
            this.panel.SetTaskTargetLabel(task.GetTaskUnComTrack(),task);
        }
        //已完成描述、追踪
        if(task.receiveState==1&&task.state==1)
        {
            this.panel.SetTaskInfoLabel(taskBase.compDesc,task);
            this.panel.SetTaskTargetLabel(taskBase.compTrack,task);
        }
    }
    /// <summary>
    /// 刷新任务奖励列表
    /// </summary>
    public void RefreshRewardLabel()
    {
        string result="";
        if(task.taskBase.exp>0)
        {
            result+=TaskLang.TASK_EXP+task.taskBase.exp.ToString()+"、";
        }
        if(task.taskBase.coin>0)
        {
            result+=TaskLang.TASK_MONEY+task.taskBase.coin.ToString()+"、";
        }
        this.panel.taskRewardInfoLabel.text=result;
    }
    /// <summary>
    /// 刷新物品列表
    /// </summary>
    public void RefreshGoodList()
    {
        foreach(dth.GoodsVo good in task.taskBase.awardGoods)
        {
            GameObject awardGood=NGUITools.AddChild(this.panel.taskRewardGoodGrid.gameObject,this.panel.GoodSprite.gameObject);
            UISprite sprite=awardGood.GetComponent<UISprite>();
            sprite.atlas=dth.ui.UIUtil.GetGoodsAtlas();
            sprite.spriteName=good.goodsBase.icon;
            awardGood.SetActive(true);
            sprite.MakePixelPerfect();
            awardGood.AddComponent<TemporaryMountData>().good=good;
            UIEventListener listener=UIEventListener.Get(awardGood.gameObject);
            listener.parameter=good;
            listener.onClick+=SetTaskGoodPanel;
        }
        this.panel.taskRewardGoodGrid.repositionNow=true;
        SetTaskGoodPanel(task.taskBase.awardGoods[0]);
    }
    /// <summary>
    /// 设置任务奖励物品面板1
    /// </summary>
    /// <param name="obj"></param>
    public void SetTaskGoodPanel(GameObject obj)
    {
        UIEventListener listener=UIEventListener.Get(obj);
        dth.GoodsVo good=listener.parameter as dth.GoodsVo;
        SetTaskGoodPanel(good);
    }
    /// <summary>
    /// 设置任务奖励物品面板2
    /// </summary>
    /// <param name="good"></param>
    public void SetTaskGoodPanel(dth.GoodsVo good)
    {
        if(good==null)return;
        this.panel.SetGoodSprite(dth.ui.UIUtil.GetGoodsAtlas(),good.goodsBase.icon);
        this.panel.SetTaskGoodName(good.goodsBase.name);
        this.panel.SetTaskGoodNum(good.num);
        this.panel.SetTaskGoodInfo(good.goodsBase.desc);
        this.panel.SetTaskGoodIsBinding(good.binding);
        this.panel.SetGoodType(good.goodsBase.type);
    }


    /// <summary>
    /// 清空的奖励面板Items
    /// </summary>
    public void ClearTaskRewardItems()
    {
        foreach(Transform transf in panel.taskRewardGoodGrid.transform)
        {
            if(transf.gameObject.activeSelf==true)
            {
                transf.gameObject.SetActive(false);
                GameObject.DestroyObject(transf.gameObject);
            }
        }
    }

    public void TaskInfoPanelClick(GameObject obj)
    {
        Debug.Log("任务面板被点击！!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }
    */
}
}
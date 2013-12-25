using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using nh.ui.cache;
using nh.ui.model.vo;

namespace nh.ui.task
{
public class BodyPanelMediator:MonoBehaviour
{
		
    BodyPanel panel;
    public BodyPanelMediator(BodyPanel panel)
    {
        this.panel=panel;
    }

    /// <summary>
    /// 刷新任务按钮Items
    /// </summary>
    public void RefreshMenuItems()//(List<dth.TaskVo> taskList)
    {
//        this.ClearMenuItems();
//        foreach(dth.TaskVo task in taskList)
//        {
//            GameObject item=NGUITools.AddChild(panel.oneMenuGrild.gameObject,panel.NormalButton.gameObject);
//            item.SetActive(true);
//            string taskType=TaskUtil.GetTaskType(task);
//            string taskName=task.taskBase.name;
//            item.GetComponentInChildren<UILabel>().text=taskType+taskName;
//            item.name=task.taskBase.id.ToString();
//            item.transform.localPosition=item.transform.localPosition-Vector3.forward;
//            item.gameObject.AddComponent<UIButtonScale>();
//            UIEventListener listener=UIEventListener.Get(item.gameObject);
//            listener.parameter=task;
//            listener.onClick+=ItemsOnClick;
//        }
//        this.panel.RefreshListAndDragAmountTop();
    }
    /// <summary>
    /// 任务按钮Item点击事件方法
    /// </summary>
    /// <param name="obj"></param>
    private void ItemsOnClick(GameObject obj)
    {
//        UIEventListener listener=UIEventListener.Get(obj);
//        dth.TaskVo task=listener.parameter as dth.TaskVo;
//        long id = task.taskBase.id;
//        if(dth.TaskCache.GetReceivedTaskById(id)!=null)
//        {
//            this.panel.SetContentPanelActive(true);
//            this.panel.GetContentPanel().Mediator.SetReceivedTaskData(id);
//        }
//        else if(dth.TaskCache.GetCanTaskById(id)!=null)
//        {
//            this.panel.SetContentPanelActive(true);
//            this.panel.GetContentPanel().Mediator.SetCanTaskData(id);
//        }
//        else
//        {
//            this.panel.SetContentPanelActive(false);
//        }
    }
    /// <summary>
    /// 清除所有显示的的Items
    /// </summary>
    private void ClearMenuItems()
    {
        foreach(Transform transf in panel.oneMenuGrild.transform)
        {
            if(transf.gameObject.activeSelf==true)
            {
                transf.gameObject.SetActive(false);
                GameObject.DestroyObject(transf.gameObject);
            }
        }
    }
}
}

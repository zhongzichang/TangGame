using UnityEngine;
using System.Collections;
using nh.ui.cache;

namespace nh.ui.task
{
public class ContentPanel : MonoBehaviour
{
    public const string NAME="ContentPanel";

    /// <summary>
    /// �����ӿؼ�
    /// </summary>
    public UIPanel goodInfoPanel;
    public UIPanel rewardPanel;
    public UIPanel taskInfoPanel;
    public UIButton trackButton;
    public UIButton taskFlyButton;
    public UIButton canelButton;

    /// <summary>
    /// ���������ؼ�
    /// </summary>
    public UILabel taskInfoLabel;
    public UILabel taskNameLabel;
    public UILabel taskTargetLabel;

    /// <summary>
    /// ���������ؼ�
    /// </summary>
    public UILabel taskRewardInfoLabel;
    public UILabel taskRewardTitleLabel;
    public UIScrollView taskRewardGoodList;
    public UIGrid taskRewardGoodGrid;
    public Transform GoodSprite;


    /// <summary>
    /// ������Ʒչʾ�ؼ�
    /// </summary>
    public UILabel taskGoodName;
    public UILabel taskGoodIsBinding;
    public UILabel taskGoodInfo;
    public UILabel taskGoodNum;
    public UISprite taskGoodSprite;
    public UILabel taskGoodType;

    private ContentPanelMediator mediator;

    public ContentPanelMediator Mediator
    {
        get
        {
            return mediator;
        }
        set
        {
            mediator = value;
        }
    }
    void Start()
    {
        mediator=new ContentPanelMediator(this);
        PanelCache.TaskPanelTable.Add(NAME,mediator);
        this.SetTaskInfoPanelColliderAndSize();
    }

    /// <summary>
    /// ����������Ϣ������ײ��С
    /// </summary>
    public void SetTaskInfoPanelColliderAndSize()
    {
        BoxCollider collider=taskInfoPanel.gameObject.AddComponent<BoxCollider>();
        Vector4 clipRange=taskInfoPanel.clipRange;
        collider.size=new Vector3(clipRange.z,clipRange.w,clipRange.x);
    }
		/*
    /// <summary>
    /// ˢ��׷�ٰ�ť
    /// </summary>
    public void RefreshTrackButton(dth.TaskVo task)
    {
        GameObject trackButtonGo=trackButton.gameObject;
        trackButtonGo.SetActive(false);
        if(dth.TaskCache.currentTrackingTask==task)return;
        trackButtonGo.SetActive(true);
        UIEventListener trackListener=UIEventListener.Get(trackButtonGo);
        trackListener.parameter=task;
        trackListener.onClick+=TrackButtonOnClick;
    }
    */
    /// <summary>
    /// ׷�ٰ�ť���
    /// </summary>
    /// <param name="obj"></param>
    public void TrackButtonOnClick(GameObject obj)
    {
//        UIEventListener trackListener=UIEventListener.Get(obj);
//        dth.TaskVo task=trackListener.parameter as dth.TaskVo;
//        dth.TaskCache.currentTrackingTask=task;
//        obj.SetActive(false);
    }

    #region============================������弰�ؼ�����==============================
    /// <summary>
    /// ������������Ʒ������ʾ
    /// </summary>
    /// <param name="bl"></param>
    public void SetGoodInfoPanelActive(bool bl)
    {
        this.goodInfoPanel.gameObject.SetActive(bl);
    }
    /// <summary>
    /// ����������������ʾ
    /// </summary>
    /// <param name="bl"></param>
    public void SetRewardPanelActive(bool bl)
    {
        this.rewardPanel.gameObject.SetActive(bl);
    }
    /// <summary>
    /// ����������Ϣ������ʾ
    /// </summary>
    /// <param name="bl"></param>
    public void SetTaskInfoPanelActive(bool bl)
    {
        this.taskInfoPanel.gameObject.SetActive(bl);
    }
    /// <summary>
    /// ����׷�ٰ�ť����ʾ
    /// </summary>
    /// <param name="bl"></param>
    public void SetTrackButtonActive(bool bl)
    {
        this.trackButton.gameObject.SetActive(bl);
    }
    /// <summary>
    /// ���Ʒ��а�ť����ʾ
    /// </summary>
    /// <param name="bl"></param>
    public void SetTaskFlyButtonActive(bool bl)
    {
        this.taskFlyButton.gameObject.SetActive(bl);
    }
    /// <summary>
    /// ����ȡ��������ʾ
    /// </summary>
    /// <param name="bl"></param>
    public void SetCanelButtonActive(bool bl)
    {
        this.canelButton.gameObject.SetActive(bl);
    }
    /// <summary>
    /// ������������Ʒ�б�
    /// </summary>
    /// <param name="bl"></param>
    public void SetTaskRewardGoodListActive(bool bl)
    {
        this.taskRewardGoodList.gameObject.SetActive(bl);
    }
    #endregion

    #region===========================���������ؼ�������==============================
    /// <summary>
    /// ����������������ֱ�ǩ
    /// </summary>
    /// <param name="arg"></param>
    /// <param name="task"></param>
/*    public void SetTaskNameLabel(string str,dth.TaskVo task)
    {
        this.taskNameLabel.text=TaskReplace(str,task);
    }
    /// <summary>
    /// ������������������Ϣ
    /// </summary>
    /// <param name="text"></param>
    /// <param name="task"></param>
    public void SetTaskInfoLabel(string str,dth.TaskVo task)
    {
        this.taskInfoLabel.text=TaskUtil.TaskReplace(str,task.taskBase.id);
    }
    /// <summary>
    /// ������������帽�ӽ�����Ϣ
    /// </summary>
    /// <param name="str"></param>
    /// <param name="task"></param>
    public void SetTaskTargetLabel(string str,dth.TaskVo task)
    {
        this.taskTargetLabel.text=TaskReplace(str,task);
    }*/
    #endregion

    #region===============================���������===========================
    public void SetTaskGoodName(string str)
    {
        this.taskGoodName.text=str;
    }
    public void SetTaskGoodInfo(string str)
    {
        this.taskGoodInfo.text=str;
    }
    public void SetTaskGoodIsBinding(int num)
    {
//        this.taskGoodIsBinding.text=GoodsUtil.GetBindingFormGoodsLang(num);
    }
    public void SetTaskGoodNum(int num)
    {
        this.taskGoodNum.text=GoodsLang.GOOD_NUM+num;
    }
    public void SetGoodSprite(UIAtlas atlas,string spriteName)
    {
        if(atlas!=null)
        {
            this.taskGoodSprite.atlas=atlas;
        }
        this.taskGoodSprite.spriteName=spriteName;
        this.taskGoodSprite.MakePixelPerfect();
    }
    public void SetGoodType(int type)
    {
//        this.taskGoodType.text=GoodsLang.GOOD_TYPE+GoodsUtil.GetTypeFormGoodsLang(type);
    }
    #endregion
//
    /// <summary>
    /// �����ַ�������
    /// </summary>
    /// <param name="arg"></param>
    /// <param name="task"></param>
    /// <returns></returns>
  /*  public string TaskReplace(string str,dth.TaskVo task)
    {
        return TaskUtil.TaskReplace(str,task.taskBase.id);
    }*/
}
}


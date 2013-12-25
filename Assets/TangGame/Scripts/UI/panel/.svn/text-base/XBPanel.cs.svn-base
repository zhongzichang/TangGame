using UnityEngine;
using System.Collections;

namespace nh.ui
{
public class XBPanel : MonoBehaviour
{
	public const string NAME="XBPanel";
    public UISprite bgPanel;
    public UIPanel uiPanel;
    public int uiLayer=1;
    void Awake()
    {
//			uiPanel=GetComponent<UIPanel>();
//			//如果没有uipanel则添加一个
//			if(uiPanel==null){
//				this.gameObject.AddComponent<UIPanel>();
//			}
        //如果没有背景则创建一个
        if(bgPanel==null)
        {
            CreateBgPanel();
        }
        uiLayer=GetTrasnformDepth(transform);

    }
    public int GetTrasnformDepth(Transform transf)
    {
        int index=0;
        Transform cursor=transf;
        while(cursor.parent!=null)
        {
            cursor=cursor.parent;
            index++;
        }
        return index;
    }

    public Transform[] GetTrasnformBrothers(Transform transf)
    {
        Transform parentTransf=this.transform.parent;
        if(parentTransf==null)return null;
        Transform[] brothers=new Transform[parentTransf.childCount];
        for(int i=0; i<brothers.Length; i++)
        {
            brothers[i]=transform.GetChild(i);
        }
        return brothers;
    }
//		public void MakePixelMax(){
//			bgPanel.transform.localPosition=new Vector3(uiPanel.clipRange.x,uiPanel.clipRange.y,bgPanel.transform.localRotation.z);
//			bgPanel.transform.localScale=new Vector3(uiPanel.clipRange.z,uiPanel.clipRange.w,1);
//		}
    public void CreateBgPanel()
    {
        bgPanel=new GameObject().gameObject.AddComponent<UISprite>();
        bgPanel.name="Background";
        bgPanel.transform.parent=transform;
        bgPanel.transform.localPosition=Vector3.zero;
        bgPanel.transform.localScale=Vector3.zero;
    }
    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
    public void OpenPanel()
    {
        CloseBrotherPanel();
        this.gameObject.SetActive(true);
    }
    public void CloseBrotherPanel()
    {
        foreach(Transform child in GetTrasnformBrothers(this.transform))
        {
            if(child.GetComponent<UIPanel>()!=null)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
}

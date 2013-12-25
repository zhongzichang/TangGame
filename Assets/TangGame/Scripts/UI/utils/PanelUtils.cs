using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using nh.ui.cache;

public class PanelUtils : MonoBehaviour
{

    /// <summary>
    /// 限制Item的最大数量
    /// </summary>
    /// <param name="grid"></param>
    public static IEnumerator DelGridItem(UIGrid grid,int countMax)
    {
        yield return true;
        if(countMax==0)
        {
            countMax=PanelCache.msgItemCountMax;
        }
        int count=grid.transform.childCount;
        if(count>countMax)
        {
            Transform trans=grid.transform.GetChild(0);
            trans.gameObject.SetActive(false);
            GameObject.DestroyObject(trans.gameObject);
        }
    }
    /// <summary>
    /// 设置拖拖拽列表到顶端
    /// </summary>
    /// <param name="list"></param>
    /// <param name="grid"></param>
    public static IEnumerator SetDragAmountTop(UIScrollView list)
    {
        yield return true;
        list.SetDragAmount(0.5F,0F,false);
    }
    /// <summary>
    /// 设置拖拖拽列表到底部
    /// </summary>
    /// <param name="list"></param>
    /// <param name="grid"></param>
    public static IEnumerator SetDragAmountBottom(UIScrollView list)
    {
        yield return true;
        list.SetDragAmount(0.5f,1,false);
    }
    /// <summary>
    /// 设置拖拽列表到左边
    /// </summary>
    /// <param name="list"></param>
    /// <param name="grid"></param>
    public static IEnumerator SetDragAmountTopLeft(UIScrollView list)
    {
        yield return true;
        list.SetDragAmount(0,0.5F,false);
    }
    /// <summary>
    /// 设置拖拽列表到右边
    /// </summary>
    /// <param name="list"></param>
    /// <param name="grid"></param>
    public static IEnumerator SetDragAmountTopRight(UIScrollView list)
    {
        yield return true;
        list.SetDragAmount(1,0.5F,false);
    }
    /// <summary>
    /// 获取缩放后像素大小
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    static public Bounds CalculateRelativeWidgetPixBounds(Transform trans)
    {
        Bounds b = NGUIMath.CalculateRelativeWidgetBounds(trans.transform);
        Vector3 bn=b.min;
        Vector3 bx=b.max;
        Vector3 ts=trans.localScale;
        Vector3 min=new Vector3(bn.x*ts.x,bn.y*ts.y,bn.z*ts.z);
        Vector3 max=new Vector3(bx.x*ts.x,bx.y*ts.y,bx.z*ts.z);
        b.SetMinMax(min,max);
        return b;
    }


    static public void RepositionOnBounds (Transform trans)
    {
        float lasty = 0;
        int row = 0;
        List<Transform> list = new List<Transform>();

        for (int i = trans.childCount; i > 0; i--)
        {
            Transform t = trans.GetChild(i-1);
            if (t && (NGUITools.GetActive(t.gameObject))) list.Add(t);
        }
        for (int i = 0, imax = list.Count; i < imax; ++i)
        {
            Transform t = list[i];
            if (!NGUITools.GetActive(t.gameObject)) continue;
            float depth = t.localPosition.z;
            t.localPosition =new Vector3(t.localPosition.x, -lasty, depth);
            lasty+=-PanelUtils.CalculateRelativeWidgetPixBounds(t).size.y;
            row++;
        }
        UIScrollView drag = NGUITools.FindInParents<UIScrollView>(trans.gameObject);
        if (drag != null) drag.UpdateScrollbars(true);
    }

    static public void RepositionUnderBounds (Transform trans)
    {
        float lasty = 0;
        int row = 0;
        List<Transform> list = new List<Transform>();

        for (int i = 0; i < trans.childCount; ++i)
        {
            Transform t = trans.GetChild(i);
            if (t && (NGUITools.GetActive(t.gameObject))) list.Add(t);
        }
        for (int i = 0, imax = list.Count; i < imax; ++i)
        {
            Transform t = list[i];
            if (!NGUITools.GetActive(t.gameObject)) continue;
            float depth = t.localPosition.z;
            t.localPosition =new Vector3(t.localPosition.x, -lasty, depth);
            lasty+=PanelUtils.CalculateRelativeWidgetPixBounds(t).size.y;
            row++;
        }
        UIScrollView drag = NGUITools.FindInParents<UIScrollView>(trans.gameObject);
        if (drag != null) drag.UpdateScrollbars(true);
    }
	
	static public void RepositionUnderBounds (Transform trans,float mheight)
    {
        float lasty = 0;
        int row = 0;
        List<Transform> list = new List<Transform>();

        for (int i = 0; i < trans.childCount; ++i)
        {
            Transform t = trans.GetChild(i);
            if (t && (NGUITools.GetActive(t.gameObject))) list.Add(t);
        }
        for (int i = 0, imax = list.Count; i < imax; ++i)
        {
            Transform t = list[i];
            if (!NGUITools.GetActive(t.gameObject)) continue;
            float depth = t.localPosition.z;
            t.localPosition =new Vector3(t.localPosition.x, -lasty, depth);
            lasty+= mheight;
            row++;
        }
        UIScrollView drag = NGUITools.FindInParents<UIScrollView>(trans.gameObject);
        if (drag != null) drag.UpdateScrollbars(true);
    }

}

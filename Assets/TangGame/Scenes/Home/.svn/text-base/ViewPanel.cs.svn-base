/*
 * Created by SharpDevelop.
 * User: xtq
 * Date: 2013/9/10
 * Time: 22:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

using System.Collections;

namespace TangGame
{
public class ViewPanel : MonoBehaviour
{
    protected void AddOnClickListener(GameObject go, UIEventListener.VoidDelegate handler, object param)
    {
        UIEventListener listener = UIEventListener.Get(go);
        listener.onClick = handler;
        listener.parameter = param;
    }
}
}

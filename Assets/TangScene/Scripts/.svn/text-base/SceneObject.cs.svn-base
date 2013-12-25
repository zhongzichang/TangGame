/*
 * Created by emacs
 * Date: 2013/9/12
 * Author: zzc
 */


using System;
using System.Xml.Serialization;
using UnityEngine;


namespace TangScene
{
  [Serializable]
  public class SceneObject
  {
    [XmlElement("pos")]
    public Vector3 localPosition;
    public SceneObject parent;
    public SceneObject[] children;
  }
}
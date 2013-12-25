/*
 * Created by emacs
 * Date: 2013/9/12
 * Author: zzc
 */


using System;
using System.Xml.Serialization;
using UnityEngine;
using Tang;

namespace TangScene
{
  [Serializable]
  public class TsObject
  {

    public string name;

    [XmlElement("pos")]
    public Vector3 localPosition;
    [XmlElement("rot")]
    public Quaternion localRotation;
    [XmlElement("scale")]
    public Vector3 localScale;
    [XmlElement("animation")]
    public TsAnimation animation;
    public string spriteSetName;

    public TsObject parent;
    public TsObject[] children;

    public string[] scripts;

	  
  }
}
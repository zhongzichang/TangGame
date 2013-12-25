/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/7/30
 * Time: 15:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;

namespace Tang
{
  /// <summary>
  /// Description of Tang.
  /// </summary>
  public class Config
  {

    public static string resDirName = "Tang";
    public static int fps = 10;
    public static ResourceStream resourceStream = ResourceStream.INNER;
    public const string dir = "/";
    public const string NAME_SEP = "_";
    public const string MAT_NAME = "mat";
    public const string AB_EXT_NAME = ".ab";
    public const string XML_EXT_NAME = ".xml";
    public const string SPRITE_NAME = "sprite";
    public const string ANIMATION_NAME = "animation";
    public const string LAYER_NAME = "layer";

    public static string AbDir {
      get {
        return ResDir + "ab/"; 
      }
    }
    
    public static string XmlDir {
      get {
        return ResDir + "xml/";
      }
    }

    public static string ResDir {
      get {
        string prefix = null;

        // WindowsWeb OSXWeb IPhone
        if (Application.platform == RuntimePlatform.WindowsWebPlayer || 
          Application.platform == RuntimePlatform.OSXWebPlayer ||
          Application.platform == RuntimePlatform.IPhonePlayer) {
          prefix = Application.dataPath + "/resources/";
        }

    // Android
    else if (Application.platform == RuntimePlatform.Android) {
          if (resourceStream == ResourceStream.INNER)
            prefix = System.IO.Path.Combine (Application.streamingAssetsPath,
             "resources/");
          else
            prefix = "file:///sdcard/" + resDirName + "/resources/";
        }

    // Editor and others
    else {
          if (resourceStream == ResourceStream.INNER) {
            prefix = "file://" + Application.streamingAssetsPath + "/resources/";
          } else {
            prefix = "file://" + Application.dataPath + "/../../resources/";
          }
        }
        return prefix;

      }
    }
  }
}
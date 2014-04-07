using UnityEngine;
using UnityEditor;

using System.IO;

public class Bundler: MonoBehaviour
{
  static void BundleAll()
  {
    string distPath = System.Environment.GetEnvironmentVariable("UNITY_BUNDLE_PATH");
    if (distPath == null || distPath.Length == 0) {
      throw new System.Exception("UNITY_BUNDLE_PATH -system property not defined, aborting.");
    }

    Bundlex86(distPath);
    BundleApk(distPath);
  }

  static void BundleApk(string distPath)
  {
    string outPath = distPath += "/android";
    Bundle(BuildTarget.Android, outPath);
  }
  
  static void Bundlex86(string distPath)
  {
    string outPath = distPath += "/win32";
    Bundle(BuildTarget.StandaloneWindows, outPath);
  }

  static void Bundle(BuildTarget target, string outPath)
  {
    if(!Directory.Exists(outPath)){
      Directory.CreateDirectory(outPath);
    }

    // Sprite
    BundleSprite(target, "Assets/Tang-Resources/Output/MultiFrame/Sprites", outPath);
    BundleSprite(target, "Assets/Tang-Resources/Output/MultiSet/Sprites", outPath);

    // Scene
    BundleSprite(target, "Assets/TangScene-Resources/Materials", outPath);
    BundleScene(target, "Assets/TangScene-Resources/Scenes", outPath);

  }

  static void BundleSprite(BuildTarget target, string spritePath, string outPath){
    foreach(string fileName in Directory.GetFiles(spritePath)){
      if (IsMetaFile(fileName))
        continue;
      
      Object obj = AssetDatabase.LoadMainAssetAtPath(fileName);
      string filepath =  outPath + @"/" + obj.name + ".ab";
      Debug.Log("BundleSprite: " + filepath);
      bool ok = BuildPipeline.BuildAssetBundle(obj, null, filepath, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, target);
      if (!ok) {
        throw new System.Exception("BuildSprite failed. ");
      }
    }
  }

  static void BundleScene(BuildTarget target, string scenePath, string outPath){
    foreach(string fileName in Directory.GetFiles(scenePath)){
      if (IsMetaFile(fileName))
        continue;

      string[] scenes = { fileName };
      Object obj = AssetDatabase.LoadMainAssetAtPath(fileName);
      string filepath =  outPath + @"/" + obj.name + ".ab";
      Debug.Log("BundleScene: " + filepath);
      string error = BuildPipeline.BuildStreamedSceneAssetBundle( scenes, filepath, target);
      if (error != null && error.Length > 0) {
        throw new System.Exception("BuildScene failed: " + error);
      }
    }
  }

  static private bool IsMetaFile(string fileName)
  {
    string[] subFileNames = fileName.Split('.');
    return subFileNames[subFileNames.Length - 1] == "meta";
  }

}

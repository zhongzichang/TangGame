using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Tang {
	
  public class EditorCommand {
	
    [MenuItem ("Tang/1. Make Sprites From Selection")]
    public static void MakePrefabs(){
			
      foreach(Object obj in Selection.objects){
	if(obj is TextAsset){
	  Maker.Make(obj as TextAsset);
	}
      }
    }
		
    [MenuItem("Tang/2. Generate Animations From Selection")]
    public static void GenerateAnimation(){
			
      foreach(Object obj in Selection.objects){
	AnimationGenerator.GenerateAnimation(obj as GameObject);
      }		
    }
		
    [MenuItem("Tang/3.0 Build AssetBundles From - Track dependencies Selection - Android")]
    public static void BuildAssetBundlesAndroid(){
			
      string dirPath = EditorUtility.SaveFolderPanel("Save AssetBundles to directory", "", "");
      if (dirPath.Length != 0) {
					        
	foreach(UnityEngine.Object obj in Selection.objects){
					
	  string filepath = dirPath + "/" + obj.name + ".ab";
					
	  BuildPipeline.BuildAssetBundle(obj, null, filepath
					 , BuildAssetBundleOptions.CollectDependencies 
					 | BuildAssetBundleOptions.CompleteAssets
					 ,BuildTarget.Android);
					
	}
				
      }
    }
		
    [MenuItem("Tang/3.1 Build AssetBundles From - Track dependencies Selection - WebPlayerStreamed")]
    public static void BuildAssetBundlesWebPlayer(){
			
      string dirPath = EditorUtility.SaveFolderPanel("Save AssetBundles to directory", "", "");
      if (dirPath.Length != 0) {
					        
	foreach(UnityEngine.Object obj in Selection.objects){
					
	  string filepath = dirPath + "/" + obj.name + ".ab";
					
	  BuildPipeline.BuildAssetBundle(obj, null, filepath
					 , BuildAssetBundleOptions.CollectDependencies 
					 | BuildAssetBundleOptions.CompleteAssets
					 ,BuildTarget.WebPlayerStreamed);
	}
      }
    }


    [MenuItem("Tang/3.2 Build AssetBundles From - Track dependencies Selection - StandaloneWindows")]
    public static void BuildAssetBundlesStandaloneWindows(){
			
      string dirPath = EditorUtility.SaveFolderPanel("Save AssetBundles to directory", "", "");
      if (dirPath.Length != 0) {
					        
	foreach(UnityEngine.Object obj in Selection.objects){
					
	  string filepath = dirPath + "/" + obj.name + ".ab";
					
	  BuildPipeline.BuildAssetBundle(obj, null, filepath
					 , BuildAssetBundleOptions.CollectDependencies 
					 | BuildAssetBundleOptions.CompleteAssets
					 ,BuildTarget.StandaloneWindows);
	}
      }
    }

    [MenuItem("Tang/3.3 Build AssetBundles From - Track dependencies Selection - iPhone")]
    public static void BuildAssetBundlesIPhone(){
			
      string dirPath = EditorUtility.SaveFolderPanel("Save AssetBundles to directory", "", "");
      if (dirPath.Length != 0) {
					        
	foreach(UnityEngine.Object obj in Selection.objects){
					
	  string filepath = dirPath + "/" + obj.name + ".ab";
					
	  BuildPipeline.BuildAssetBundle(obj, null, filepath
					 , BuildAssetBundleOptions.CollectDependencies 
					 | BuildAssetBundleOptions.CompleteAssets
					 ,BuildTarget.iPhone);
	}
      }
    }

  }


}
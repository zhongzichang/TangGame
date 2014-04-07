/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/7/30
 * Time: 23:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Tang
{
	/// <summary>
	/// Description of Maker.
	/// </summary>
	public class Maker
	{
		
		
		public static void Make(TextAsset textAsset){
			
			// input
			// Assets/Tang/Input/MultiSet/Data/mount_0.xml
			string textAssetPath = AssetDatabase.GetAssetPath(textAsset);
			string textAssetDirPath = textAssetPath.Substring(0,textAssetPath.LastIndexOf('/'));
			string texturePath = textAssetPath.Replace("Data","Textures").Replace(".xml",".png");
			// output
			string matAlphaPath = textAssetPath.Replace("Input","Output").Replace("Data","Materials").Replace(".xml","-alpha.mat");			
			string prefabDirPath = textAssetDirPath.Replace("Input","Output").Replace("Data","Sprites");
			// parameters
			string[] splits = textAssetPath.Split(new Char[]{'/'});
			string resName = splits[splits.Length - 1].Split(new Char[]{'.'})[0];
			
			// parse data
			AtlasParser parser = new AtlasCocos2DParser(textAsset.text);
			Atlas atls = parser.Parse();
			MidFrame[] midFrames = atls.GetMidFrames();
			
			// create material
			Material matAlpha = new Material(Shader.Find("Mobile/Particles/Alpha Blended"));
			matAlpha.name = resName + "_alpha";
			matAlpha.mainTexture = AssetDatabase.LoadAssetAtPath(texturePath, typeof(Texture)) as Texture;
			AssetDatabase.CreateAsset(matAlpha, matAlphaPath);
			
			string spriteType = splits[splits.Length-3];
			
			if( "MultiSet".Equals(spriteType) ){
				
				Dictionary<string, List<Frame>> frameTable = new Dictionary<string, List<Frame>>();
				foreach( MidFrame frame in midFrames ){
		
					string[] frameNamesplits = frame.name.Split(new Char[]{ '_' });
					string key = frameNamesplits[0];
					//string index = frameNamesplits[1];
					
					List<Frame> frameList = null;
					if( !frameTable.ContainsKey(key) ) {
						frameList = new List<Frame>();
						frameTable.Add(key, frameList);
					} else {
						frameList = frameTable[key];
					}
					
					frameList.Add(frame);
					
				}
				
				List<FrameSet> frameSets = new List<FrameSet>();
				foreach( KeyValuePair<string, List<Frame>> kvp in frameTable )
				{
					FrameSet frameSet = new FrameSet(kvp.Key, kvp.Value.ToArray());
					frameSets.Add(frameSet);
				}
				
				
				// create game object
				GameObject go = new GameObject();
				go.name = resName;
		
				MultiSetSprite sprite = go.AddComponent<MultiSetSprite>();
				sprite.frameSets = frameSets.ToArray();
							
				// mesh reader
				MeshRenderer mr = go.AddComponent<MeshRenderer>();
				mr.material = matAlpha;
				mr.castShadows = false;
				mr.receiveShadows = false;
		
				// create prefab
				// output prefab path
				string prefabPath = prefabDirPath + "/" + resName + ".prefab";
				UnityEngine.Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath);
				PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ConnectToPrefab);
				
				// destory game object
				GameObject.DestroyImmediate(go);
				
			} else if( "MultiFrame".Equals(spriteType) ){
				
				// create game object
				GameObject go = new GameObject();
				go.name = resName;
		
				MultiFrameSprite sprite = go.AddComponent<MultiFrameSprite>();
				sprite.frames = midFrames;
							
				// mesh reader
				MeshRenderer mr = go.AddComponent<MeshRenderer>();
				mr.material = matAlpha;
				mr.castShadows = false;
				mr.receiveShadows = false;
		
				// create prefab
				// output prefab path
				string prefabPath = prefabDirPath + "/" + resName + ".prefab";
				UnityEngine.Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath);
				PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ConnectToPrefab);
				
				// destory game object
				GameObject.DestroyImmediate(go);
				
				
				
			} else if( "SingleFrame".Equals(spriteType) ){
								
				foreach( MidFrame frame in midFrames ){
					GameObject go = new GameObject();
					go.name = resName + frame.name.Replace('/','_');
					
					SingleFrameSprite sprite = go.AddComponent<SingleFrameSprite>();
					sprite.fr = frame;
					
					// mesh reader
					MeshRenderer mr = go.AddComponent<MeshRenderer>();
					mr.material = matAlpha;
					mr.castShadows = false;
					mr.receiveShadows = false;
					
					// create prefab
					// output prefab path
					string prefabPath = prefabDirPath + "/" + go.name + ".prefab";
					UnityEngine.Object prefab = PrefabUtility.CreateEmptyPrefab(prefabPath);
					PrefabUtility.ReplacePrefab(go, prefab, ReplacePrefabOptions.ConnectToPrefab);
					
					// destory game object
					GameObject.DestroyImmediate(go); 
					
				}
				
			}
			
		}
		
		
	}
}

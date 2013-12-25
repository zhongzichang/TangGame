///xbhuang
///2013/11/13
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using nh.ui.basePanel;

namespace TangGame{
	public class PrefabCache {
		
		private static Dictionary<string, GameObject> prefabDic = new Dictionary<string, GameObject>();
		private static Dictionary<string, GameObject> iconPrefabDic = new Dictionary<string, GameObject>();
		public static GameObject getPrefabs(string prefabName)
		{
			GameObject obj = null;
			if (prefabDic.ContainsKey(prefabName))
				obj =  prefabDic[prefabName];
			else
			{
				obj = Resources.Load(GameConsts.PREFABS_PATH +  prefabName) as GameObject;
				prefabDic[prefabName] = obj;
			}
			return obj;
		}
//		public static GameObject getMainUIPrefabs(){
//			GameObject obj = null;
//			if(iconPrefabDic.ContainsKey(GameConsts.MAIN_UI)){
//				obj = iconPrefabDic[GameConsts.MAIN_UI];
//			}
//			else
//			{
//				string path = GameConsts.MAIN_UI_PATH + GameConsts.MAIN_UI;
//				Object oo = Resources.Load(path);
//				iconPrefabDic[GameConsts.MAIN_UI] = obj;
//			}
//			return obj;
//		}

		public static GameObject getIconPrefabs(string prefabName, string prefabPath)
		{
			GameObject obj = null;
			if (iconPrefabDic.ContainsKey(prefabName))
				obj =  iconPrefabDic[prefabName];
			else
			{
				string path = GameConsts.ICON_PATH + prefabPath +  prefabName;
				Object oo = Resources.Load(path);
				obj =  oo as GameObject;
				iconPrefabDic[prefabName] = obj;
			}
			return obj;
		}
//		
//		
//		
//		/// <summary>
//		/// 物品框对象
//		/// </summary>
//		private static GameObject hItemGameObject;
//		
//		public static GameObject HItemGameObject {
//			get { 
//				if(hItemGameObject == null)
//					hItemGameObject = Resources.Load(GameConsts.PREFABS_PATH +  typeof(HItem).Name) as GameObject;
//				return hItemGameObject; }
//			set { hItemGameObject = value; }
//		}
			
	}
}
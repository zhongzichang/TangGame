using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace zyhd.TEffect{
	public class MyCache{
		public static UIAtlas usedAtlas;
		public static UIFont usedFont;
		public static GameObject labelObj;
		public static string DMG_PRE = "dmg_";
		public static string HP_PRE = "hp_";
		public static string EXP_PRE = "exp_";
		public static string PET_PRE = "pet_";
		public static string SELF_PRE = "self_";
		public static string CRIT_PRE = "crit_";
		
		public static Dictionary<TEffect,TEffectLogo> logos = new Dictionary<TEffect,TEffectLogo>();
		public static Dictionary<TEffect,GameObject> texts = new Dictionary<TEffect,GameObject>();
		public static Queue effQueue = new Queue();
		public static int effQueueNum = 0;
		
		public static Queue logoQueue = new Queue();
		public static int logoQueueNum = 0;
		
		public static Queue textQueue = new Queue();
		public static int textQueueNum = 0;
		
		public static GameObject root;
		public static UIRoot uiRoot;
		public static GameObject itemPrefab;

	}
}
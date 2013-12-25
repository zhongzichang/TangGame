using UnityEngine;
using System.Collections;

namespace TangGame.Net{
	public class ActorNo {
		/// <summary>
		/// 角色ID
		/// </summary>
		public long id;
		/// <summary>
		/// 角色名字
		/// </summary>
		public string name;
		/// <summary>
		/// 角色x坐标
		/// </summary>
		public short x;
		/// <summary>
		/// 角色y坐标
		/// </summary>
		public short y;
		/// <summary>
		/// 生命最大值
		/// </summary>
		public int hpMax;
		/// <summary>
		/// 移动速度
		/// </summary>
		public float speed;
		/// <summary>
		/// 角色等级
		/// </summary>
		public int level;
		/// <summary>
		/// 半身像
		/// </summary>
		public string helfLengthPhoto;
		/// <summary>
		/// 角色动画资源Id
		/// </summary>
		public string resourcesId;
	}
}
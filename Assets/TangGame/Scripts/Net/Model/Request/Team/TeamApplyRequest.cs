using UnityEngine;
using TangNet;

namespace TangGame.Net
{
//申请队伍
	public class TeamApplyRequest : Request
	{

		private long id;
		private int type;

		/// <summary>
		/// 队伍申请
		/// </summary>
		/// <param name="id">队伍ID</param>
		/// <param name="type">申请类型，0为普通,1为一键招募</param>
		public TeamApplyRequest (long id)
		{
			this.id=id;
			this.type=0;
			
		}

		public TeamApplyRequest (long id, int type)
		{
			this.id = id;
			this.type = type;
		}

		public NetData NetData {
			get {
				NetData data = new NetData (TeamProxy.S_ASKJOIN_TEAM);
				data.PutLong (id);
				data.PutInt (type);
				return data;
			}
		}
	}
}

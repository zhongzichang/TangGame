using System;
using TangNet;

namespace TangGame.Net
{
	/// <summary>
	/// 点击场景中的怪物和NPC时请求头像信息数据
	/// </summary>
	public class GetTargetHeadInfoRequest : Request
	{
		private long objId = 0L;
		public GetTargetHeadInfoRequest(long objId)
		{
			this.objId = objId;
		}
		
		public NetData NetData
		{
			get
			{
				NetData data = new NetData(SceneProxy.S_GET_TARGET_HEAD_INFO_BY_ID);
				data.PutLong(objId);
				return data;
			}
		}
	}
}

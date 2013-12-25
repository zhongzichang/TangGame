/*
 * yc : 2013/11/14
 */
using System;

namespace TangGame.Net
{
	public class RoleProxy
	{
		public const short TYPE = 0x0200;
		//请求自己的英雄角色面板数据
		public const short MY_ROLE_INFO  = TYPE + 0x0002;
	}
}

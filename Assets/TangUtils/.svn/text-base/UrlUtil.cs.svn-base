/**
 * Created by emacs
 * Date: 2013/10/21
 * Author: zzc
 */

namespace TangUtils
{

	public class UrlUtil
	{
		/// <summary>
		///   从URL中获取文件名（不带后缀）
		/// </summary>
		public static string GetFileNameWithoutExt(string url)
		{
			if(url != null )
			{
				string filename = null;
				int lastSlashIndex = url.LastIndexOf('/');
				if( lastSlashIndex > 0 && lastSlashIndex < url.Length - 1 )
				{
					// 最后一个斜线后面还有其他字符

					filename = url.Substring(lastSlashIndex+1);
					int lastDotIndex = filename.LastIndexOf('.');
					if( lastDotIndex > 0 )
					{
						// 文件名有点号
						return filename.Substring(0, lastDotIndex);
					}
					else
						// 文件名没有点号
						return filename;
				}
			}
			return null;
		}
	}
	
}
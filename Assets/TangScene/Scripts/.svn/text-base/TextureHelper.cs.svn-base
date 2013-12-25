using UnityEngine;

namespace TangScene
{
	public class TextureHelper
	{
		
		public static Color32 SampleUnClearColor(Texture2D texture2D){
			
			
			Color32[] colors = texture2D.GetPixels32();
			
			foreach(Color32 color in colors){
				
				if(color.r > 0 || color.g > 0 || color.b > 0 || color.a > 0){
					return new Color32(color.r, color.g, color.b, 100);
				}
			}
			
			return new Color32(0,0,0,0);
		}
		
	}
}


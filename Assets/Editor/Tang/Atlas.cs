using UnityEngine;
using System.Collections.Generic;


namespace Tang {
	
	public class Atlas {
		
		public string name;
		public Vector2 sheetSize = Vector2.zero;
		public AtlasData[] atlasData = null;
		
		
		public MidFrame[] GetMidFrames() {
			
			MidFrame[] frames = new MidFrame[atlasData.Length];
			
			for (int i = 0; i < atlasData.Length; i++)
			{
				AtlasData data = atlasData[i];
				MidFrame frame = new MidFrame();
				frame.name = data.name;
				frame.offset = data.offset;
				frame.size = data.size;
				// uv ---
				frame.uv = new Vector2[4];
				float sx = data.position.x / sheetSize.x;
				float sy = 1 - ((data.position.y + data.size.y) / sheetSize.y);
				float scx = data.size.x / sheetSize.x;
				float scy = data.size.y / sheetSize.y;
				if ( data.rotated )
				{
					sy = 1 - ((data.position.y + data.size.x) / sheetSize.y);
					scx = data.size.y / sheetSize.x;
					scy = data.size.x / sheetSize.y;
					frame.uv[3] = new Vector2(sx, sy + scy);
					frame.uv[0] = new Vector2(sx + scx, sy + scy);
					frame.uv[1] = new Vector2(sx + scx, sy);
					frame.uv[2] = new Vector2(sx, sy);
				} else {
					frame.uv[0] = new Vector2(sx, sy + scy);
					frame.uv[1] = new Vector2(sx + scx, sy + scy);
					frame.uv[2] = new Vector2(sx + scx, sy);
					frame.uv[3] = new Vector2(sx, sy);
				}
				// ---
				
				frames[i] = frame;
			}
			return frames;
		}
	}
}

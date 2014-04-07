/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/7/30
 * Time: 22:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;


namespace Tang
{
	/// <summary>
	/// Description of AtlasCocos2DImporter.
	/// </summary>
	public class AtlasCocos2DParser : AtlasXmlParser
	{
		
		public XmlNode subTexture = null;
		
		public AtlasCocos2DParser(string text){
			this.text = text;
		}
		
		public override Atlas Parse() {
			
			if (!ValidXML())
				return null;
			
			Vector2 sheetSize = Vector2.zero;
			List<AtlasData> data = new List<AtlasData>();
			string name = null;
			
			if ( xml.DocumentElement.Name == "plist" ) {
				XmlNodeList nodeList = xml.DocumentElement.SelectNodes("dict/key");
				for (int i=0; i<nodeList.Count; i++) {
					XmlNode frames = nodeList[i];
					if (frames != null && frames.InnerText == "frames") {
						
						XmlNodeList subTextureNames = xml.DocumentElement.SelectNodes("dict/dict/key");
						XmlNodeList subTextures = xml.DocumentElement.SelectNodes("dict/dict/dict");
						try {
							for (int si = 0; si < subTextures.Count; si++) {
								subTexture = subTextures[si];
								AtlasData ad = new AtlasData();
								
								bool rotated = GetBool("rotated");
								Rect frame = GetRect("frame");
								Rect colorRect = GetRect("sourceColorRect");
								Vector2 sourceSize = GetVector2("sourceSize");
								Vector2 offset = GetVector2("offset");

								try {
									ad.name = subTextureNames[si].InnerText.Split('.')[0];
								} catch (System.Exception) {
									ad.name = subTextureNames[si].InnerText;
								}
								ad.position = new Vector2(frame.xMin, frame.yMin);
								if (rotated)
									ad.rotated = true;
								
								ad.size = new Vector2(colorRect.width, colorRect.height);
								ad.frameSize = sourceSize;
								ad.offset = offset;
								
								data.Add(ad);
							}
						} catch (System.Exception ERR) {
							Debug.LogError("Orthello : Cocos2D Atlas Import error!");
							Debug.LogError(ERR.Message);
						}
					}
					else if (frames != null && frames.InnerText == "metadata") {
						
						XmlNode sizeNode = frames.NextSibling.SelectSingleNode("key[text()=\"size\"]");
						if (sizeNode!=null)
							sheetSize = StringToVector2(sizeNode.NextSibling.InnerText);
						
						XmlNode nameNode = frames.NextSibling.SelectSingleNode("key[text()=\"realTextureFileName\"]");
						if (nameNode==null)
							nameNode = frames.NextSibling.SelectSingleNode("key[text()=\"textureFileName\"]");
						if (nameNode!=null) {
							string[] sa = nameNode.NextSibling.InnerText.Split('.');
							if (sa.Length>0)
								name = sa[0];
						}
					}
				}
			}
			
			Atlas atlas = new Atlas();
			atlas.atlasData = data.ToArray();
			atlas.sheetSize = sheetSize;
			atlas.name = name;
			
			return atlas;
		}
		
		private Vector2 StringToVector2(string s)
		{
			string _s = s.Substring(1, s.Length - 2);
			string[] sa = _s.Split(',');
			return new Vector2(System.Convert.ToSingle(sa[0]), System.Convert.ToSingle(sa[1]));
		}

		private Rect StringToRect(string s)
		{
			string _s = s.Substring(1, s.Length - 2);
			string[] sa = _s.Split(new string[] { "},{" }, System.StringSplitOptions.None);
			Vector2 v1 = StringToVector2(sa[0]+"}");
			Vector2 v2 = StringToVector2("{"+sa[1]);
			return new Rect(v1.x, v1.y, v2.x, v2.y);
		}

		private Rect GetRect(string name)
		{
			XmlNode nameNode = subTexture.SelectSingleNode("key[.='" + name + "']");
			if (nameNode != null)
			{
				XmlNode stringNode = nameNode.NextSibling;
				return StringToRect(stringNode.InnerText);
			}
			return new Rect(0, 0, 0, 0);
		}

		private Vector2 GetVector2(string name)
		{
			XmlNode nameNode = subTexture.SelectSingleNode("key[.='" + name + "']");
			if (nameNode != null)
			{
				XmlNode stringNode = nameNode.NextSibling;
				return StringToVector2(stringNode.InnerText);
			}
			return Vector2.zero;
		}

		private bool GetBool(string name)
		{
			XmlNode nameNode = subTexture.SelectSingleNode("key[.='" + name + "']");
			if (nameNode != null)
			{
				XmlNode boolNode = nameNode.NextSibling;
				return (boolNode.Name.ToLower() == "true");
			}
			return false;
		}
	}
}

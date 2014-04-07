/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/7/30
 * Time: 22:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Xml;
using UnityEngine;

namespace Tang
{
	/// <summary>
	/// Description of AtlasXmlImporter.
	/// </summary>
	public abstract class AtlasXmlParser : AtlasParser
	{
		protected string text;
		protected XmlDocument xml = new XmlDocument();
		
		protected string AttrS(XmlNode node, string field)
		{
			try
			{
				return node.Attributes[field].InnerText;
			}
			catch (System.Exception)
			{
				return "";
			}
		}
		
		protected int AttrI(XmlNode node, string field)
		{
			try
			{
				return System.Convert.ToInt16(node.Attributes[field].InnerText);
			}
			catch (System.Exception)
			{
				return -1;
			}
		}
		
		
		/// <summary>
		/// Check if xml provided is valid
		/// </summary>
		/// <returns>Array with atlas frame data</returns>
		protected bool ValidXML()
		{
			try
			{
				xml.LoadXml(text);
				return true;
			}
			catch (System.Exception err)
			{
				Debug.LogError("Orthello : Atlas XML file could not be read!");
				Debug.LogError(err.Message);
			}
			return false;
		}
		
		
		public abstract Atlas Parse();
	}
}

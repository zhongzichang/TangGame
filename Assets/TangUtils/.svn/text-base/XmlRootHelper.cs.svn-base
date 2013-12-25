using UnityEngine;

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace TangUtils
{

	public class XmlRootHelper
	{
		public static T LoadXml<T>(TextReader textReader)
		{
			var serializer = new XmlSerializer(typeof(T));
			using(XmlReader reader = new XmlTextReader(textReader))
			{
				return (T)serializer.Deserialize(reader);
			}
		}

	}
}
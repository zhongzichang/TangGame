/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/18
 * Time: 18:08
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using UnityEngine;

namespace TangUtils
{
    /// <summary>
    /// Description of IParser.
    /// </summary>
    public class XmlProcessor
    {
        private Dictionary<string, MethodInfo> xmlParseMethodTable = new Dictionary<string, MethodInfo>();
        private Dictionary<string, MethodInfo> stringXmlParseMethodTable = new Dictionary<string, MethodInfo>();
        private Dictionary<string, MethodInfo> xmlLateMethodTable = new Dictionary<string, MethodInfo>();
        private static readonly object m_syncObj = new object();
        private static XmlProcessor m_instance = null;
        private MethodInfo staticXmlParseMethod = null;
        private MethodInfo staticStringXmlParseMethod = null;

        public static XmlProcessor Instance
        {
            get
            {
                lock (m_syncObj)
                {
                    if (m_instance == null)
                        m_instance = new XmlProcessor();
                    return m_instance;
                }
            }
        }

        private XmlProcessor()
        {
            staticXmlParseMethod = typeof(XmlParser).GetMethod("Parse", new Type[] { typeof(byte[])  });
            staticStringXmlParseMethod = typeof(XmlParser).GetMethod("Parse", new Type[] { typeof(string)  });
            List<Type> typeList = AttributeUtils.GetTypesWith<XmlLateAttribute>(true);
            if (typeList != null)
                foreach (Type type in typeList)
                    RegisterXmlProcess(type);	    

        }

        private void RegisterXmlProcess(Type type)
        {
            object[] objs = type.GetCustomAttributes(true);

            foreach (object obj in objs)
            {
	  
                if (obj is XmlLateAttribute)
                {
                    XmlLateAttribute attribute = (XmlLateAttribute)obj;
                    // 注册一个泛型的解释方法
                    xmlParseMethodTable[attribute.GetName()] = staticXmlParseMethod.MakeGenericMethod(type);
                    stringXmlParseMethodTable[attribute.GetName()] = staticStringXmlParseMethod.MakeGenericMethod(type);
                    // 注册一个后期处理方法
                    MethodInfo methodInfo = type.GetMethod("LateProcess", new Type[] { typeof(object) });
                    if (methodInfo != null)
                    {
                        xmlLateMethodTable.Add(attribute.GetName(), methodInfo);		  
                    }


                }

            }
        }

        public object Process(string name, byte[] bytes)
        {
            if (xmlParseMethodTable.ContainsKey(name))
            {
                MethodInfo methodInfo = xmlParseMethodTable[name] as MethodInfo;
                if (methodInfo != null)
                {
                    Debug.Log(name);
                    object obj = methodInfo.Invoke(null, new byte[][] { bytes }) as object;
                    if (obj != null && xmlLateMethodTable.ContainsKey(name))
                    {
                        xmlLateMethodTable[name].Invoke(null, new object[] { obj });
                    }
                    return obj;
                }
            }
            return null;

        }

        public object Process(string name, string text)
        {
            if (xmlParseMethodTable.ContainsKey(name))
            {
                MethodInfo methodInfo = stringXmlParseMethodTable[name] as MethodInfo;
                if (methodInfo != null)
                {
                    object obj = methodInfo.Invoke(null, new string[] { text }) as object;
                    if (obj != null && xmlLateMethodTable.ContainsKey(name))
                    {
                        xmlLateMethodTable[name].Invoke(null, new object[] { obj });
                    }
                    return obj;
                }
            }
            return null;
        }
    }
}

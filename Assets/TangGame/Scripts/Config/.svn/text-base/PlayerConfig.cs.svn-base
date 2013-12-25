/*
	2013/6/9

	xbhuang
*/

using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace TangGame
{
public static class PlayerConfig
{
    private static Hashtable playerConfigHashtable = new Hashtable();

    private static bool hashTableChanged = false;
    private static string serializedOutput = "";
    private static string serializedInput = "";

    private const string PARAMETERS_SEPERATOR = ";";
    private const string KEY_VALUE_SEPERATOR = ":";

    private static readonly string fileName = Application.persistentDataPath + "/PlayerConfig.config";

    static PlayerConfig()
    {
        //load previous settings
        StreamReader fileReader = null;

        if (File.Exists(fileName))
        {
            fileReader = new StreamReader(fileName);

            serializedInput = fileReader.ReadLine();

            Deserialize();

            fileReader.Close();
        }
        Debug.Log("read file from disk!!!@"+fileName);
    }

    public static bool HasKey(string key)
    {
        return playerConfigHashtable.ContainsKey(key);
    }

    public static void SetString(string key, string value)
    {
        if(!playerConfigHashtable.ContainsKey(key))
        {
            playerConfigHashtable.Add(key, value);
        }
        else
        {
            playerConfigHashtable[key] = value;
        }

        hashTableChanged = true;
    }

    public static void SetInt(string key, int value)
    {
        if(!playerConfigHashtable.ContainsKey(key))
        {
            playerConfigHashtable.Add(key, value);
        }
        else
        {
            playerConfigHashtable[key] = value;
        }

        hashTableChanged = true;
    }

    public static void SetFloat(string key, float value)
    {
        if(!playerConfigHashtable.ContainsKey(key))
        {
            playerConfigHashtable.Add(key, value);
        }
        else
        {
            playerConfigHashtable[key] = value;
        }

        hashTableChanged = true;
    }

    public static void SetBool(string key, bool value)
    {
        if(!playerConfigHashtable.ContainsKey(key))
        {
            playerConfigHashtable.Add(key, value);
        }
        else
        {
            playerConfigHashtable[key] = value;
        }

        hashTableChanged = true;
    }

    public static string GetString(string key)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return playerConfigHashtable[key].ToString();
        }

        return null;
    }

    public static string GetString(string key, string defaultValue)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return playerConfigHashtable[key].ToString();
        }
        else
        {
            playerConfigHashtable.Add(key, defaultValue);
            hashTableChanged = true;
            return defaultValue;
        }
    }

    public static int GetInt(string key)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return (int) playerConfigHashtable[key];
        }

        return 0;
    }

    public static int GetInt(string key, int defaultValue)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return (int) playerConfigHashtable[key];
        }
        else
        {
            playerConfigHashtable.Add(key, defaultValue);
            hashTableChanged = true;
            return defaultValue;
        }
    }

    public static float GetFloat(string key)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return (float) playerConfigHashtable[key];
        }

        return 0.0f;
    }

    public static float GetFloat(string key, float defaultValue)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return (float) playerConfigHashtable[key];
        }
        else
        {
            playerConfigHashtable.Add(key, defaultValue);
            hashTableChanged = true;
            return defaultValue;
        }
    }

    public static bool GetBool(string key)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return (bool) playerConfigHashtable[key];
        }

        return false;
    }

    public static bool GetBool(string key, bool defaultValue)
    {
        if(playerConfigHashtable.ContainsKey(key))
        {
            return (bool) playerConfigHashtable[key];
        }
        else
        {
            playerConfigHashtable.Add(key, defaultValue);
            hashTableChanged = true;
            return defaultValue;
        }
    }
    public static void DeleteKey(string key)
    {
        playerConfigHashtable.Remove(key);
    }

    public static void DeleteAll()
    {
        playerConfigHashtable.Clear();
    }

    public static void Flush()
    {
        if(hashTableChanged)
        {
            Serialize();

            StreamWriter fileWriter = null;
            fileWriter = File.CreateText(fileName);
            if (fileWriter == null)
            {
                Debug.LogWarning("PlayerConfig::Flush() opening file for writing failed: " + fileName);
            }

            fileWriter.WriteLine(serializedOutput);

            fileWriter.Close();

            serializedOutput = "";
        }
    }

    private static void Serialize()
    {
        IDictionaryEnumerator myEnumerator = playerConfigHashtable.GetEnumerator();

        while ( myEnumerator.MoveNext() )
        {
            if(serializedOutput != "")
            {
                serializedOutput += " " + PARAMETERS_SEPERATOR + " ";
            }
            serializedOutput += EscapeNonSeperators(myEnumerator.Key.ToString()) + " " + KEY_VALUE_SEPERATOR + " " + EscapeNonSeperators(myEnumerator.Value.ToString()) + " " + KEY_VALUE_SEPERATOR + " " + myEnumerator.Value.GetType();
        }
    }

    private static void Deserialize()
    {
        string[] parameters = serializedInput.Split(new string[] {" " + PARAMETERS_SEPERATOR + " "}, StringSplitOptions.None);

        foreach(string parameter in parameters)
        {
            string[] parameterContent = parameter.Split(new string[] {" " + KEY_VALUE_SEPERATOR + " "}, StringSplitOptions.None);

            playerConfigHashtable.Add(DeEscapeNonSeperators(parameterContent[0]), GetTypeValue(parameterContent[2], DeEscapeNonSeperators(parameterContent[1])));

            if(parameterContent.Length > 3)
            {
                Debug.LogWarning("PlayerPrefs::Deserialize() parameterContent has " + parameterContent.Length + " elements");
            }
        }
    }

    private static string EscapeNonSeperators(string inputToEscape)
    {
        inputToEscape = inputToEscape.Replace(KEY_VALUE_SEPERATOR,"\\" + KEY_VALUE_SEPERATOR);
        inputToEscape = inputToEscape.Replace(PARAMETERS_SEPERATOR,"\\" + PARAMETERS_SEPERATOR);
        return inputToEscape;
    }

    private static string DeEscapeNonSeperators(string inputToDeEscape)
    {
        inputToDeEscape = inputToDeEscape.Replace("\\" + KEY_VALUE_SEPERATOR, KEY_VALUE_SEPERATOR);
        inputToDeEscape = inputToDeEscape.Replace("\\" + PARAMETERS_SEPERATOR, PARAMETERS_SEPERATOR);
        return inputToDeEscape;
    }

    public static object GetTypeValue(string typeName, string value)
    {
        if (typeName == "System.String")
        {
            return (object)value.ToString();
        }
        if (typeName == "System.Int32")
        {
            return (object)System.Convert.ToInt32(value);
        }
        if (typeName == "System.Boolean")
        {
            return (object)System.Convert.ToBoolean(value);
        }
        if (typeName == "System.Single")// -> single = float
        {
            return (object)System.Convert.ToSingle(value);
        }
        else
        {
            Debug.LogError("Unsupported type: " + typeName);
        }

        return null;
    }
}
}
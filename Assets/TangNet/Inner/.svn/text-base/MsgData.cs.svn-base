/**
 * MsgData for decoded bytes
 * 
 * Date: 2013/10/24
 * Author: zzc
 */
using System;
using System.Collections;

namespace TangNet
{

  public class MsgData
  {

    //		private ArrayList msg = new ArrayList();
    public ArrayList msg=new ArrayList();
    public int Size
    {
      get
        {
	  return msg.Count;
        }
    }

    public void Put(object val)
    {
      msg.Add(val);
    }

    public object Get(int index)
    {
      return msg[index];
    }

    public byte GetByte(int index)
    {
      return (byte) msg[index];
    }

    public byte[] GetBytes(int index)
    {
      return (byte[])msg[index];
    }

    public short GetShort(int index)
    {
      return (short) msg[index];
    }

    public int GetInt(int index)
    {
      return (int) msg[index];
    }

    public long GetLong(int index)
    {
      return (long)msg[index];
    }

    public double GetDouble(int index)
    {
      return (double) msg[index];
    }

    public string GetString(int index)
    {
      return (string) msg[index];
    }

    public bool GetBool(int index)
    {
      return (byte) msg[index] == 1;
    }

    public MsgData GetMsgData(int index)
    {
      return (MsgData) msg[index];
    }
  }
}


using System;

namespace TangNet
{


  /**
   * pack the data for sending
   *
   */
  public class NetData
  {

    public const short VALUE_BYTE = -1; // FFFF
    public const short VALUE_SHORT = -2; // FFFE
    public const short VALUE_INT = -3; // FFFD
    public const short VALUE_LONG = -4; // FFFC
    public const short VALUE_DOUBLE = -5; // FFFB
    public const short VALUE_BYTES = -6; // FFFA
    public const short VALUE_STRING = -7; // FFF9

    private ByteArray data = new ByteArray();
    private bool packed = false;

    public NetData(int title)
    {
      if (title == 0) {
        data.WriteShort(0);
      } else {
        data.WriteShort(2);
        data.WriteShort((short)title);
      }
    }

    public void PutByte(byte val)
    {
      if (packed)
        throw new InvalidOperationException("This object have been packed. " +
          "Please don't put any data into it.");
      data.WriteShort(VALUE_BYTE);
      data.WriteByte(val);
    }

    public void PutBytes(ByteArray val)
    {
      if (packed)
        throw new InvalidOperationException("This object have been packed. " +
          "Please don't put any data into it.");
      data.WriteShort(VALUE_BYTES);
      data.WriteShort((short)(val.BytesAvailable));
      data.WriteBytes(val.Data, 0, val.BytesAvailable);
    }

    public void PutShort(int val)
    {
      if (packed)
        throw new InvalidOperationException("This object have been packed. " +
          "Please don't put any data into it.");
      data.WriteShort(VALUE_SHORT);
      data.WriteShort((short)val);
    }

    public void PutInt(int val)
    {
      if (packed)
        throw new InvalidOperationException("This object have been packed. " +
          "Please don't put any data into it.");
      data.WriteShort(VALUE_INT);
      data.WriteInt(val);
    }

    public void PutLong(long val)
    {

      if (packed)
        throw new InvalidOperationException("This object have been packed. " +
          "Please don't put any data into it.");
      data.WriteShort(VALUE_LONG);
      data.WriteLong(val);
    }

    public void PutDouble(double val)
    {
      if (packed)
        throw new InvalidOperationException("This object have been packed. " +
          "Please don't put any data into it.");
      data.WriteShort(VALUE_DOUBLE);
      data.WriteDouble(val);
    }

    public void PutString(String val)
    {
      if (packed)
        throw new InvalidOperationException("This object have been packed. " +
          "Please don't put any data into it.");
      data.WriteShort(VALUE_STRING);
      data.WriteUTF(val);
    }

    public ByteArray Pack()
    {
      data.Position = 0;
      data.WriteShort((short)(data.BytesAvailable - 2));
      data.Position = data.BytesAvailable;
      packed = true;
      return data;
    }
  }
}

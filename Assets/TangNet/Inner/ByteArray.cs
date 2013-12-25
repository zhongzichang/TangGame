
using System;
using System.Text;
using TangUtils;

namespace TangNet
{


  public class ByteArray
  {

    public const int DEFAULT_SIZE = 1024;
    public const int BASE_SIZE = 1024;

    private static Encoding utf8 = Encoding.UTF8;
    private static EndianBitConverter endianBitConverter =
      (System.BitConverter.IsLittleEndian ?
       (EndianBitConverter)EndianBitConverter.Big :
       (EndianBitConverter)EndianBitConverter.Little);

    public int Position
    {
      get;
      set;
    }
    public int BytesAvailable
    {
      get;
      private set;
    }

    private byte[] data;
    public int Size
    {
      get
        {
	  return data.Length;
        }
    }
    public byte[] Data
    {
      get
        {
	  return data;
        }
    }

    /**
     * 构造一个字节数组，缺省初始大小为 1024
     */
    public ByteArray()
    {
      data = new byte[DEFAULT_SIZE];
      init();
    }
    /**
     * 构造一个字节数组，指定初始大小
     */
    public ByteArray (int initSize)
    {
      data = new byte[initSize];
      init();
    }

    private void init()
    {
      Position = 0;
      BytesAvailable = 0;
    }

    public byte ReadByte()
    {
      return data[Position++];
    }

    public short ReadShort()
    {
      byte[] bytes = ReadBytes(2);
      return endianBitConverter.ToInt16(bytes,0);
    }

    public int ReadInt()
    {
      byte[] bytes = ReadBytes(4);
      return endianBitConverter.ToInt32(bytes,0);
    }

    public long ReadLong()
    {
      byte[] bytes = ReadBytes(8);
      return endianBitConverter.ToInt64(bytes,0);
    }


    public float ReadFloat()
    {
      byte[] bytes = ReadBytes(4);
      return endianBitConverter.ToSingle(bytes,0);
    }

    public double ReadDouble()
    {
      byte[] bytes = ReadBytes(8);
      return endianBitConverter.ToDouble(bytes,0);
    }


    public void ReadBytes(ref ByteArray dstArray, int length)
    {

      dstArray.WriteBytes(data, Position, length);
      Position += length;

    }

    public void ReadBytes(ref ByteArray dstArray,int start, int length)
    {

      dstArray.WriteBytes(data, start, length);

    }

    public byte[] ReadBytes(int length)
    {
      byte[] dstBytes = new byte[length];
      Array.Copy(data,Position,dstBytes,0, length);
      Position += length;
      return dstBytes;
    }

    public string ReadUTF()
    {
      short length = ReadShort();
      return ReadUTFBytes(length);
    }

    /**
     * 读取一个字符串
     **/
    public string ReadUTFBytes(int length)
    {
      string val = utf8.GetString(data, Position, length);
      Position += length;
      return val;

    }

    /**
     * Writes a byte to the byte stream.
     */
    public void WriteByte(byte val)
    {
      CheckData(1);
      data[Position++] = val;
      if(Position > BytesAvailable)
        {
	  BytesAvailable = Position;
        }
    }

    /**
     * 写入多个字节
     **/
    public void WriteBytes(byte[] bytes)
    {
      CheckData(bytes.Length);
      Array.Copy(bytes, 0, data, Position, bytes.Length);
      Position += bytes.Length;
      if(Position > BytesAvailable)
        {
	  BytesAvailable = Position;
        }
    }

    /**
     * 写入多个字节，用参数指定开始和长度
     **/
    public void WriteBytes(byte[] bytes, int start, int length)
    {
      CheckData(bytes.Length);
      Array.Copy(bytes, start, data, Position, length);
      Position += length;
      if(Position > BytesAvailable)
        {
	  BytesAvailable = Position;
        }
    }

    public void WriteShort(short val)
    {
      WriteBytes(endianBitConverter.GetBytes(val));
    }

    /**
     * Writes a 32-bit signed integer to the byte stream.
     */
    public void WriteInt(int val)
    {
      WriteBytes(endianBitConverter.GetBytes(val));
    }

    public void WriteLong(long val)
    {
      WriteBytes(endianBitConverter.GetBytes(val));
    }

    /**
     * Writes an IEEE 754 single-precision (32-bit) floating-point number to the byte stream.
     */
    public void WriteFloat(float val)
    {
      WriteBytes(endianBitConverter.GetBytes(val));
    }

    /**
     * Writes an IEEE 754 double-precision (64-bit) floating-point number to the byte stream.
     */
    public void WriteDouble(double val)
    {
      WriteBytes(endianBitConverter.GetBytes(val));
    }

    /**
     * Writes a UTF-8 string to the byte stream.
     */
    public void WriteUTF(string val)
    {
      byte[] bytes = utf8.GetBytes(val);
      WriteShort((short)bytes.Length);
      WriteBytes(bytes);
    }


    public void Clear()
    {
      Position = 0;
      BytesAvailable = 0;
    }

    private void CheckData(int appendLenght)
    {
      int remain = data.Length - BytesAvailable;
      int need = appendLenght - remain;
      if(need > 0)
        {
	  // expend data size
	  int multiple = (int)Math.Ceiling(((double)need) / BASE_SIZE);
	  Expand(multiple * BASE_SIZE);
        }
    }


    /**
     * 将内置的字节数组扩充到指定长度，如果指定的长度少于或者等于当前长度，不做扩充
     * @param destLength
     */
    private void Expand(int destLength)
    {
      if(data.Length < destLength)
        {
	  byte[] destBytes = new byte[destLength];
	  Array.Copy(data, destBytes, BytesAvailable);
	  data = destBytes;
        }
    }

  }
}

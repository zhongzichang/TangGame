
using System;

namespace TangNet
{


  public class NioDecoder
  {

    public static MsgData DecodeData(ByteArray byteArray)
    {
      byteArray.Position = 0;
      MsgData msgData = new MsgData();

      int type = 0;
      while(byteArray.BytesAvailable > 0)
        {

	  type = byteArray.ReadShort();

	  switch (type)
            {
            case NetData.VALUE_BYTE:
	      msgData.Put(byteArray.ReadByte());
	      break;
            case NetData.VALUE_SHORT:
	      msgData.Put(byteArray.ReadShort());
	      break;
            case NetData.VALUE_INT:
	      msgData.Put(byteArray.ReadInt());
	      break;
            case NetData.VALUE_LONG:
	      msgData.Put(byteArray.ReadLong());
	      break;
            case NetData.VALUE_DOUBLE:
	      msgData.Put(byteArray.ReadDouble());
	      break;
            case NetData.VALUE_BYTES:
	      int byteLength = byteArray.ReadShort();
	      if(byteLength > 0)
                {
		  ByteArray byteArr = new ByteArray();
		  byteArray.ReadBytes(ref byteArr, byteLength);
		  msgData.Put(NioDecoder.DecodeData(byteArr));

                }
	      else
                {
		  msgData.Put(new MsgData());
                }
	      break;
            case NetData.VALUE_STRING:
	      int stringLength = byteArray.ReadShort();
	      if(stringLength > 0)
                {
		  msgData.Put(byteArray.ReadUTFBytes(stringLength));
                }
	      else
                {
		  msgData.Put("");
                }
	      break;
            default:
	      Console.WriteLine(msgData.GetString(0)+"  数据错误  "+type);
	      break;
            }

        }


      return msgData;
    }
  }
}

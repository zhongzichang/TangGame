/**
 * Response handler
 *
 * Date: 2013/10/25
 * Author: zzc
 */
using System;
using System.IO;
using System.Text;
using PureMVC.Patterns;

using UnityEngine;
using TangUtils;

namespace TangNet
{
  public class ResponseHandler
  {

    public delegate void HandleHook(MsgData data);
    public HandleHook handleHook = null;

    private MemoryStream stream = new MemoryStream (10240);
    private static Encoding utf8 = Encoding.UTF8;
    private static EndianBitConverter bitConverter =
      (System.BitConverter.IsLittleEndian ?
       (EndianBitConverter)EndianBitConverter.Big :
       (EndianBitConverter)EndianBitConverter.Little);
    private short packageLength = 0;
    private int availableLength = 0;
    private int offset = 0;
    private byte[] buff = null;
    private ResponseParser responseParser = new ResponseParser ();

    public void SetResponseParser (ResponseParser parser)
    {
      responseParser = parser;
    }

    public void Handle (byte[] data, int start, int count)
    {

      // decode data
      // send notification
      stream.Write (data, start, count);
      availableLength += count;
      this.HandleData ();
    }

    private void HandleData ()
    {

      if (availableLength > 1) {
	if (packageLength == 0) {
	  // package start
	  byte[] tempBuff = new byte[2];
	  stream.Position = offset;
	  int temp = stream.Read (tempBuff, 0, 2);
	  if (temp != 2)
	    throw new Exception ("Data read error, except 2 but return " + temp);

	  packageLength = bitConverter.ToInt16 (tempBuff, 0);
	}

	int wholePackageLength = packageLength + 2;
	if (availableLength >= wholePackageLength) {
	  // decode
	  buff = new byte[packageLength];
	  stream.Position = offset + 2;
	  int temp = stream.Read (buff, 0, packageLength);
	  if (temp != packageLength)
	    throw new Exception ("Data read error, expect 2 but return " + temp);

	  MsgData msgData = decode (0, packageLength);
	  if (msgData != null)
	    HandleByMsgType (msgData);
	  else
	    throw new Exception ("Data decode error");

	  if (availableLength == wholePackageLength) {
	    offset = 0;
	    stream.Position = 0;
	    availableLength = 0;
	    packageLength = 0;
	  } else {
	    offset += wholePackageLength;
	    availableLength -= wholePackageLength;
	    packageLength = 0;
	    if (availableLength > 1)
	      this.HandleData ();
	  }
	} else
	    stream.Position = offset + availableLength;
      }

    }

    // fetch MsgData
    private MsgData decode (int start, int length)
    {

      // offset , packageLength
      MsgData msgData = new MsgData ();

      short type = 0;
      int index = start;
      int count = 0;
      int bytesLength = 0; // for sub MsgData

      while (count < length) {
	type = bitConverter.ToInt16 (buff, index);
	index += 2;
	count += 2;
	switch (type) {

	case NetData.VALUE_BYTE:
	  msgData.Put (buff [index]);
	  index++;
	  count++;
	  break;

	case NetData.VALUE_SHORT:
	  msgData.Put (bitConverter.ToInt16 (buff, index));
	  index += 2;
	  count += 2;
	  break;

	case NetData.VALUE_INT:
	  msgData.Put (bitConverter.ToInt32 (buff, index));
	  index += 4;
	  count += 4;
	  break;

	case NetData.VALUE_LONG:
	  msgData.Put (bitConverter.ToInt64 (buff, index));
	  index += 8;
	  count += 8;
	  break;

	case NetData.VALUE_DOUBLE:
	  msgData.Put (bitConverter.ToDouble (buff, index));
	  index += 8;
	  count += 8;
	  break;

	case NetData.VALUE_BYTES:
	  bytesLength = bitConverter.ToInt16 (buff, index);
	  index += 2;
	  count += 2;
	  if (bytesLength > 0) {
	    msgData.Put (decode (index, bytesLength));
	    index += bytesLength;
	    count += bytesLength;
	  } else
	      msgData.Put (new MsgData ());

	  break;

	case NetData.VALUE_STRING:
	  bytesLength = bitConverter.ToInt16 (buff, index);
	  index += 2;
	  count += 2;
	  if (bytesLength > 0) {
	    msgData.Put (utf8.GetString (buff, index, bytesLength));
	    index += bytesLength;
	    count += bytesLength;
	  } else
	      msgData.Put ("");

	  break;

	default:
	  throw new Exception ("Illegal data type `" + type + "`.");
	}
      }
      return msgData;
    }

    // handle MsgData
    private void HandleByMsgType (MsgData msgData)
    {

      if( handleHook != null )
	handleHook(msgData);

      string msgName = msgData.GetString (0);


      if ( msgName.IndexOf ("RESULT") != -1 ) {

	// ---- result ----

	short statusCode = msgData.GetShort(1);

	MsgData data = null;
	if (msgData.Size > 2)
	  data = msgData.GetMsgData (2);

	Response response = responseParser.Parse (msgName, statusCode, data);
	if (response == null)
	  {
	    //Cache.notificationQueue.Enqueue( new Notification(NtftNames.TN_NONE_OF_PARSER, msgData) );
	    throw new Exception ("None parser for " + msgName);
	  }

	else
	  Cache.notificationQueue.Enqueue (new Notification (msgName, response));


      } else if (msgName.IndexOf ("PUSH") != -1) {

	// ---- push ----
	MsgData data = null;
	if (msgData.Size > 1)
	  data = msgData.GetMsgData (1);

	Response response = responseParser.Parse (msgName, data);
	if (response == null)
	  {
	    //Cache.notificationQueue.Enqueue( new Notification(NtftNames.TN_NONE_OF_PARSER, msgData) );
	    throw new Exception ("None parser for " + msgName);
	  }

	else
	  Cache.notificationQueue.Enqueue (new Notification (msgName, response));
      } else
	  // ---- error message type ----
	  throw new Exception ("illegal response type " + "'" + msgName + "'");
    }
  }
}

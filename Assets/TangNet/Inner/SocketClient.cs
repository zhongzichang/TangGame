/**
 * Created by emacs
 * Date: 2013/10/16
 * Author: zzc
 */


using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace TangNet
{

  public class SocketClient
  {
    // used to pass state information to delegate
    public delegate void CloseHandler(Socket socket);
    public delegate void ExceptionHandler(Socket socket, Exception e);
    public delegate void ConnectSuccessHandler( Socket socket );
    public delegate void ConnectFailureHandler( Socket socket );

    public CloseHandler closeHandler = null;
    public ExceptionHandler exceptionHandler = null;
    public ConnectSuccessHandler connectSuccessHandler = null;
    public ConnectFailureHandler connectFailureHandler = null;

    private const int BUFF_SIZE = 4096;
    private const int CONNECT_TIMEOUT = 3000;

    private byte[] buff = new byte[BUFF_SIZE];
    private Socket clientSocket = null;
    private ResponseHandler responseHandler = new ResponseHandler();
    private IAsyncResult connectResult = null;


    /// <summary>
    ///   是否正在连接
    /// </summary>
    public virtual bool Connecting
    {
      get
	{
	  if(connectResult != null && !connectResult.IsCompleted)
	    return true;
	  else
	    return false;
	}
    }

    /// <summary>
    ///   是否已连接
    /// </summary>
    public virtual bool Connected
    {
      get
	{
	  return clientSocket != null && clientSocket.Connected;
	}
    }


    /// <summary>
    ///   回应处理句柄
    /// </summary>
    public ResponseHandler ResponseHandler
    {
      get
	{
	  return responseHandler;
	}
    }


    public Socket Socket
    {
      get
	{
	  return clientSocket;
	}
    }


    /// <summary>
    ///   设置回应分析器
    /// </summary>
    public virtual void SetResponseParser(ResponseParser parser)
    {
      responseHandler.SetResponseParser(parser);
    }


    /// <summary>
    ///   构造器
    /// </summary>
    public SocketClient()
    {
    }


    /// <summary>
    ///   连接服务器
    /// </summary>
    public virtual void Connect(string server , int port)
    {
      if( !Connected && !Connecting )
	{

	  try
	    {
	      IPAddress ipAddress = Dns.GetHostEntry(server).AddressList[0];
	      IPEndPoint ipEndpoint = new IPEndPoint (ipAddress, port);
	      clientSocket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	      connectResult = clientSocket.BeginConnect (
							 ipEndpoint, new AsyncCallback (ConnectCallback), null);
	    }
	  catch (Exception e)
	    {
	      HandleException(e);
	      Close();
	    }
	}
    }


    /// <summary>
    ///   关闭 socket
    /// </summary>
    public virtual void Close()
    {

      try
	{
	  if(clientSocket != null)
	    {
	      clientSocket.Shutdown(SocketShutdown.Both);
	      clientSocket.Close ();
	    }
	}
      catch (Exception e)
	{
	  HandleException(e);
	}


      if( closeHandler != null )
	closeHandler( clientSocket );

      clientSocket = null;

    }


    /// <summary>
    ///   连接后的回调
    /// </summary>
    public void ConnectCallback (IAsyncResult asyncConnect)
    {
      clientSocket.EndConnect ( asyncConnect );
      if (clientSocket.Connected == false)
	{
	  if( connectFailureHandler != null )
	    connectFailureHandler( clientSocket );

	}
      else
	{

	  if( connectSuccessHandler != null )
	    connectSuccessHandler( clientSocket );

	  // send a active message
	  //	NetData dummyData = new NetData(0);
	  //	dummyData.PutByte(0);
	  //	SendMessage(dummyData);
				
	  // begin receiving
	  clientSocket.BeginReceive (buff, 0, buff.Length,
				     SocketFlags.None, new AsyncCallback (ReceiveCallback), null);
	}
    }


    /// <summary>
    ///   发送后的回调
    /// </summary>
    public void SendCallback (IAsyncResult asyncSend)
    {
      clientSocket.EndSend (asyncSend);
      //int bytesSent = clientSocket.EndSend (asyncSend);
      //Debug.Log("NET: " + bytesSent.ToString () + " bytes sent.");

    }


    /// <summary>
    ///   接收到信息后的回调
    /// </summary>
    public void ReceiveCallback (IAsyncResult asyncReceive)
    {
      int bytesReceived = clientSocket.EndReceive (asyncReceive);

      if(bytesReceived > 0)
	{
	  lock(buff)
	    {
	      try
		{
		  responseHandler.Handle(buff, 0, bytesReceived);
		  clientSocket.BeginReceive (buff, 0, buff.Length,
					     SocketFlags.None,
					     new AsyncCallback (ReceiveCallback), null);

		}
	      catch (Exception e)
		{
		  HandleException(e);
		  Close();
		}
	    }
	}
      else
	{

	  // close socket
	  Close();

	}
    }


    /// <summary>
    ///   发送信息
    /// </summary>
    public virtual void SendMessage(NetData data)
    {
      try
	{
	  ByteArray bytes = data.Pack();
	  clientSocket.BeginSend (bytes.Data, 0, bytes.BytesAvailable,
				  SocketFlags.None, new AsyncCallback (SendCallback), null);
	  
	}
      catch ( Exception e )
	{
	  HandleException(e);
	  Close();
	}

    }


    /// <summary>
    ///   发送多条信息
    /// </summary>
    public virtual void SendMessages(NetData[] datas)
    {

      try
	{
	  
	  ByteArray bytes = new ByteArray();

	  for(int i=0; i<datas.Length; i++)
	    {
	      ByteArray subbytes = datas[i].Pack();
	      bytes.WriteBytes(subbytes.Data,0, subbytes.BytesAvailable);
	    }

	  clientSocket.BeginSend (bytes.Data, 0, bytes.BytesAvailable,
				  SocketFlags.None, new AsyncCallback (SendCallback), null);

	}

      catch(Exception e)
	{
	  HandleException(e);
	  Close();
	}

    }


    /// <summary>
    ///   处理异常
    /// </summary>
    private void HandleException(Exception e)
    {
      if( exceptionHandler != null )
	exceptionHandler(clientSocket, e);

    }

  }



}

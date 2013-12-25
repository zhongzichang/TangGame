/**
 * Created by emacs
 * Date: 2013/10/18
 * Author: zzc
 */
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangNet
{
  public class TnFacadeBhvr : MonoBehaviour
  {
    /// <summary>
    ///   超过这个时间没有接收到任何数据包，将断开网络连接
    /// </summary>
    public const float TIME_OUT_LIMIT = 3600F;
    
    private IFacade facade;
    private float hourglass = TIME_OUT_LIMIT;

    void Start()
    {
      facade = Facade.Instance;
      RegisterCommands();
    }

    void OnDestroy()
    {
      RemoveCommands();
    }

    void Update()
    {

      
      if( Cache.notificationQueue.Count > 0 )
	{
	  int count = Cache.notificationQueue.Count;
	  for( int i=0; i<count; i++ )
	    {
	      Facade.Instance.NotifyObservers( Cache.notificationQueue.Dequeue() );
	    }

	  // 重置沙漏时间
	  hourglass = TIME_OUT_LIMIT;

	}
      else if( Cache.connected )
	{
	  hourglass -= Time.deltaTime;
	  
	  // 超时
	  if( hourglass <= 0F )
	    {
	      // 发送 Close 消息，让 TnBhvr 执行关闭 socket 方法
	      SendMessage("Close");
	    }
	}

    }


    private void RegisterCommands()
    {
      facade.RegisterCommand( ConnectCmd.NAME, typeof(ConnectCmd) );
      facade.RegisterCommand( CloseCmd.NAME, typeof(CloseCmd) );
    }

    private void RemoveCommands()
    {
      facade.RemoveCommand( ConnectCmd.NAME );
      facade.RemoveCommand( CloseCmd.NAME );
    }
  }
}
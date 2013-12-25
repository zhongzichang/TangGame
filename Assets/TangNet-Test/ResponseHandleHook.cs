/**
 * Response handle hook
 * Date: 2013/11/5
 * Author: zzc
 */

using UnityEngine;

namespace TangNet
{
  public class ResponseHandleHook : MonoBehaviour
  {

    void Start()
    {
      TN.SocketClient.ResponseHandler.handleHook = OnHandleMsgData;

    }

    private void OnHandleMsgData(MsgData data)
    {
	  string name = data.GetString(0);
			if ("skillUpdate_PUSH".Equals(name))
      	Debug.Log("Handling Remote MsgData " + name );
    }
    
  }
}
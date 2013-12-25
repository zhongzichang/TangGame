/*
 * Created by emacs
 * Date: 2013/9/13
 * Author: zzc
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;

namespace Tang
{
  public class ResourceLoader : MonoBehaviour
  {
    public delegate void LoadCompleted (WWW www);

    public delegate void LoadFailure (WWW www);

    public delegate void LoadBegan (WWW www);

    public const float NOTIFY_SPAN = 0.01F;
    private static Queue<string> waitingQueue = new Queue<string> ();
    private static Queue<string> loadingQueue = new Queue<string> ();
    private static Dictionary<string, WWW> loadedTable = new Dictionary<string, WWW> ();
    private static Dictionary<string, LoadCompleted> completedHandlerTable = new Dictionary<string, LoadCompleted> ();
    private static Dictionary<string, LoadFailure> failureHandlerTable = new Dictionary<string, LoadFailure> ();
    private static Dictionary<string, LoadBegan> beganHandlerTable = new Dictionary<string, LoadBegan> ();
    private static float lastProgress = 0F;
    private static WWW loadingWWW = null;

    public static void Enqueue (string filepath, LoadCompleted completedHandler)
    {
      Enqueue (filepath, completedHandler, null);
    }

    public static void Enqueue (string filepath, LoadCompleted completedHandler, LoadFailure failureHandler)
    {
      Enqueue (filepath, completedHandler, failureHandler, null);
    }

    public static int UncompletedCount
    {
      get
	{
	  return waitingQueue.Count + loadingQueue.Count;
	}
    }

    public static void Enqueue (string filepath, 
				LoadCompleted completedHandler, 
				LoadFailure failureHandler,
				LoadBegan beganHandler)
    {

      waitingQueue.Enqueue (filepath);
      
      if (completedHandler != null) {
	if (completedHandlerTable.ContainsKey (filepath))
	  completedHandlerTable [filepath] += completedHandler;
	else
	  completedHandlerTable.Add (filepath, completedHandler);
      }
      
      if (failureHandler != null) {
	if (failureHandlerTable.ContainsKey (filepath))
	  failureHandlerTable [filepath] += failureHandler;
	else
	  failureHandlerTable.Add (filepath, failureHandler);
      }

      if (beganHandler != null) {
	if (beganHandlerTable.ContainsKey (filepath))
	  beganHandlerTable [filepath] += beganHandler;
	else
	  beganHandlerTable.Add (filepath, beganHandler);
      }
    }

    private static IEnumerator Load ()
    {

      string filepath = waitingQueue.Dequeue ();

      LoadCompleted loadCompletedHandler = null;
      LoadFailure loadFailureHandler = null;
      LoadBegan loadBeganHandler = null;

      if (filepath != null) {
	// take out delegate methods
	if (completedHandlerTable.ContainsKey (filepath))
	  loadCompletedHandler = completedHandlerTable [filepath];
	if (failureHandlerTable.ContainsKey (filepath))
	  loadFailureHandler = failureHandlerTable [filepath];
	if (beganHandlerTable.ContainsKey (filepath))
	  loadBeganHandler = beganHandlerTable [filepath];
	completedHandlerTable.Remove (filepath);
	failureHandlerTable.Remove (filepath);
	beganHandlerTable.Remove (filepath);

	if (loadedTable.ContainsKey (filepath)) {
	  if (loadBeganHandler != null)
	    loadBeganHandler (loadedTable [filepath]);

	  // have loaded
	  if (loadCompletedHandler != null)
	    loadCompletedHandler (loadedTable [filepath]);
	} else {
	  // ready load
	  loadingQueue.Enqueue (filepath);
	  WWW www = new WWW (filepath);
	  loadingWWW = www;
	  lastProgress = 0F;
	  if (loadBeganHandler != null)
	    loadBeganHandler (www);

	  yield return www;
	  loadingWWW = null;
	  if (www.error == null) {
	    // load success
	    loadedTable.Add (filepath, www);
	    if (loadCompletedHandler != null)
	      loadCompletedHandler (www);
	  } else {
	    // load failure
	    if (loadFailureHandler != null)
	      loadFailureHandler (www);
	  }
	  loadingQueue.Dequeue ();
	}
      }
    }

    void Update ()
    {
      if (loadingQueue.Count == 0 && waitingQueue.Count > 0)
	StartCoroutine (Load ());

      if (loadingWWW != null && (loadingWWW.progress - lastProgress) > NOTIFY_SPAN) {
	Facade.Instance.SendNotification (NtftNames.TANG_WWW_PROGRESS, loadingWWW);
      }
      
    }
  }
}
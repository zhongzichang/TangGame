/**
 * Tracer behaviour
 *
 * Date: 2013/10/24
 * Author: zzc
 */
using UnityEngine;
using PureMVC.Patterns;

namespace TangScene
{

  /// <summary>
  ///   跟踪状态
  /// </summary>
  public enum TraceStatus
  {
    start,
    enter,
    lost
  }

  [RequireComponent(typeof(CharacterStatusBhvr))]
  [RequireComponent(typeof(Navigable))]
  public class TracerBhvr : MonoBehaviour
  {
    public const float DEFULT_CACHE_DISTANCE = 50F;
    public const float DEFAULT_START_DISTANCE = 200F;
    public const float MIN_CACHE_DISTANCE = 10F;
    public const float CHECK_PERIOD = 2F;
    

    // 目标
    public Transform target;

    // 跟踪者ID
    [HideInInspector]
    public long tracerId;
    // 目标ID
    [HideInInspector]
    private long m_targetId;

    private float checkTime = 0F;

    private Vector3 targetLastPosition = Vector3.zero;

    // 目标ID，代码用
    public long targetId {
      get {
        return m_targetId;
      }
      set {
        m_targetId = value;
        if (Cache.actors.ContainsKey (value))
          target = Cache.actors [value].transform;
        else
          target = null;
      }
    }

    /// <summary>
    ///   停止跟踪需要的距离
    /// </summary>
    public float cacheDistance;

    /// <summary>
    ///   启动跟踪需要的距离
    /// </summary>
    public float startDistance;

    private CharacterStatusBhvr characterStatusBhvr;
    private Navigable navigable;
    private TraceStatus traceStatus;


    public void TraceStart ()
    {

      Reset();

      target = Cache.actors [targetId].transform;
      targetLastPosition = target.localPosition;
      traceStatus = TraceStatus.start;


      if ( target != null && target.localScale != Vector3.zero)
      {

        float distance = Vector3.Distance (transform.localPosition, target.localPosition);

        if (distance < cacheDistance+20F)
        {
          Facade.Instance.SendNotification ( NtftNames.TRACE_RANGE_ENTER,
                                            new TraceBean (tracerId, targetId));
          traceStatus = TraceStatus.enter;
        }
        else
        {
          navigable.NavTo ( target.localPosition, cacheDistance );
        }

      }
      else
      {
        traceStatus = TraceStatus.lost;
        Facade.Instance.SendNotification (NtftNames.TRACE_TARGET_LOST,
                                          new TraceBean (tracerId, targetId));
        this.enabled = false;
      }
      
    }

    /// <summary>
    ///   重置距离参数
    /// </summary>
    private void Reset ()
    {

      if (cacheDistance < MIN_CACHE_DISTANCE)
        cacheDistance = MIN_CACHE_DISTANCE;

      if (startDistance < cacheDistance)
        startDistance = cacheDistance * 2;
    }


    // 状态发生改变时回调
    private void OnStatusChange (CharacterStatus status)
    {
      if (status == CharacterStatus.idle && traceStatus == TraceStatus.start && target != null)
      {
        float distance = Vector3.Distance (transform.localPosition, target.localPosition);

        if( distance <= cacheDistance + 20F )
        {
          Facade.Instance.SendNotification (NtftNames.TRACE_RANGE_ENTER, new TraceBean (tracerId, targetId));
          traceStatus = TraceStatus.enter;
          
        }
      }
    }


    void Awake ()
    {

      characterStatusBhvr = GetComponent<CharacterStatusBhvr> ();
      navigable = GetComponent<Navigable> ();


    }

    void Update ()
    {

      if (target != null && target.localScale != Vector3.zero)
      {

        checkTime += Time.deltaTime;
        
        if( checkTime > CHECK_PERIOD )
        {
          // 目标有效
          if ( targetLastPosition != target.localPosition )
          {
            float distance = Vector3.Distance (transform.localPosition, target.localPosition);
            if (distance > startDistance)
              navigable.NavTo (target.localPosition, cacheDistance);
          }
          checkTime = 0F;
        }

      }
      else
      {
        // 目标无效
        traceStatus = TraceStatus.lost;
        Facade.Instance.SendNotification (NtftNames.TRACE_TARGET_LOST,
                                          new TraceBean (tracerId, targetId));
        this.enabled = false;
      }
      
    }

    void OnEnable ()
    {

      // ensure contains
      if ( Cache.actors.ContainsKey (targetId) )
      {
        characterStatusBhvr.statusStartHandler += OnStatusChange;
      }
      else
        this.enabled = false;

    }

    void OnDisable ()
    {

      characterStatusBhvr.statusStartHandler -= OnStatusChange;
      Facade.Instance.SendNotification (NtftNames.TRACE_CANCEL, new TraceBean (tracerId, targetId));

    }


  }
}
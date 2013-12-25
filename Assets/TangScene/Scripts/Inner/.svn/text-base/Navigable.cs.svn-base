/**
 * Created by Emacs
 * Date: 2013/9/2
 * Author: zzc
 */
using UnityEngine;
using TangUtils;

namespace TangScene
{
  [ExecuteInEditMode]
  [RequireComponent(typeof(NavMeshAgent))]
  public class Navigable : MonoBehaviour
  {

    public delegate void NextPositionChange (Vector3 nextPosition);

    public NextPositionChange nextPositionChangeHandle = null;

    public delegate void LocalPositionChange (Vector3 localPosition);

    public LocalPositionChange localPositionChangeHandle = null;
    public const float CACHE_DISTANCE = 10F; // 距离目标人物等于小于这个距离的时候人物动作由跑动改为站立(run=>idle)
    public static readonly Vector2 NOTIFIED_RANGE = new Vector2 (32F, 16F); // 摇杆操作，角色移动超过这个距离发通知（如果需要 nextPositionChangeHandle != null）

    public float m_speed = 240F;
    private NavMeshAgent agent;
    private CharacterStatusBhvr statusBhvr;
    private Directional directional;
    private Vector3 lastPosition = Vector3.zero;
    private const float PREIOD_CHECK_TIME = 0.1F;
    private Vector3 lastCheckPosition = Vector3.zero;
    private float checkTimer = 0F;
    private Vector3 m_nextPosition = Vector3.zero;
    private Vector3 lastRecordMovePosition = Vector3.zero;
    private int lastCornersLength = 0;
    
    // 是不是使用摇杆类似的输入
    private bool isMove = false;

    private Vector3 NextPosition {
      get {
        return m_nextPosition;
      }
      set {
        m_nextPosition = value;
        if (nextPositionChangeHandle != null)
          nextPositionChangeHandle (value);
      }
    }

    public float Speed {
      get {
        return m_speed;
      }
      set {
        m_speed = value;
        if (agent != null) {
          agent.speed = value;
        }
      }
    }
    

    /// <summary>
    ///   Navigate to a destination
    /// </summary>
    public void NavTo (Vector3 position)
    {
      NavTo (position, 0F);
    }

    /// <summary>
    ///   Navigate to a destination with stopping distance
    /// </summary>
    public void NavTo (Vector3 position, float stoppingDistance)
    {

      if (agent != null && agent.enabled) {

    
        agent.ResetPath ();
        Vector3 fixedPosition = new Vector3 (position.x, transform.localPosition.y, position.z);
        agent.SetDestination (fixedPosition);
        agent.stoppingDistance = stoppingDistance;
        m_nextPosition = transform.localPosition;
        lastCornersLength = 0;
      }
      
    }

    /// <summary>
    ///   Move by joystick
    /// </summary>
    public void Move (Vector3 moveDirection)
    {
      
      if (agent != null && agent.enabled) {

        isMove = true;

        agent.ResetPath();
        Vector3 normalized = transform.TransformDirection (moveDirection).normalized;
        agent.Move (normalized * agent.speed * Time.deltaTime);

        //NavTo(transform.localPosition + forward * 50F );

        if (statusBhvr.Status != CharacterStatus.run)
          statusBhvr.Status = CharacterStatus.run;

        Vector3 vector3 = transform.localPosition - lastRecordMovePosition;

        if ((Mathf.Abs (vector3.x) - NOTIFIED_RANGE.x) > 0 || 
          (Mathf.Abs (vector3.z) - NOTIFIED_RANGE.y) > 0) {
          lastRecordMovePosition = transform.localPosition;
          NextPosition = transform.localPosition;
        }
    
      }
    }




#region mono

    void Start ()
    {

      // agent
      agent = GetComponent<NavMeshAgent> ();
      if (agent == null)
        agent = gameObject.AddComponent<NavMeshAgent>();
      
      // initialize agent
      agent.radius = 0.5F;
      agent.speed = m_speed;
      agent.acceleration = 999999F;
      agent.angularSpeed = 0F;
      agent.stoppingDistance = 0F;
      agent.autoTraverseOffMeshLink = true;
      agent.autoBraking = true;
      agent.autoRepath = true;
      agent.height = 2;
      agent.baseOffset = 0;
      agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
      agent.avoidancePriority = 50;

      // character status bhvr
      statusBhvr = GetComponent<CharacterStatusBhvr> ();

      // directional
      directional = GetComponent<Directional> ();

      // last position
      lastPosition = transform.localPosition; 
    }

    void Update ()
    {

      if (agent.hasPath) {

        // status(run/idle) checking ------

        if (Vector2.Distance (new Vector2 (agent.destination.x,
             agent.destination.z),
             new Vector2 (transform.localPosition.x,
             transform.localPosition.z)) - agent.stoppingDistance
          < CACHE_DISTANCE) {

          if (statusBhvr != null) {
            if (statusBhvr.Status == CharacterStatus.run) {
              statusBhvr.Status = CharacterStatus.idle;
            }
          }
        } else {
          if (statusBhvr != null) {
            if (statusBhvr.Status != CharacterStatus.run) {
              statusBhvr.Status = CharacterStatus.run;
            }
          }
        }

        // send next position notification ------

        if (lastCornersLength != agent.path.corners.Length) {
          // 如果路径的 corners.Length 发生变化，说明角色转弯了，需要向服务器发送下一个转角的位置
          NextPosition = agent.path.corners [1];

          EightDirection currentDirection = VectorUtils.Direction (transform.localPosition, 
                      NextPosition);
          // 调整角色方向
          if (directional.Direction != currentDirection)
            directional.Direction = currentDirection;
        
          lastCornersLength = agent.path.corners.Length;

        }
        
      } // if agent.hasPath
      
      else {

        if (lastCheckPosition == transform.localPosition) {

          if (!isMove) {
              
            if (statusBhvr.Status == CharacterStatus.run)
              statusBhvr.Status = CharacterStatus.idle;
            
          } else {
            
            // 使用摇杆的情况
            isMove = false;
          }
          

        } else if (statusBhvr.Status == CharacterStatus.run) {

          checkTimer += Time.deltaTime;
          if (checkTimer > PREIOD_CHECK_TIME) {
            
            EightDirection currentDirection = VectorUtils.Direction (lastPosition, transform.localPosition);
            if (directional.Direction != currentDirection)
              directional.Direction = currentDirection;
            
            lastCheckPosition = transform.localPosition;
            checkTimer = 0F;
          }
        }



      
      
      }
      
      // position at last update
      float localPositionX = Mathf.Round (transform.localPosition.x);
      float localPositionZ = Mathf.Round (transform.localPosition.z);

      if (lastPosition.x != localPositionX &&
        lastPosition.z != localPositionZ) {
        lastPosition = new Vector3 (localPositionX, transform.localPosition.y, localPositionZ);
        if (localPositionChangeHandle != null)
          localPositionChangeHandle (lastPosition);
      }
      
      lastCheckPosition = transform.localPosition;
      
    }
#endregion
  }
}
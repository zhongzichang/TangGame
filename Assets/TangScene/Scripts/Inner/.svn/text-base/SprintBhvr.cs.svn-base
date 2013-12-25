/**
 * sprint behaviour
 *
 * Ref: SprintFollowBehaviour by HuangXiaoBo
 * Author: zzc
 * Date: 2013/11/1
 */

using UnityEngine;

namespace TangScene
{
  [ RequireComponent(typeof(CharacterStatusBhvr)) ]
  public class SprintBhvr : MonoBehaviour
  {

    // 小于这个距离不用冲刺
    public const float MIN_SPRINT_DISTANCE = 50F;
    
    public const float DEFAULT_SPEED = 800F;

    #region NeedForSet
    // 目标角色ID
    public long targetId = 0;
    // 目标位置
    public Vector3 targetPosition = Vector3.zero;
    #endregion
    // 冲刺速度
    public float speed = DEFAULT_SPEED;

    private GameObject targetGobj;
    private Vector3 direction = Vector3.zero;
    private NavMeshAgent agent = null;
    private CharacterStatusBhvr statusBhvr = null;
    
    void Awake()
    {
      agent = gameObject.GetComponent<NavMeshAgent>();
      statusBhvr = gameObject.GetComponent<CharacterStatusBhvr>();
      if( statusBhvr != null )
      {
        statusBhvr.statusStartHandler += OnStatusStart;
        statusBhvr.statusEndHandler += OnStatusEnd;
      }

    }

    void OnEnable()
    {
      
      if( Cache.actors.ContainsKey( targetId )  && statusBhvr != null )
      {
        targetGobj = Cache.actors[ targetId ];
        // 获取目标位置
        if( targetPosition == Vector3.zero )
          targetPosition = targetGobj.transform.localPosition;

        // 计算方向
        direction = GameUtils.GetDirection(transform.localPosition, targetPosition);

        if( agent != null )
          agent.enabled = false;
      }
      else
        this.enabled = false;

    }

    void OnDisable()
    {

      if( agent != null )
        agent.enabled = true;

      targetId = 0;
      targetPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
      if( targetId != 0 )
      {
        if( Vector3.Distance( transform.localPosition, targetPosition )
           < MIN_SPRINT_DISTANCE)
        {
          this.enabled = false;
          statusBhvr.Status = CharacterStatus.sprintBrake;
        }
        else
          transform.Translate( Time.deltaTime * speed * direction );

      }
    }

    private void OnStatusStart( CharacterStatus status )
    {
      if( status == CharacterStatus.sprintGlide )
      {
        this.enabled = true;
      }


    }

    private void OnStatusEnd( CharacterStatus status )
    {

      if( status == CharacterStatus.sprintGlide )
      {
        this.enabled = false;
      }
    }

  }
}
/**
 * sprint with position behaviour
 *
 * Ref: SprintFollowBehaviour by HuangXiaoBo
 * Author: zzc
 * Date: 2013/11/1
 */

using UnityEngine;

namespace TangScene
{
  [ RequireComponent(typeof(CharacterStatusBhvr)) ]
  public class SprintWithPosBhvr : MonoBehaviour
  {

    // 小于这个距离停止冲刺
    public const float MIN_SPRINT_DISTANCE = 1F;
    
    public const float DEFAULT_SPEED = 800F;

    #region NeedForSet
    // 目标位置
    public Vector3 targetPosition = Vector3.zero;
    #endregion
    // 冲刺速度
    public float speed = DEFAULT_SPEED;

    private GameObject targetGobj;
    private Vector3 direction = Vector3.zero;
    private NavMeshAgent agent = null;
    private CharacterStatusBhvr statusBhvr = null;
    private Transform myTransform;
    
    void Awake()
    {
      myTransform = transform;
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
      
      if( statusBhvr != null && targetPosition != Vector3.zero )
      {
        // 计算方向
        direction = GameUtils.GetDirection(transform.localPosition, targetPosition);

        if( agent != null )
	  {
	    agent.ResetPath();
	    agent.enabled = false;
	    
	  }
      }
      else
        this.enabled = false;

    }

    void OnDisable()
    {

      if( agent != null )
        agent.enabled = true;

      targetPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
      if( targetPosition != Vector3.zero )
      {
        float distance = Vector3.Distance( myTransform.localPosition, targetPosition );
        if( distance < MIN_SPRINT_DISTANCE)
        {
          this.enabled = false;
          statusBhvr.Status = CharacterStatus.sprintBrake;
        }
        else {
          //transform.Translate( Time.deltaTime * speed * direction );
          myTransform.localPosition = Vector3.Lerp(myTransform.localPosition, targetPosition, Time.deltaTime * speed/ distance);
        }

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
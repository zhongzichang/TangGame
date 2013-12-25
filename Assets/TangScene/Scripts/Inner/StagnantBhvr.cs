/**
 *
 * Stagnant behaviour
 *
 * Date: 2013/11/1
 * Author: zzc
 */
using UnityEngine;


namespace TangScene
{

  public class StagnantBhvr : MonoBehaviour
  {
    // 停滞时角色的速度
    public const float STAGNANT_SPEED = 1F;

    // 停滞持续时间
    private float m_stagnantTime = 0;
    // 速度备份
    private float speedBackup = 240F;

    private Navigable navigable = null;


    // 停滞持续时间
    public float StagnantTime
    {
      get
	{
	  return m_stagnantTime;
	}
      set
	{
	  if( value > m_stagnantTime )
	    {
	      // 设置停滞
	      if( !this.enabled )
		{
		  // 备份速度
		  speedBackup = navigable.Speed;
		  // 降低速度
		  navigable.Speed = STAGNANT_SPEED;
		  // 启用组件
		  this.enabled = true;
		}
	      m_stagnantTime = value;
	    }
	}
    }

    void Awake()
    {
      navigable = GetComponent<Navigable>();
    }


    void Update()
    {
      m_stagnantTime -= Time.deltaTime;
      if( m_stagnantTime <= 0 )
	{
	  // 恢复速度
	  if( navigable != null )
	    navigable.Speed = speedBackup;
	  // 停用组件
	  this.enabled = false;
	}
    }
  }
  
}
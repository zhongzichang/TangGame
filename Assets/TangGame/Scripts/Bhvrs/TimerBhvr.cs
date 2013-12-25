///xbhuang
///小伙伴们，来点乐子吧！
using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// 计时器
/// </summary>
public class TimerBhvr : MonoBehaviour {
	/// <summary>
	/// 根据时间一次性调用回调函数
	/// </summary>
	public class APeriod{
		public float time;
		public object obj;
		public Callback callback;
		public CallbackWithObject callbackWithObject;
		//在指定时间后执行
		public APeriod(float time,Callback callback){this.time = time; this.callback = callback;this.obj = null;}
		public APeriod(float time,CallbackWithObject callbackWithObject,object obj){this.time = time; this.callbackWithObject = callbackWithObject;this.obj = obj;}
		//是否是一段时间后执行
//		public Throwaway(float time,Callback callback,bool isAfterPeriodOfTime){if(isAfterPeriodOfTime){this.time = Time.time+time;}else{this.time = time;} this.callback = callback;}
	}
	
	public delegate void Callback();
	public delegate void CallbackWithObject(object obj);
	void Start(){
		/// <summary>
		/// 加载场景的时候不能销毁这个对象
		/// </summary>
		DontDestroyOnLoad(this.gameObject);
	}
	
	public static List<APeriod> commandList = new List<APeriod>();
	// Update is called once per frame
	void Update () {
		ThrowawayCallBack();
	}
	/// <summary>
	/// 根据时间一次性回调函数
	/// </summary>
	private void ThrowawayCallBack(){
		for(int i=0; i<commandList.Count; i++){
			APeriod command = commandList[i];
			if(command.time < Time.time){
				if(command.obj == null){
					command.callback();
				}else{
					command.callbackWithObject(command.obj);
				}
				commandList.RemoveAt(i);
			}
		}
	}
}
/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/8/6
 * Time: 17:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tang
{
  /// <summary>
  /// Description of Animation.
  /// </summary>
  [ExecuteInEditMode]
  public class SpriteAnimation : MonoBehaviour
  {

    public delegate void LastFrame(SpriteAnimation animation);
    public LastFrame lastFrameHandler;

    public delegate void CurrentIndexChange(int index);
    public CurrentIndexChange currentIndexChange;

    public SpriteLayerBhvr.SpriteReady spriteReadyHandler;

    

    /// <summary>
    /// Prefab
    /// </summary>
    public SpriteLayer[] layers; // 层 1...*
    public int loop = -1; // 播放次数，<0 表示无限循环播放
    public int fps = Config.fps; // FPS，每秒多少帧
    public int m_currentIndex = 0; // 当前放到第几帧
    public bool m_flipHorizontal = false; // 是否水平翻转
    public bool m_flipVertical = false; // 是否垂直翻转
    public float delay = 0F; // 延迟多少秒开始
    public bool playOnStart = false; // 在 Mono 的 Start() 方法执行播放

#region Private Fields
    private int maxIndex = 0; // 当前动画的最大帧的索引值，从0开始
		
    private float currentTime = 0F; // 当前帧已显示的时间，每一帧的现实时间不能超过 1F/FPS
    private bool playing = false; // 是否正在播放
    private float delayTimer = 0F; // 延迟计时器， 当计时器初始值 =delay，递减到0后开始播放内容
    private int loopCounter = 0; // 播放次数计算器

#endregion
		
#region Public Properties


    /// <summary>
    ///   获取动画当前最大索引值
    /// </summary>
    public int MaxIndex
    {
      get
	{
	  return maxIndex;
	}
    }

    /// <summary>
    /// 当前帧索引，从0开始到 maxIndex
    /// </summary>
    public int currentIndex {
      get {
	return m_currentIndex;
      }
      set {

	if( m_currentIndex != value )
	  {
	    m_currentIndex = value;
	    if( currentIndexChange != null )
	      currentIndexChange(value);
	  }

	m_currentIndex = value;
	UpdateSpriteIndexes();
	
      }
    }
    /// <summary>
    /// 是否水平翻转
    /// </summary>
    public bool flipHorizontal {
      get { return m_flipHorizontal; }
      set {
	m_flipHorizontal = value;

	foreach(Transform child in transform)
	  {
	    foreach(Transform grandchild in child)
	      {
		TTSprite sprite = grandchild.GetComponent<TTSprite>();
		if( sprite != null )
		  {
		    sprite.flipHorizontal = value;
		  }
	      }
	  }
      }
    }
    /// <summary>
    /// 是否垂直翻转
    /// </summary>
    public bool flipVertical {
      get { return m_flipVertical; }
      set {
	m_flipVertical = value;

	foreach(Transform child in transform)
	  {
	    foreach(Transform grandchild in child)
	      {
		TTSprite sprite = grandchild.GetComponent<TTSprite>();
		if( sprite != null )
		  {
		    sprite.flipVertical = value;
		  }
	      }
	  }

      }
    }
    /// <summary>
    /// 是否正在播放
    /// </summary>
    public bool IsPlaying{
      get{
	return playing;
      }
    }
#endregion
		
#region Public Method

    /// <summary>
    /// 将一个精灵层放入动画中
    /// </summary>
    /// <param name="layer">精灵层</param>
    public void PutLayer( TsLayer layer ){
      InitLayer(layer);
    }
    
    public void PutLayer( SpriteLayer layer ){
      if( layers != null && layers.Length > 0 )
	{
	  bool exists = false;
	  for(int i=0; i<layers.Length; i++ )
	    {
	      if( layer.name == layers[i].name )
		{
		  layers[i] = layer;
		  exists = true;
		  break;
		}
	    }
	  if( !exists )
	    {
	      Array.Resize(ref layers, layers.Length+1);
	      layers[layers.Length-1] = layer;
	    }
	  
	}
      else
	{
	  layers = new SpriteLayer[1];
	  layers[0] = layer;
	}
      InitLayer(layer);
    }


    /// <summary>
    /// 在指定层打开一个精灵，指定的层必须存在
    /// </summary>
    /// <param name="spritePrefab">精灵 sprite</param>
    /// <param name="index">所在层 index</param>
    public void Open( string spriteName, string layerName ){
      
      foreach( Transform child in transform )
	{
	  if( child.name == layerName )
	    {
	      SpriteLayerBhvr bhvr = child.GetComponent<SpriteLayerBhvr>();
	      bhvr.spriteName = spriteName;
	      break;
	    }
	}

      Debug.Log("Failed to open sprite " + spriteName + " on layer " + layerName);

    }

    /// <summary>
    /// 播放
    /// </summary>
    public void Play(){
      playing = true;
    }

    /// <summary>
    /// 停止
    /// </summary>
    public void Stop(){
      playing = false;
      Reset();
    }

    /// <summary>
    ///   暂停
    /// </summary>
    public void Suspend()
    {
      playing = false;
    }

    public void DestroyChildren()
    {
      foreach(Transform child in transform)
	{
#if UNITY_EDITOR
	  DestroyImmediate( child.gameObject );
#else
	  Destroy( child.gameObject );
#endif
	}
    }

#endregion
		
#region Private Methods

    private void OnLayerMaxIndexChange( int layerMaxIndex )
    {

      if( layerMaxIndex > this.maxIndex )
	this.maxIndex = layerMaxIndex;
      else
	{
	  int tempMaxIndex = 0;
	  foreach( Transform child in transform )
	    {
	      SpriteLayerBhvr layerBhvr = child.GetComponent<SpriteLayerBhvr>();
	      if( layerBhvr != null && layerBhvr.maxIndex > tempMaxIndex)
		{
		  tempMaxIndex = layerBhvr.maxIndex;
		}
	    }
	  this.maxIndex = tempMaxIndex;
	}

    }

    private void UpdateSpriteIndexes()
    {

      foreach( Transform child in transform )
	{
	  SpriteLayerBhvr layerBhvr = child.GetComponent<SpriteLayerBhvr>();
	  
	  foreach( Transform grandchild in child )
	    {
	      TTSprite sprite = grandchild.GetComponent<TTSprite>();
	      int index = currentIndex - layerBhvr.frameDelay;

	      if( index < 0 )
		{
		  if( layerBhvr.hiddenBeforeBegin && !layerBhvr.hidden )
		    {
		      layerBhvr.hidden = true;
		    }
		}
	      
	      else if( index > layerBhvr.maxIndex )
		{
		  if( layerBhvr.hiddenAfterEnd && ! layerBhvr.hidden )
		    {
		      layerBhvr.hidden = true;
		    }
		}
	      
	      else if( layerBhvr.hidden )
		{
		  layerBhvr.hidden = false;
		}

	      sprite.currentIndex = index;
	      
	    }
	}
			
    }

    private void Reset()
    {
      currentIndex = 0;
      currentTime = 0F;
      delayTimer = delay;
      loopCounter = loop;
    }

    private void HideLayer(SpriteLayerBhvr layerBhvr, bool yes){
      
      if( yes ) {
	layerBhvr.hidden = true;
	layerBhvr.transform.localScale = Vector3.zero;
      } else {
	layerBhvr.hidden = false;
	layerBhvr.transform.localScale = Vector3.one;
      }
    }

    /// <summary>
    ///   dynamic layer
    /// </summary>
    private void InitLayer( TsLayer layer )
    {
      SpriteLayerBhvr layerBhvr = AddLayerBhvr( layer.name );
      InitLayerBhvr( layerBhvr, layer );
      layerBhvr.spriteName = layer.sprite.name;
      layerBhvr.spriteReadyHandler = this.spriteReadyHandler;
    }

    /// <summary>
    ///   Initialize static sprite layer
    /// </summary>
    private void InitLayer( SpriteLayer layer )
    {
			
      SpriteLayerBhvr layerBhvr = AddLayerBhvr( layer.name );
      InitLayerBhvr( layerBhvr, layer );
      layerBhvr.spritePrefab = layer.spritePrefab;
      layerBhvr.spriteReadyHandler = this.spriteReadyHandler;
    }

    private SpriteLayerBhvr AddLayerBhvr( string layerName )
    {
      // 确保 layer's gameObject 存在，没有则生成
      Transform layerTransform = transform.FindChild( layerName );
      SpriteLayerBhvr layerBhvr = null;
      if( layerTransform == null )
	{

	  // game object of layer
	  GameObject layerGobj = new GameObject();
	  layerGobj.transform.parent = transform;
	  layerGobj.name = layerName;
	  layerTransform = layerGobj.transform;

	  layerBhvr = layerGobj.AddComponent<SpriteLayerBhvr>();

	}
      
      else // layer transform != null
	{

	  layerBhvr = layerTransform.GetComponent<SpriteLayerBhvr>();

	  if( layerBhvr == null )
	      layerBhvr = layerTransform.gameObject.AddComponent<SpriteLayerBhvr>();
	}
      return layerBhvr;
      
    }

    /// <summary>
    ///   static layer
    /// </summary>
    private void InitLayerBhvr( SpriteLayerBhvr layerBhvr, SpriteLayer layer )
    {

      layerBhvr.frameDelay = layer.frameDelay;
      layerBhvr.hiddenBeforeBegin = layer.hiddenBeforeBegin;
      layerBhvr.hiddenAfterEnd = layer.hiddenAfterEnd;

    }

    /// <summary>
    ///   dynamic layer
    /// </summary>
    private void InitLayerBhvr( SpriteLayerBhvr layerBhvr, TsLayer layer )
    {

      layerBhvr.frameDelay = layer.frameDelay;
      layerBhvr.hiddenBeforeBegin = layer.hiddenBeforeBegin;
      layerBhvr.hiddenAfterEnd = layer.hiddenAfterEnd;
      
    }


		
    private void DestroyGobj(GameObject gobj){

#if UNITY_EDITOR
      DestroyImmediate(gobj);
#else 
      Destroy(gobj);
#endif
    }


    private void OnLastFrame()
    {
      if( lastFrameHandler != null )
	lastFrameHandler(this);
    }


#endregion
		
#region Mono Methods
		
    void Start(){
			
			
      // init layers ---
      if( layers != null && layers.Length > 0 )
	for(int i=0; i<layers.Length; i++)
	  InitLayer(layers[i]);		

      // init fields ---

      currentIndex = currentIndex;
      flipHorizontal = flipHorizontal;
      flipVertical = flipVertical;
			
      // play on start
      if ( playOnStart )
	playing = true;
      else
	playing = false;
			
      loopCounter = loop;
      delayTimer = delay;
			
			
    }
		
		
    void Update(){
			
      if( playing && maxIndex > 0 ) {
				
				
	if( delayTimer > 0F )
	  {
					
	    delayTimer -= Time.deltaTime;
					
	  }
	else
	  {
				
	    currentTime += Time.deltaTime;
	    int nextIndex = (int)(fps * currentTime);
					
	    if( currentIndex != nextIndex ){
						
	      currentIndex = nextIndex;
						
	      if( currentIndex == maxIndex ){
							
		// 要播放到最后一帧了
							
		if( loopCounter == 0 )
		  Stop();
		else if( loopCounter > 0)
		  loopCounter--;

		// 回调
		OnLastFrame();
							
	      } else if( currentIndex > maxIndex ){
							
		// 超过最大帧，将转到第一帧
							
		currentIndex = 0;
		currentTime = 0F;
	      }
	    }
	  }
      }
    }
		
#endregion
  }
}

using System.Collections;
using UnityEngine;

namespace Tang
{

  [ExecuteInEditMode]
  public class SpriteLayerBhvr : MonoBehaviour
  {

    public delegate void SpriteReady(TTSprite sprite);
    public SpriteReady spriteReadyHandler;
		

    // predefine variables
    public int frameDelay = 0;
    public bool hiddenBeforeBegin = true;
    public bool hiddenAfterEnd = true;

    private AssetBundle m_spriteAssetBundle;
    private bool spriteAssetBundleUpdated = false;
    private TTSprite m_spritePrefab = null;
    private bool spritePrefabUpdated = false;
    private string m_spriteName = null;
    private bool m_hidden = false;
    private int m_maxIndex = 0;
    private bool m_flipHorizontal = false;
    private bool m_flipVertical = false;

    public string spriteName
    {
      get
	{
	  return m_spriteName;
	}
      set
	{
	  if( m_spriteName != value )
	    {
	      m_spriteName = value;
	      OnSpriteNameChange();
	    }
	}
    }

    public TTSprite spritePrefab
    {
      get
	{
	  return m_spritePrefab;
	}
      set
	{
	  m_spritePrefab = value;
	  spritePrefabUpdated = true;
	}
    }

    public bool hidden
    {
      get
	{
	  return m_hidden;
	}
      set
	{
	  if( m_hidden != value )
	    {
	      m_hidden = value;
	      if( m_hidden )
		transform.localScale = Vector3.zero;
	      else
		transform.localScale = Vector3.one;
	    }
	}
    }

    public int maxIndex
    {
      get
	{
	  return m_maxIndex;
	}
      set
	{
	  if( m_maxIndex != value )
	    {
	      m_maxIndex = value;
	      if( transform.parent != null )
		transform.parent.SendMessage("OnLayerMaxIndexChange", value);
	    }
	}
    }

    public bool flipHorizontal
    {
      get
	{
	  return m_flipHorizontal;
	}
      set
	{
	  if( m_flipHorizontal != value )
	    {
	      m_flipHorizontal = value;
	      TTSprite sprite;      
	      foreach( Transform child in transform )
		{
		  sprite = child.GetComponent<TTSprite>();
		  if( sprite != null )
		    sprite.flipHorizontal = true;
		}
	    }
	}
    }

    public bool flipVertical
    {
      get
	{
	  return m_flipVertical;
	}
      set
	{
	  if( m_flipVertical != value )
	    {
	      m_flipVertical = value;
	      TTSprite sprite;      
	      foreach( Transform child in transform )
		{
		  sprite = child.GetComponent<TTSprite>();
		  if( sprite != null )
		    sprite.flipVertical = true;
		}
	    }
	}
    }


    public AssetBundle spriteAssetBundle
    {
      get
	{
	  return m_spriteAssetBundle;
	}
      set
	{
	  m_spriteAssetBundle = value;
	  spriteAssetBundleUpdated = true;
	}
    }


    /// <summary>
    ///   Call when spriteName was changed.
    /// </summary>
    private void OnSpriteNameChange()
    {
      

      if( AssetCache.spritePrefabTable.ContainsKey(spriteName) )
	spritePrefab = AssetCache.spritePrefabTable[spriteName];
      else
	{
	  
	  // load new prefab
	  // delete old prefab and instance
	  // create new instance
	  string filepath = ResourceUtils.GetAbFilePath(spriteName);
	  ResourceLoader.Enqueue(filepath, this.OnSpritePrefabLoad, this.OnSpritePrefabLoadFailure);
	}
    }


    /// <summary>
    ///   Callback when spritePefab was loaded.
    /// </summary>
    private void OnSpritePrefabLoad(WWW www)
    {
      spriteAssetBundle = www.assetBundle;
    }

    private void OnSpritePrefabLoadFailure(WWW www)
    {
      Debug.Log("Fail to load sprite prefab assetbundle " + www.url);
    }

    private IEnumerator OnSpriteAssetBundleChange()
    {

      AssetBundleRequest request = spriteAssetBundle.LoadAsync( spriteName, typeof(TTSprite) );
      yield return request;
      
      spritePrefab = request.asset as TTSprite;
      if( !AssetCache.spritePrefabTable.ContainsKey(spritePrefab.name) )
	AssetCache.spritePrefabTable.Add(spritePrefab.name, spritePrefab);
    }

    /// <summary>
    ///   Call when spritePrefab was changed.
    /// </summary>
    private void OnSpritePrefabChange()
    {
      
      if( transform.childCount > 0 )
	{
	  // delete old sprite
	  foreach( Transform child in transform )
	    {
#if UNITY_EDITOR
	      DestroyImmediate( child.gameObject );
#else
	      Destroy( child.gameObject );
#endif
	    }
	}


      if( spritePrefab != null )
	{
	  // new instance
	  TTSprite spriteInstance = Instantiate( spritePrefab ) as TTSprite;

	  // become child of this layer
	  spriteInstance.transform.parent = transform;

	  spriteInstance.maxIndexChangeHandler += OnSpriteMaxIndexChange;
	  spriteInstance.flipHorizontal = flipHorizontal;
	  spriteInstance.flipVertical = flipVertical;

	  maxIndex = spriteInstance.maxIndex + frameDelay;

	  spriteInstance.maxIndexChangeHandler = OnSpriteMaxIndexChange;
	  
	  OnSpriteReady( spriteInstance );

	}
      else
	{
	  maxIndex = 0;
	}

      
    }

    private void OnSpriteMaxIndexChange(int spriteMaxIndex)
    {
      maxIndex = spriteMaxIndex + frameDelay;
    }

    private void OnSpriteReady(TTSprite sprite)
    {

      if( spriteReadyHandler != null )
	{
	  spriteReadyHandler( sprite );	  
	}


    }

    void Start()
    {
      transform.localPosition = Vector3.zero;
    }

    void Update()
    {
      if( spriteAssetBundleUpdated )
	{
	  spriteAssetBundleUpdated = false;
	  StartCoroutine( OnSpriteAssetBundleChange() );
	}
      else if( spritePrefabUpdated )
	{
	  spritePrefabUpdated = false;
	  OnSpritePrefabChange();
	}

    }

  }
}
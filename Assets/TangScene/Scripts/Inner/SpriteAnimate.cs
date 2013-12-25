using System;
using System.Collections.Generic;
using UnityEngine;

using Tang;

namespace TangScene
{
  [ExecuteInEditMode]
  public class SpriteAnimate : MonoBehaviour
  {

    /// <summary>
    ///   可视时回调
    /// </summary>
    public delegate void BecameVisible();
    public BecameVisible becameVisibleHandler;

    /// <summary>
    ///   不可视时回调
    /// </summary>
    public delegate void BecameInvisible();
    public BecameInvisible becameInvisibleHandler;

    /// <summary>
    ///   精灵资源准备好的回调
    /// </summary>
    public delegate void LateSpriteReady(TTSprite sprite);
    public LateSpriteReady lateSpriteReadyHandler;

    /// <summary>
    ///   播放到最后一帧的回调
    /// </summary>
    public delegate void LateLastFrame(SpriteAnimation spriteAnimation);
    public LateLastFrame lateLastFrameHandler;

    /// <summary>
    ///   当前帧改变
    /// </summary>
    public delegate void CurrentIndexChange(int index);
    public CurrentIndexChange currentIndexChange;

    /// <summary>
    ///   精灵动画 Prefab
    /// </summary>
    public SpriteAnimation spriteAnimationPrefab;

    /// <summary>
    ///   需要播放的精灵集合名字
    /// </summary>
    public string spriteSetName;
    
    
    /// <summary>
    /// 是否屏幕内可见
    /// </summary>
    public bool visible = false;
    
    
    private SpriteAnimation m_spriteAnimation;
    private Transform spriteAnimationTransform;
    private float fixedy;
    private CharacterStatusBhvr statusBhvr;
    private Directional directional;

    /// <summary>
    ///   获取精灵动画
    /// </summary>
    public SpriteAnimation spriteAnimation {
      get {
        return m_spriteAnimation;
      }
      set {
        m_spriteAnimation = value;
        m_spriteAnimation.spriteReadyHandler = OnSpriteReady;
        m_spriteAnimation.lastFrameHandler = OnLastFrame;
        m_spriteAnimation.transform.parent = transform;
      }
    }

    /// <summary>
    ///   修改高亮级别
    /// </summary>
    public void ChangeSpecularLevel(int level)
    {
      if (spriteAnimation != null) {
        List<TTSprite> spriteList = ComponentSelector.Filter<TTSprite>(spriteAnimation.transform);
        foreach (TTSprite sprite in spriteList) {
          sprite.ChangeSpecularLevel(level);
        }
      }
      
    }

    /// <summary>
    ///   还原到非高亮状态
    /// </summary>
    public void RevertSpecular()
    {
      if (spriteAnimation != null) {
        List<TTSprite> spriteList = ComponentSelector.Filter<TTSprite>(spriteAnimation.transform);
        foreach (TTSprite sprite in spriteList) {
          sprite.RevertSpecular();
        }
      }
      
    }


    /// <summary>
    ///   状态改变时的回调
    /// </summary>
    private void OnStatusChange(CharacterStatus status)
    {

      if (spriteAnimation != null) {

        spriteAnimation.Stop();

        List<MultiSetSprite> spriteList = ComponentSelector.Filter<MultiSetSprite>(spriteAnimation.transform);
        if (spriteList != null && spriteList.Count > 0) {
          foreach (MultiSetSprite sprite in spriteList) {
            int slashIndex = sprite.currentSetName.IndexOf("/");
            if (slashIndex > 0) {
              string postfix = sprite.currentSetName.Substring(slashIndex);
              sprite.currentSetName = status + postfix;
            }
          }
        }

        spriteAnimation.Play();
      }
    }

    /// <summary>
    ///   方向改变时的回调
    /// </summary>
    private void OnDirectionChange(EightDirection direction)
    {
      if (spriteAnimation != null) {
        foreach (Transform child in spriteAnimation.transform) {
          foreach (Transform grandchild in child) {
            MultiSetSprite sprite = grandchild.GetComponent<MultiSetSprite>();
            if (sprite != null)
              fixSprite(ref sprite, direction);
          }
        }
      }
    }


    /// <summary>
    ///   根据方向来修正精灵的显示，因为游戏使用的是八方向，而只有 0,4,5,6,7 五个方向的资源
    /// </summary>
    private void fixSprite(ref MultiSetSprite sprite, EightDirection direction)
    {
      EightDirection fixedDirection = direction;
      bool flipHorizontal = false;

      if (EightDirection.LD == direction) {
        fixedDirection = EightDirection.RD;
        flipHorizontal = true;
      } else if (EightDirection.L == direction) {
        fixedDirection = EightDirection.R;
        flipHorizontal = true;
      } else if (EightDirection.LT == direction) {
        fixedDirection = EightDirection.RT;
        flipHorizontal = true;
      }
  
      int slashIndex = sprite.currentSetName.LastIndexOf("/");
      if (slashIndex > 0) {
        string prefix = sprite.currentSetName.Substring(0, slashIndex + 1);       
        sprite.currentSetName = prefix + (int)fixedDirection;
        sprite.flipHorizontal = flipHorizontal;
      }

      
    }


    /// <summary>
    ///   精灵加载完成后的回调
    /// </summary>
    private void OnSpriteReady(TTSprite sprite)
    {
      sprite.becameVisibleHandler += OnBecameVisible;
      sprite.becameInvisibleHandler += OnBecameInvisible;

      if (sprite is MultiSetSprite && sprite != null) {
        MultiSetSprite mssprite = sprite as MultiSetSprite;
    
        if (!String.IsNullOrEmpty(spriteSetName))
          mssprite.currentSetName = spriteSetName;
        else {
          if (statusBhvr != null) {
            int slashIndex = mssprite.currentSetName.IndexOf("/");
            if (slashIndex > 0) {
              string postfix = mssprite.currentSetName.Substring(slashIndex);
              mssprite.currentSetName = statusBhvr.Status + postfix;
            }
          }

          if (directional != null) {
            fixSprite(ref mssprite, directional.Direction);
          }
        
        }
      }

      if (lateSpriteReadyHandler != null)
        lateSpriteReadyHandler(sprite);

    }

    /// <summary>
    ///   动画播放到最后一帧的回调
    /// </summary>
    void OnLastFrame(SpriteAnimation spriteAnimation)
    {
      if (lateLastFrameHandler != null)
        lateLastFrameHandler(spriteAnimation);
    }

    void OnCurrentIndexChange(int index)
    {
      if( currentIndexChange != null )
	currentIndexChange( spriteAnimation.currentIndex );
    }



#region mono

    void Start()
    {

      // sprite animation

      if (spriteAnimationPrefab != null) {
        if (transform.childCount > 0)
          GameObjectUtils.DestroyChildren(transform);

        spriteAnimation = Instantiate(spriteAnimationPrefab) as SpriteAnimation;
        if (spriteAnimation != null) {
          spriteAnimationTransform = spriteAnimation.transform;
          spriteAnimationTransform.parent = transform;
          spriteAnimationTransform.localPosition = Vector3.zero;
        }
      }


      if (transform.childCount > 0) {
        // for each animation
        foreach (Transform child in transform) {
          spriteAnimation = child.GetComponent<SpriteAnimation>();
          if (spriteAnimation != null) {
            spriteAnimationTransform = child;
            spriteAnimation.spriteReadyHandler += OnSpriteReady;
            spriteAnimation.lastFrameHandler += OnLastFrame;
	    spriteAnimation.currentIndexChange += OnCurrentIndexChange;
          }
        }
      }
      
      // status bhvr

      statusBhvr = GetComponent<CharacterStatusBhvr>();
      if (statusBhvr != null) {
        OnStatusChange(statusBhvr.Status);
        statusBhvr.statusStartHandler += OnStatusChange;
    
      }


      // directional
      directional = GetComponent<Directional>();
      if (directional != null) {
        OnDirectionChange(directional.Direction);
        directional.directionChangeHandler += OnDirectionChange;
      }
      
    }

    void FixedUpdate()
    {
      if (spriteAnimationTransform != null) {
    
        fixedy = - transform.localPosition.z;
        spriteAnimationTransform.transform.localPosition = new Vector3(0F, fixedy, 0F);
      }
    
    }

    /// <summary>
    ///   由不可视变成可视
    /// </summary>
    void OnBecameVisible()
    {
      if( !visible )
        visible = true;
      
      if (becameVisibleHandler != null)
        becameVisibleHandler();
    }

    /// <summary>
    ///   由不可视变成可视
    /// </summary>
    void OnBecameInvisible()
    {
      if( visible )
        visible = false;
      
      if (becameInvisibleHandler != null)
        becameInvisibleHandler();
    }


#endregion


    /// <summary>
    ///   显示成半透明状态
    /// </summary>
    void OnBecameHalfTransparent()
    {
      if (spriteAnimation != null) {
        List<TTSprite> spriteList = ComponentSelector.Filter<TTSprite>(spriteAnimation.transform);
        foreach (TTSprite sprite in spriteList) {
          sprite.OnBecameHalfTransparent();
        }
      }
    }


    /// <summary>
    ///   还原真实（取消半透明状态）
    /// </summary>
    void OnBecameReal()
    {
      if (spriteAnimation != null) {
        List<TTSprite> spriteList = ComponentSelector.Filter<TTSprite>(spriteAnimation.transform);
        foreach (TTSprite sprite in spriteList) {
          sprite.OnBecameReal();
        }
    
      }
    }

  }
}
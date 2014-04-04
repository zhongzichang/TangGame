/**
 * UI Panel Manager
 * Author: zzc
 * Date: 2014/4/3
 */

using UnityEngine;
using System;
using TangGame;
using TS = TangScene;

namespace TangUI
{
  public class UIPanelNode
  {

    private UIPanelNodeContext m_context;

    /// <summary>
    ///   Node Name
    /// </summary>
    public string name;

    /// <summary>
    ///   Previous Node
    /// </summary>
    public UIPanelNode preNode;

    /// <summary>
    ///   Next Node
    /// </summary>
    public UIPanelNode nextNode;

    /// <summary>
    ///   GameObject
    /// </summary>
    public GameObject gameObject;

    /// <summary>
    ///   Replace
    /// </summary>
    public bool replace = false;

    /// <summary>
    ///   Body
    /// </summary>
    public object body;

    /// <summary>
    ///   Context
    /// </summary>
    public UIPanelNodeContext context
    {
      get
	{
	  return m_context;
	}
      set
	{
	  this.m_context = value;
	  this.preNode = m_context.currentNode;
	}
    }

    
    
    public UIPanelNode()
    {
      
    }

    public UIPanelNode(string name)
    {
      this.name = name;
    }

    /// <summary>
    ///   Launch
    /// </summary>
    public void Launch(bool replace, object body)
    {

      this.replace = replace;
      this.body = body;

      gameObject = context.cache.GetInactiveGobj(name);
      if( null == gameObject )
	StartLoadRes();
      else
	Show();

    }


    public void SetActive(bool active)
    {
      NGUITools.SetActive(gameObject, active);
    }

    private void StartLoadRes()
    {
      if (Config.debug)
	LoadResComplete(null);
      else
	{
	  string path = Tang.ResourceUtils.GetAbFilePath( name );
	  TS.TS.LoadAssetBundle(path, LoadResComplete);			
	}
    }

    private void LoadResComplete(WWW www)
    {	
      UnityEngine.Object assets = null;
      if (www == null)
	assets = Resources.Load(GameConsts.PREFABS_PATH + name);
      else
	assets = www.assetBundle.Load(name);
      gameObject = GameObject.Instantiate(assets) as GameObject;

      if( gameObject != null )
	{
	  gameObject.name = name;
	  context.cache.Put(name, gameObject);
	  Show();	  
	}

    }

    private void Show()
    {

      // hide previous node
      if( replace && !(preNode is UIPanelRoot ))
	{
	  preNode.Hide();
	}

      // init current node
      preNode = context.currentNode;
      if( preNode.nextNode == null )
	{
	  preNode.nextNode = this;

	  context.currentNode = this;
	  context.depth++;

	  Transform transform = gameObject.transform;
	  transform.parent = context.anchor.transform;
	  transform.localPosition = Vector3.zero;
	  transform.localRotation = Quaternion.identity;
	  transform.localScale = Vector3.one;
	  UIPanel panel = gameObject.GetComponent<UIPanel>();
	  if( null != panel )
	    panel.depth = context.depth;

	  if( !gameObject.activeSelf )
	    NGUITools.SetActive(gameObject, true);

	}
      else
	{
	  throw new Exception("Can not attach to previous node.");
	}
    }

    public void Hide()
    {
      if( !(this is UIPanelRoot ))
	{
	    
	  SetActive(false);
	  preNode.nextNode = null;

	  context.currentNode = preNode;
	  context.depth--;

	}
    }

  }
}
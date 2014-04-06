/**
 * UI Panel Node Manager
 * Author: zzc
 * Date: 2014/4/3
 */
using UnityEngine;

namespace TangUI
{
  public class UIPanelNodeManager
  {

    private UIPanelNodeContext context;

    public UIPanelNodeManager(UIAnchor anchor)
    {

      UIPanelNode root = new UIPanelRoot();
      root.gameObject = anchor.gameObject;

      this.context = new UIPanelNodeContext();
      this.context.currentNode = root;
      this.context.cache = new UIPanelCache();
      this.context.anchor = anchor;
    }

    public void LazyOpen(string name)
    {
      LazyOpen(name, UIPanelNode.OpenMode.ADDITIVE, null);
    }

    public void LazyOpen(string name, UIPanelNode.OpenMode openMode)
    {
      LazyOpen(name, openMode, null);
    }

    public void LazyOpen(string name, UIPanelNode.OpenMode openMode, object param)
    {
      if( !name.Equals( context.currentNode.name ) )
	{
	  UIPanelNode node = new UIPanelNode(name);
	  node.context = context;
	  node.Launch( openMode,  param);
	}
      
    }


    public void Back()
    {
      if( !(context.currentNode is UIPanelRoot) )
	{
	  context.currentNode.Remove();

	  
	}
    }
    
  }
}

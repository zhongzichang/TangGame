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
      LazyOpen(name, false, null);
    }

    public void LazyOpen(string name, bool replace)
    {
      LazyOpen(name, replace, null);
    }

    public void LazyOpen(string name, bool replace, object param)
    {
      if( !name.Equals( context.currentNode.name ) )
	{
	  UIPanelNode node = new UIPanelNode(name);
	  node.context = context;
	  node.Launch( replace, param);
	}
      
    }


    public void Back()
    {
      if( !(context.currentNode is UIPanelRoot) )
	{
	  context.currentNode.Hide();
	}
    }
    
  }
}

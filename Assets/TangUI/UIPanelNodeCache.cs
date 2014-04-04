/// <summary>
///   UI Panel Node Cache
/// Author: zzc
/// Date: 2014/4/3
/// </summary>

using System.Collections.Generic;

namespace TangUI
{
  public class UIPanelNodeCache
  {
    public Dictionary<string, List<UIPanelNode>>
    table = new Dictionary<string, List<UIPanelNode>>();

    public UIPanelNodeCache()
    {
      
    }

    public UIPanelNode GetInactiveOne(string name)
    {
      if( table.ContainsKey(name) )
	{
	  foreach(UIPanelNode panelNode in table[name])
	    {
	      if( !panelNode.gameObject.activeSelf )
		return panelNode;
	    }
	}
      return null;
    }

    // add node
    public void Add(string name, UIPanelNode node)
    {
      if( table.ContainsKey(name) )
	{
	  table[name].Add(node);
	}
      else
	{
	  List<UIPanelNode> list = new List<UIPanelNode>();
	  list.Add(node);
	  table.Add(name, list);
	}
    }


  }
}
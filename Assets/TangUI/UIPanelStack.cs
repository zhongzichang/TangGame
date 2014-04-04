/**
 * UI Panel Manager
 * Author: zzc
 * Date: 2014/4/3
 */

namespace TangUI
{
		public class UIPanelStack
		{

				private UIPanelNode currentNode;

				public void push (UIPanelNode node)
				{
						node.preNode = currentNode;
						currentNode = node;
				}
    
				public UIPanelNode pop ()
				{
      
						return currentNode;
				}
		}
}
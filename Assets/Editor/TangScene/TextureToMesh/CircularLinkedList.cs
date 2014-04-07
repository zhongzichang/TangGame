#if UNITY_EDITOR
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;

namespace TangScene {

	/// <summary>
	/// Represents a circular doubly linked list.
	/// </summary>
	/// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
	public sealed class CircularLinkedList<T> : ICollection<T>, IEnumerable<T>
	{
		private CircularLinkedListNode<T> m_rFirstNode = null;
		
		private CircularLinkedListNode<T> m_rLastNode = null;
		
		int m_iCountNode = 0;
		
		readonly IEqualityComparer<T> m_rComparer;
		
		/// <summary>
		/// Initializes a new instance of <see cref="CircularLinkedList"/>
		/// </summary>
		public CircularLinkedList( )
		    : this(null, EqualityComparer<T>.Default)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of <see cref="CircularLinkedList"/>
		/// </summary>
		/// <param name="collection">Collection of objects that will be added to linked list</param>
		public CircularLinkedList(IEnumerable<T> collection)
		    : this(collection, EqualityComparer<T>.Default)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of <see cref="CircularLinkedList"/>
		/// </summary>
		/// <param name="a_rComparer">Comparer used for item comparison</param>
		/// <exception cref="ArgumentNullException">comparer is null</exception>
		public CircularLinkedList(IEqualityComparer<T> a_rComparer)
		    : this(null, a_rComparer)
		{
		}
		
		/// <summary>
		/// Initializes a new instance of <see cref="CircularLinkedList"/>
		/// </summary>
		/// <param name="a_rCollection">Collection of objects that will be added to linked list</param>
		/// <param name="a_rComparer">Comparer used for item comparison</param>
		public CircularLinkedList(IEnumerable<T> a_rCollection, IEqualityComparer<T> a_rComparer)
		{
		    if (a_rComparer == null)
		        throw new ArgumentNullException("comparer");
		    this.m_rComparer = a_rComparer;
		    if (a_rCollection != null)
		    {
		        foreach (T item in a_rCollection)
		            this.AddLast(item);
		    }
		}
		
		/// <summary>
		/// Gets Tail node. Returns NULL if no tail node found
		/// </summary>
		public CircularLinkedListNode<T> Last { get { return m_rLastNode; } }
		
		/// <summary>
		/// Gets the head node. Returns NULL if no node found
		/// </summary>
		public CircularLinkedListNode<T> First { get { return m_rFirstNode; } }
		
		/// <summary>
		/// Gets total number of items in the list
		/// </summary>
		public int Count { get { return m_iCountNode; } }
		
		/// <summary>
		/// Gets the item at the current index
		/// </summary>
		/// <param name="a_iIndex">Zero-based index</param>
		/// <exception cref="ArgumentOutOfRangeException">index is out of range</exception>
		public CircularLinkedListNode<T> this[int a_iIndex ]
		{
		    get
		    {
		        if (a_iIndex >= m_iCountNode || a_iIndex < 0)
		            throw new ArgumentOutOfRangeException("index");
		        else
		        {
		            CircularLinkedListNode<T> rNode = this.m_rFirstNode;
		            for (int i = 0; i < a_iIndex; i++)
		                rNode = rNode.Next;
		            return rNode;
		        }
		    }
		}
		
		/// <summary>
		/// Add a new item to the end of the list
		/// </summary>
		/// <param name="a_rItem">Item to be added</param>
		public void AddLast(T a_rItem)
		{
		    // if head is null, then this will be the first item
		    if (m_rFirstNode == null)
		        this.AddFirstItem(a_rItem);
		    else
		    {
		        CircularLinkedListNode<T> oNewNode = new CircularLinkedListNode<T>(a_rItem);
		        m_rLastNode.Next = oNewNode;
		        oNewNode.Next = m_rFirstNode;
		        oNewNode.Previous = m_rLastNode;
		        m_rLastNode = oNewNode;
		        m_rFirstNode.Previous = m_rLastNode;
		    }
		    ++m_iCountNode;
		}
		
		void AddFirstItem(T a_rItem)
		{
		    m_rFirstNode = new CircularLinkedListNode<T>(a_rItem);
		    m_rLastNode = m_rFirstNode;
		    m_rFirstNode.Next = m_rLastNode;
		    m_rFirstNode.Previous = m_rLastNode;
		}
		
		/// <summary>
		/// Adds item to the last
		/// </summary>
		/// <param name="a_rItem">Item to be added</param>
		public void AddFirst(T a_rItem)
		{
		    if (m_rFirstNode == null)
		        this.AddFirstItem(a_rItem);
		    else
		    {
		        CircularLinkedListNode<T> oNewNode = new CircularLinkedListNode<T>(a_rItem);
		        m_rFirstNode.Previous = oNewNode;
		        oNewNode.Previous = m_rLastNode;
		        oNewNode.Next = m_rFirstNode;
		        m_rLastNode.Next = oNewNode;
		        m_rFirstNode = oNewNode;
		    }
		    ++m_iCountNode;
		}
		
		/// <summary>
		/// Adds the specified item after the specified existing node in the list.
		/// </summary>
		/// <param name="a_rNode">Existing node after which new item will be inserted</param>
		/// <param name="a_rItem">New item to be inserted</param>
		/// <exception cref="ArgumentNullException"><paramref name="a_rNode"/> is NULL</exception>
		/// <exception cref="InvalidOperationException"><paramref name="node"/> doesn't belongs to list</exception>
		public void AddAfter(CircularLinkedListNode<T> a_rNode, T a_rItem)
		{
		    if (a_rNode == null)
		        throw new ArgumentNullException("node");
		    // ensuring the supplied node belongs to this list
		    bool bNodeBelongsToList = this.FindNode( a_rNode );
		    if ( bNodeBelongsToList == false )
		        throw new InvalidOperationException("Node doesn't belongs to this list");
		
		    CircularLinkedListNode<T> oNewNode = new CircularLinkedListNode<T>(a_rItem);
		    oNewNode.Next = a_rNode.Next;
		    a_rNode.Next.Previous = oNewNode;
		    oNewNode.Previous = a_rNode;
		    a_rNode.Next = oNewNode;
		
		    // if the node adding is tail node, then repointing tail node
		    if (a_rNode == m_rLastNode)
		        m_rLastNode = oNewNode;
		    ++m_iCountNode;
		}
		
		/// <summary>
		/// Adds the new item after the specified existing item in the list.
		/// </summary>
		/// <param name="a_rExistingItem">Existing item after which new item will be added</param>
		/// <param name="a_rNewItem">New item to be added to the list</param>
		/// <exception cref="ArgumentException"><paramref name="existingItem"/> doesn't exist in the list</exception>
		public void AddAfter(T a_rExistingItem, T a_rNewItem)
		{
		    // finding a node for the existing item
		    CircularLinkedListNode<T> rNode = this.Find(a_rExistingItem);
		    if (rNode == null)
		        throw new ArgumentException("existingItem doesn't exist in the list");
		    this.AddAfter(rNode, a_rNewItem);
		}
		
		/// <summary>
		/// Adds the specified item before the specified existing node in the list.
		/// </summary>
		/// <param name="a_rNode">Existing node before which new item will be inserted</param>
		/// <param name="a_rItem">New item to be inserted</param>
		/// <exception cref="ArgumentNullException"><paramref name="a_rNode"/> is NULL</exception>
		/// <exception cref="InvalidOperationException"><paramref name="node"/> doesn't belongs to list</exception>
		public void AddBefore(CircularLinkedListNode<T> a_rNode, T a_rItem)
		{
		    if (a_rNode == null)
		        throw new ArgumentNullException("node");
		    // ensuring the supplied node belongs to this list
		    bool bNodeBelongsToList = this.FindNode( a_rNode );
		    if ( bNodeBelongsToList == false )
		        throw new InvalidOperationException("Node doesn't belongs to this list");
		
		    CircularLinkedListNode<T> oNewNode = new CircularLinkedListNode<T>(a_rItem);
		    a_rNode.Previous.Next = oNewNode;
		    oNewNode.Previous = a_rNode.Previous;
		    oNewNode.Next = a_rNode;
		    a_rNode.Previous = oNewNode;
		
		    // if the node adding is head node, then repointing head node
		    if (a_rNode == m_rFirstNode)
		        m_rFirstNode = oNewNode;
		    ++m_iCountNode;
		}
		
		/// <summary>
		/// Adds the new item before the specified existing item in the list.
		/// </summary>
		/// <param name="a_rExistingItem">Existing item before which new item will be added</param>
		/// <param name="a_rNewItem">New item to be added to the list</param>
		/// <exception cref="ArgumentException"><paramref name="existingItem"/> doesn't exist in the list</exception>
		public void AddBefore(T a_rExistingItem, T a_rNewItem)
		{
		    // finding a node for the existing item
		    CircularLinkedListNode<T> rNode = this.Find(a_rExistingItem);
		    if (rNode == null)
		        throw new ArgumentException("existingItem doesn't exist in the list");
		    this.AddBefore(rNode, a_rNewItem);
		}
		
		/// <summary>
		/// Finds the supplied item and returns the first node which contains item. Returns NULL if item not found
		/// </summary>
		/// <param name="a_rItem">Item to search</param>
		/// <returns><see cref="CircularLinkedListNode&lt;T&gt;"/> instance or NULL</returns>
		public CircularLinkedListNode<T> Find(T a_rItem)
		{
		    CircularLinkedListNode<T> rNode = FindFirstNodeWithValue(m_rFirstNode, a_rItem);
		    return rNode;
		}
		
		/// <summary>
		/// Removes the first occurance of the supplied item
		/// </summary>
		/// <param name="a_rItem">Item to be removed</param>
		/// <returns>TRUE if removed, else FALSE</returns>
		public bool Remove(T a_rItem)
		{
		    // finding the first occurance of this item
		    CircularLinkedListNode<T> rNodeToRemove = this.Find(a_rItem);
		    if (rNodeToRemove != null)
				return this.RemoveNode(rNodeToRemove);
	
			return false;
		}
		
		bool RemoveNode(CircularLinkedListNode<T> a_rNodeToRemove)
		{
		    CircularLinkedListNode<T> rPreviousNode = a_rNodeToRemove.Previous;
		    rPreviousNode.Next = a_rNodeToRemove.Next;
		    a_rNodeToRemove.Next.Previous = a_rNodeToRemove.Previous;
		
		    // if this is head, we need to update the head reference
		    if (m_rFirstNode == a_rNodeToRemove)
		        m_rFirstNode = a_rNodeToRemove.Next;
		    else if (m_rLastNode == a_rNodeToRemove)
		        m_rLastNode = m_rLastNode.Previous;
		
		    --m_iCountNode;
		    return true;
		}
		
		/// <summary>
		/// Removes all occurances of the supplied item
		/// </summary>
		/// <param name="a_rItem">Item to be removed</param>
		public void RemoveAll(T a_rItem)
		{
		    bool bRemoved = false;
		    do
		    {
		        bRemoved = this.Remove(a_rItem);
		    } while (bRemoved);
		}
		
		/// <summary>
		/// Clears the list
		/// </summary>
		public void Clear()
		{
		    m_rFirstNode = null;
		    m_rLastNode = null;
		    m_iCountNode = 0;
		}
		
		/// <summary>
		/// Removes head
		/// </summary>
		/// <returns>TRUE if successfully removed, else FALSE</returns>
		public bool RemoveFirst()
		{
		    return this.RemoveNode(m_rFirstNode);
		}
		
		/// <summary>
		/// Removes tail
		/// </summary>
		/// <returns>TRUE if successfully removed, else FALSE</returns>
		public bool RemoveLast()
		{
		    return this.RemoveNode(m_rLastNode);
		}
	
		bool FindNode( CircularLinkedListNode<T> a_rNode )
		{
			CircularLinkedListNode<T> rNode = m_rFirstNode;
			do
			{
				if( rNode == a_rNode )
				{
					return true;
				}
	
				rNode = rNode.Next;
			}
			while( rNode != m_rFirstNode );
			return false;
		}
		
		CircularLinkedListNode<T> FindFirstNodeWithValue( CircularLinkedListNode<T> a_rNode, T a_rValueToCompare)
		{
		    CircularLinkedListNode<T> rResult = null;
		    if (m_rComparer.Equals(a_rNode.Value, a_rValueToCompare))
		        rResult = a_rNode;
		    else if (rResult == null && a_rNode.Next != m_rFirstNode)
		        rResult = FindFirstNodeWithValue(a_rNode.Next, a_rValueToCompare);
		    return rResult;
		}
		
		/// <summary>
		/// Gets a forward enumerator
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator()
		{
		    CircularLinkedListNode<T> rCurrent = m_rFirstNode;
		    if (rCurrent != null)
		    {
		        do
		        {
		            yield return rCurrent.Value;
		            rCurrent = rCurrent.Next;
		        } while (rCurrent != m_rFirstNode);
		    }
		}
		
		/// <summary>
		/// Gets a reverse enumerator
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetReverseEnumerator()
		{
		    CircularLinkedListNode<T> rCurrent = m_rLastNode;
		    if (rCurrent != null)
		    {
		        do
		        {
		            yield return rCurrent.Value;
		            rCurrent = rCurrent.Previous;
		        } while (rCurrent != m_rLastNode);
		    }
		}
		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
		    return GetEnumerator();
		}
		
		/// <summary>
		/// Determines whether a value is in the list.
		/// </summary>
		/// <param name="a_rItem">Item to check</param>
		/// <returns>TRUE if item exist, else FALSE</returns>
		public bool Contains(T a_rItem)
		{
		    return Find(a_rItem) != null;
		}
		
		public void CopyTo(T[] a_rArray, int a_iArrayIndex)
		{
		    if (a_rArray == null)
		        throw new ArgumentNullException("array");
		    if (a_iArrayIndex < 0 || a_iArrayIndex > a_rArray.Length)
		        throw new ArgumentOutOfRangeException("arrayIndex");
		
		    CircularLinkedListNode<T> rNode = this.m_rFirstNode;
		    do
		    {
		        a_rArray[a_iArrayIndex++] = rNode.Value;
		        rNode = rNode.Next;
		    } while (rNode != m_rFirstNode);
		}
		
		bool ICollection<T>.IsReadOnly
		{
			get { return false; }
		}
		
		void ICollection<T>.Add(T a_rItem)
		{
			this.AddLast(a_rItem);
		}
	}
}
#endif
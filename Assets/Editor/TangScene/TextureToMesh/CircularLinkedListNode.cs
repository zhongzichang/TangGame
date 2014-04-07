#if UNITY_EDITOR

namespace TangScene {

	/// <summary>
	/// Represents a node
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public sealed class CircularLinkedListNode<T>
	{
	    /// <summary>
	    /// Gets the Value
	    /// </summary>
	    public T Value { get; private set; }
	
	    /// <summary>
	    /// Gets next node
	    /// </summary>
	    public CircularLinkedListNode<T> Next { get; internal set; }
	
	    /// <summary>
	    /// Gets previous node
	    /// </summary>
	    public CircularLinkedListNode<T> Previous { get; internal set; }
	
	    /// <summary>
	    /// Initializes a new <see cref="CircularLinkedListNode"/> instance
	    /// </summary>
	    /// <param name="a_rItem">Value to be assigned</param>
	    internal CircularLinkedListNode(T a_rItem)
	    {
	        this.Value = a_rItem;
	    }
	}
}
#endif
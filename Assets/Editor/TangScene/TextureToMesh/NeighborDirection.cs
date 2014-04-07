using System;

namespace TangScene
{
	// Enum used to select a neighbor node/pixel
	public enum NeighborDirection
	{
		DirectionRight, // 0
		DirectionUpRight, // 1
		DirectionUp, // 2
		DirectionUpLeft, // 3
		DirectionLeft, // 4
		DirectionDownLeft, // 5
		DirectionDown, // 6
		DirectionDownRight // 7
	}
}


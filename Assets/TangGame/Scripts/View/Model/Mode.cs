using System;

namespace TangGame.View
{
	
	public class Mode
	{
		public enum Type {NORMAL, TRAVEL, BATTLE, CLUB, TEAM}
		
		private Type type = Type.NORMAL;
				
		private bool updated = false;
		
		public Mode (Type type)
		{
			this.type = type;
			this.updated = false;
		}
		
		public Type getType(){
			return type;
		}
		
		public bool isUpdated(){
			return updated;
		}
		
		public void To(Type type) {
			this.type = type;
			this.updated = true;
		}
		
	}
}


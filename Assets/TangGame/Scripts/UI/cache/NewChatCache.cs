using UnityEngine;
using System.Collections;
using TangGame.View;
using System.Text.RegularExpressions;
namespace nh.ui.cache{

	public class NewChatCache{
		public static short currentChannel = 0;
		
		public static short[] index = new short[]{ChatVo.WORLD,ChatVo.PROPS,ChatVo.WORLD,ChatVo.SECRET,ChatVo.CLAN,ChatVo.TEAM,ChatVo.WORLD};
		public static Color[] channelColor = new Color[]{ColorUtil.CYAN,ColorUtil.ORANGE,ColorUtil.YELLOW,
			ColorUtil.PURPLE,ColorUtil.GREEN,ColorUtil.BLUE,ColorUtil.RED};
		public static Color[] buttonTextColor = new Color[]{ColorUtil.YELLOW,ColorUtil.ORANGE,ColorUtil.YELLOW,
			ColorUtil.PURPLE,ColorUtil.GREEN,ColorUtil.BLUE,ColorUtil.YELLOW};
		
		public static Queue chatQueue = new Queue();
		public static int update = 0;
		
		public static Queue chatAllQueue = new Queue();
		public static int updateAll = 0;
		public static Queue chatHaojiaoQueue = new Queue();
		public static int updateHaojiao = 0;
		public static Queue chatWorldQueue = new Queue();
		public static int updateWorld = 0;
		public static Queue chatSecretQueue = new Queue();
		public static int updateSecret = 0;
		public static Queue chatLeagueQueue = new Queue();
		public static int updateLeague = 0;
		public static Queue chatTeamQueue = new Queue();
		public static int updateTeam = 0;
		public static Queue chatSystemQueue = new Queue();
		public static int updateSystem = 0;
		
		public static string[] faces = null;
		public static UIAtlas faceAtlas = null;
		
		public static Regex faceRegex = new Regex(@"\&\w+\&");
		public static int faceNum = 0;
		public static Regex linkRegex = new Regex(@"\[link\].+\[link\]");
		
		public static void Add(ChatVo chat){
			chatQueue.Enqueue (chat);
			update ++;
		}
	}
}
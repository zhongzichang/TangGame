using UnityEngine;
using System.Collections;

public class GameUtils
{
  /// <summary>
  /// 获取第二个点相对于第一个点的方向
  /// </summary>
  /// <param name="position1">第一个点</param>
  /// <param name="position2">第二个点</param>
  /// <returns></returns>
  public static Vector3 GetDirection (Vector3 position1, Vector3 position2)
  {
    Vector3 heading = position2 - position1;
    float distance = heading.magnitude;
    return heading / distance;
  }
  /// <summary>
  /// Servers to client speed. Pixel/s
  /// </summary>
  /// <returns>
  /// The to client speed.
  /// </returns>
  /// <param name='speed'>
  /// Speed.
  /// </param>
  public static float ServerToClientSpeed (float speed)
  {
    float rate = 24;
    return speed * rate;
  }
  
  
  #region ==================任务相关工具==================
  ///类型字符串
  private static string typeStr = "1:[主],303:[支],2:[日],305:[世],306:[家],309:[奖],5:[赏],311:[缉],313:[隐],4:[伐],315:[阵],316:[帮会],317:[镖],3:[环]";
  ///类型集合
  private static Hashtable typeTable;
  ///条件前缀文字
  private static string trackStr = "111:到达地图,201:击杀,401:收集,501:寻找,502:护送,601:学习技能,701:使用技能,702:技能升级,703:拖动技能,704:使用物品,705:使用物品,706:强化装备,707:强化装备,708:镶嵌宝石,709:提升装备品质,710:提升装备等级,711:合成宝石,712:装备打孔,713:装备附魔,714:升级经脉,715:升级穴位,716:修改模式,717:死亡,718:玩家等级需达到{0}级,719:拥有铜币,720:vip等级,721:亲密度,722:加入帮会,723:组队次数,724:杀戮值,725:物品寄售次数,726:物品竞拍次数,727:竞选人,728:成为领袖,729:投票次数,730:杀死玩家数量,731:好友数量,732:频道聊天,733:摆摊次数,734:购买摆摊物品次数,735:完成任务数量,736:通缉任务数量,737:挂机次数,739:播放动画,751:提升坐骑品质,750:强化物品,752:提升坐骑品质到指定等级,754:在道具商城购买指定道具,755:重铸装备";
  ///条件集合
  private static Hashtable trackTable;
    
    
    
    
  //是否为大量经验
  public static bool IsMoreExp (int level, int exp)
  {
    return (exp > level * 600 * 1.2f);
  }
  //是否为大量金钱
  public static bool IsMoreCopper (int level, int coin)
  {
    return (coin > level * 45 * 1.5f);
  }
    
  /// 任务替换
  public static string TaskReplace (string str)
  {
    string result = str;
    result = result.Replace ("#9%", "[00ff00]$");
    result = result.Replace ("#A%", "[00ff00]$");
    result = result.Replace ("#G%", "$");
      
    result = result.Replace ("#B%", '\n' + "");
    result = result.Replace ("#C%", "[-]");
    result = result.Replace ("#E%", "[-]");
      
    result = result.Replace ("#F%", "[ffff00]$");
    result = result.Replace ("#I%", "");
    result = result.Replace ("#T%", "[00ffff]");
    result = result.Replace ("#U%", "[00ffff]");
    result = result.Replace ("#H%", "");
      
    //      var pattern:RegExp = /[\#]+/g;//g是非常重要的，如果发现字符串中有#则继续替换，下一次查找将从上一个位置继续查找
    //      while(pattern.test(str))
    //      {
    //        str = str.replace("#9%", "<font color='#00ff00'><a href='event:1;");
    //        str = str.replace("#A%", "<font color='#00ff00'><a href='event:2;");
    //        str = str.replace("#G%", "'>");
    //  
    //        str = str.replace("#B%","<br>");
    //        str = str.replace("#C%","</font>");
    //        str = str.replace("#E%", "</a></font>");
    //        
    //        str = str.replace("#F%", "<font color='#ffff00'><a href='event:5;" + task.id + ",");//任务的
    //        str = str.replace("#I%", "<img src='" + NameSpace.getUrlPaths("icon/fly_shoes.png") + "' border='0'/>");//任务的
    //        str = str.replace("#T%", "<font color='#00ffff'>");//一种颜色，任务用的。颜色代码是根据任务需求变动
    //        str = str.replace("#U%", "<font color='#00ffff'>");//任务字体颜色
    //        str = str.replace("#H%", "<font color='#");//#H%ff0000#G%神一样的人物出现了！#C%
    //      }
    //      return str;
    string[] temp = result.Split ('$');//临时这样处理，以后修改再调整
    result = "";
    for (int i = 0; i < temp.Length; i++) {
      if ((i % 2) == 1) {
        continue;
      }
      result += temp [i];
    }
    return result;
  }
    
  /// 获得任务的类型
  public static string GetTaskType (TangGame.Xml.Task task)
  {
    if (typeTable == null) {
      typeTable = new Hashtable ();
      string[] types = typeStr.Split (',');
      foreach (string str in types) {
        if (string.IsNullOrEmpty (str)) {
          continue;
        }
        string[] strArr = str.Split (':');
        typeTable [strArr [0]] = strArr [1];
      }
    }
    string result = "";
    string key = task.Task_type.ToString ();
    result = typeTable [key] as string;
    if (result == null) {
      result = "";
    }
    return result;
  }
    

  ///检查处理条件前缀
  private static void CheckTaskCondition ()
  {
    if (trackTable == null) {
      trackTable = new Hashtable ();
      string[] types = trackStr.Split (',');
      foreach (string str in types) {
        if (string.IsNullOrEmpty (str)) {
          continue;
        }
        string[] strArr = str.Split (':');
        trackTable [strArr [0]] = strArr [1];
      }
    }
  }
  //转换颜色
  public static string ReplaceColor(string str){
    //黄色
    str = str.Replace("#Y","ffee00");
    //白色
    str = str.Replace("#W","ffe9eb");
    //绿色
    str = str.Replace("#G","00d400");
    //蓝色
    str = str.Replace("#B","0000d4");
    //红色
    str = str.Replace("#R","bf0000");
    //橘红色
    str = str.Replace("#O","d46300");
    //粉色
    str = str.Replace("#P","e900ca");
    //紫色
    str = str.Replace("#Z","21002a");
    return str;
  }
    

  #endregion
}

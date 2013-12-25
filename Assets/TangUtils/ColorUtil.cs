using UnityEngine;
using System.Collections;

public class ColorUtil
{
    /// 0.8 alpha 黑色
    public static Color BLACK=new Color(0f,0f,0f,0.8f);
    /// 黄色
    public static Color YELLOW = new Color(1.0f, 1.0f, 0.0f, 1.0f);
    /// 白色
    public static Color WHITE = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    /// 灰色
    public static Color GRAY = new Color(0.5f, 0.5f, 0.5f, 1.0f);
    /// 蓝色
    public static Color BLUE = new Color(0f, 0f, 1f, 1f);
    /// 绿色
    public static Color GREEN = new Color(0f, 1f, 0f, 1f);
    /// 橙色
    public static Color ORANGE = new Color(1f, 0.38f, 0f, 1f);
    /// 红色
    public static Color RED = new Color(1f, 0f, 0f, 1f);
    /// 紫色
    public static Color PURPLE = new Color(1f, 0f, 1f, 1f);
    /// 暗绿色
    public static Color DARK_GREEN = new Color(0.431f, 0.824f, 0.255f, 1f);
    /// 暗黄色
    public static Color DARK_TELLOW = new Color(0.949f, 0.867f, 0.518f, 1f);
    /// 暗蓝色
    public static Color DARK_BLUE = new Color(0f, 0.478f, 0.922f, 1f);
	
	public static Color CYAN = new Color(0f,1f,1f);

    /// 黑色
    public static string BLACK_HEX = "000000";
    /// 黄色
    public static string YELLOW_HEX = "FFFF00";
    /// 白色
    public static string WHITE_HEX = "FFFFFF";
    /// 灰色
    public static string GRAY_HEX = "0F0F0F";
    /// 蓝色
    public static string BLUE_HEX = "0000FF";
    /// 绿色
    public static string GREEN_HEX = "00FF00";
    /// 橙色
    public static string ORANGE_HEX = "FF9A00";
    /// 红色
    public static string RED_HEX = "FF0000";
    /// 紫色
    public static string PURPLE_HEX = "FF00FF";
    /// 暗蓝色
    public static string DARK_BLUE_HEX = "0079EB";
	
	public static string CYAN_HEX = "00FFFF";

    //=====================游戏使用颜色=====================
    /// 游戏使用的默认字体颜色
    public static Color NORMAL = new Color(0.255f, 0.824f, 0.647f, 1f);
    /// 游戏使用的选中字体颜色
    public static Color SELECTED = new Color(0.412f, 0.835f, 0.243f, 1f);
    /// 菜单选中字体颜色
    public static Color MENU_SELECTED = new Color(0.255f, 0.824f, 0.647f, 1f);
    /// 菜单字体颜色
    public static Color MENU = new Color(0.568f, 0.568f, 0.568f, 1f);

    /// 游戏使用的默认字体颜色
    public static string NORMAL_HEX = "41D2A4";
}

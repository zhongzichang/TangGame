/*
 * 由SharpDevelop创建。
 * 用户： xbhuang
 * 日期: 2013/5/28
 * 时间: 11:36
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using UnityEngine;

namespace TangGame
{
public class SystemSettingCache
{
    //系统设置面板
    public static bool systemSettingBool=false;
    //开启血条
    public static bool openBlood=false;
    //开启NPC名字
    public static bool openNpcName=false;
    //开启玩家名字
    public static bool openPlayerName=false;
    //开启怪物名字
    public static bool openMousterName=false;
    //开启NPC
    public static bool openNpc=false;
    //开启其他玩家
    public static bool openPlayer=false;
    //开启怪物
    public static bool openMouster=false;
    //开启特效
    public static bool openEffect=false;
    //屏蔽系统消息
    public static bool openSystemMessage=false;
    //同屏最大人数限制
    public static int sameScreenCaps=20;
    //拒绝组队
    public static bool refuseTeam=false;
    //拒绝好友
    public static bool refuseFriend=false;
    //拒绝家族
    public static bool refuseClan=false;

    /// 音乐更新标示
    public static int musicUpdated;
    /// 音乐更新
    public static float music=0.5F;
    /// 音效更新标示
    public static int soundUpdated;
    /// 音效
    public static float sound=0.5F;
    //静音
    public static bool mute=false;

    /// 启动初始化数据 by Cucumber
    static SystemSettingCache()
    {
        if(PlayerConfig.HasKey("music"))
        {
            music = PlayerConfig.GetFloat("music");
        }
        if(PlayerConfig.HasKey("sound"))
        {
            sound = PlayerConfig.GetFloat("sound");
        }
    }

    /// 设置音乐大小 by Cucumber
    public static void SetMusic(float data)
    {
        music = data;
        musicUpdated++;
        PlayerConfig.SetFloat("music", music);
        PlayerConfig.Flush();
    }

    /// 设置音效大小 by Cucumber
    public static void SetSound(float data)
    {
        sound = data;
        soundUpdated++;
        PlayerConfig.SetFloat("sound", sound);
        PlayerConfig.Flush();
    }
}

}

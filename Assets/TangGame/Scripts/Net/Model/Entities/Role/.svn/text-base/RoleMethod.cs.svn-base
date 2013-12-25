/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/7
 * Time: 16:30
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of RoleMethod.
/// </summary>
public interface RoleMethod
{
    /** 获取ID */
    long getId();

    /** 当前坐标 */
    short getX();

    /** 当前坐标 */
    short getY();

    /** 当前地图 */
    short getGameMapId();

    /** 获取所在网格 */
    NGrid getGrid();

    /** 获取等级 */
    short getLevel();

    /** 获取最大HP */
    int getMaxHP();

    /** 获取当前HP */
    int getHp();

    /** 获取当前Mp */
    int getMp();

    /** 获取最大MP */
    int getMaxMP();

    /** 是否死亡 */
    bool isDeadState();

    /** 是否在离线状态(Role专用) */
    bool isOfflineState();

    /**
     * 更新对象
     */
    void update(SceneBase scene);

    /**
     * 获取最大攻击值
     * @return
     */
    int getMaxAttack();

    /**
     * 获取浮动后的攻击值
     * @return
     */
    int getAttack();

    /**
     * 获取命中值
     * @return
     */
    int getHit();

    /**
     * 获取攻击加成<br>
     * (已经于将正负加成中和)
     * @return
     */
    double getAdditionAttack();

    /**
     * 获取防御值
     * @return
     */
    int getDefence();

    /**
     * 伤害减少比例
     * @return
     */
    double getReduceHurt();

    /**
     * 固定减伤
     * @return
     */
    int getAbsoluteDefense();

    /**
     * 死亡处理
     */
    void deadHandle(RoleMethod role);

    /**
     * 增加HP
     * @param num 增加值
     */
    void addHP(int num);

    /**
     * 减少
     * @param role 攻击者
     * @param num 减少值
     */
    void reduceHP(RoleMethod role, int num);

    /**
     * 修改MP
     * @param mp
     * @param isAdd true增加
     */
    void changeMp(int num, bool isAdd);

    /**
     * 判断是否需要更新坐标位置
     */
    void doMove(SceneBase scene);

    /**
     * 删除所有正面Buff
     */
    void delBuff();

    /**
     * 删除所有Buff
     */
    void delAllBuff(bool isNoticeClient);

    /**
     * 添加BUFF
     * @param buff
     * @param isSend true:向前台推送消息
     */
    void addBuff(Buff buff, bool isSend);

    /**
     * 获取所有Buff效果
     * @return
     */
    Buff[] getAllBuff();

    /**
     * 是否发送暴击
     * @return true:发送暴击
     */
    bool isCrit();

    /**
     * 是否发动闪避
     * @param hitValue 对方命中
     * @return true:发动闪避
     */
    bool isDodge(int hitValue);

    /**
     * 技能伤害加成
     * @return
     */
    double getAddSkillHurt();

    /**
     * 绝对伤害
     * @return
     */
    int getAbsoluteAttack();

    /**
     * 暴击伤害加成
     * @return
     */
    double getAddDritical();

    /** 伤害转换比例 */
    double getTransformHurt();

    /**
     * 是否忽略闪避
     * @return true:忽略闪避
     */
    bool isIgnoreDodge();

    /** 是否在骑乘状态 */
    bool isRiding();

    /**
     * 骑马/下马
     * @return true操作成功
     */
    bool ride(bool isNotice);

    /**
     * 设置坐标
     * @param scene 场景
     * @param x 坐标
     * @param y 坐标
     * @param isUpdateNGridPoint 是否更新九宫格
     */
    void setPoint(SceneBase scene, short x, short y, bool isUpdateNGridPoint);

    /**
     * 改变击杀玩家数量
     */
    void changeSkillHeroNum();
}
}

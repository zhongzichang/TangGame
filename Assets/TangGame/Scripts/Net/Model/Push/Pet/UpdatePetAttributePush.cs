/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 23:01
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of UpdatePetAttributePush.
/// </summary>
public class UpdatePetAttributePush : Response
{
    public const string NAME = "updatePetAttribute_PUSH";

    public Pet pet;

    public UpdatePetAttributePush() : base(NAME)
    {
    }

    public static UpdatePetAttributePush Parse(MsgData data)
    {
        UpdatePetAttributePush push = new UpdatePetAttributePush();

        Pet pet = new Pet();

        int index = 0;
        pet.id = (long)data.GetDouble(index++);
        pet.level = data.GetShort(index++);
        pet.quality = data.GetShort(index++);
        pet.starLevel = data.GetShort(index++);
        pet.growValue = data.GetShort(index++);

        pet.strength = data.GetShort(index++);
        pet.stamina = data.GetShort(index++);
        pet.agility = data.GetShort(index++);
        pet.savvy = data.GetShort(index++);

        pet.hp = data.GetInt(index++);
        pet.trendsAttribute.totalHpMax = data.GetInt(index++);

        pet.trendsAttribute.totalMinAttack = data.GetInt(index++);
        pet.trendsAttribute.totalMaxAttack = data.GetInt(index++);
        pet.trendsAttribute.totalDefence = data.GetInt(index++);

        pet.trendsAttribute.totalEvadeValue = data.GetInt(index++);
        pet.trendsAttribute.absoluteDefense = data.GetInt(index++);
        pet.trendsAttribute.totalDriticalValue = data.GetInt(index++);
        pet.trendsAttribute.totalAdditionAttack = data.GetDouble(index++);
        pet.strengthValue = (long)data.GetDouble(index++);
        pet.exp = (long) data.GetDouble(index++);
        pet.addAttributeValue[0] = data.GetShort(index++);
        pet.addAttributeValue[1] = data.GetShort(index++);
        pet.addAttributeValue[2] = data.GetShort(index++);
        pet.addAttributeValue[3] = data.GetShort(index++);

        pet.trendsAttribute.totalStrength = data.GetShort(index++);
        pet.trendsAttribute.totalStamina = data.GetShort(index++);
        pet.trendsAttribute.totalAgility = data.GetShort(index++);
        pet.trendsAttribute.totalSavvy = data.GetShort(index++);

        push.pet = pet;

        return push;

    }

    public static void Update(ref Pet pet, Pet updated)
    {

        pet.id = updated.id;
        pet.level = updated.level;
        pet.quality = updated.quality;
        pet.starLevel = updated.starLevel;
        pet.growValue = updated.growValue;

        pet.strength = updated.strength;
        pet.stamina = updated.stamina;
        pet.agility = updated.agility;
        pet.savvy = updated.savvy;

        pet.hp = updated.hp;
        pet.trendsAttribute.totalHpMax = updated.trendsAttribute.totalHpMax;

        pet.trendsAttribute.totalMinAttack = updated.trendsAttribute.totalMinAttack;
        pet.trendsAttribute.totalMaxAttack = updated.trendsAttribute.totalMaxAttack;
        pet.trendsAttribute.totalDefence = updated.trendsAttribute.totalDefence;

        pet.trendsAttribute.totalEvadeValue = updated.trendsAttribute.totalEvadeValue;
        pet.trendsAttribute.absoluteDefense = updated.trendsAttribute.absoluteDefense;
        pet.trendsAttribute.totalDriticalValue = updated.trendsAttribute.totalDriticalValue;
        pet.trendsAttribute.totalAdditionAttack = updated.trendsAttribute.totalAdditionAttack;
        pet.strengthValue = updated.strengthValue;
        pet.exp = updated.exp;
        pet.addAttributeValue[0] = updated.addAttributeValue[0];
        pet.addAttributeValue[1] = updated.addAttributeValue[1];
        pet.addAttributeValue[2] = updated.addAttributeValue[2];
        pet.addAttributeValue[3] = updated.addAttributeValue[3];

        pet.trendsAttribute.totalStrength = updated.trendsAttribute.totalStrength;
        pet.trendsAttribute.totalStamina = updated.trendsAttribute.totalStamina;
        pet.trendsAttribute.totalAgility = updated.trendsAttribute.totalAgility;
        pet.trendsAttribute.totalSavvy = updated.trendsAttribute.totalSavvy;

    }
}
}

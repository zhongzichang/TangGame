using System;
using TangScene;

namespace TangGame.View
{
public class Relationship
{
    public enum Type {ENIMY, FRIEND, NORMAL}

    public static Type parse(ActorVo source, ActorVo target)
    {

        // npc => dialog
        if(target.actorType == ActorType.npc)
        {
            return Type.NORMAL;
        }

        Mode.Type sourceModeType = source.mode.getType();
        Mode.Type targetModeType = target.mode.getType();

        if(Mode.Type.BATTLE == sourceModeType || Mode.Type.BATTLE == targetModeType)
        {
            // battle too
            return Type.ENIMY;

        }
        else if(Mode.Type.NORMAL == sourceModeType)
        {
            // s = camp

            if(ActorType.hero == target.actorType)
            {

                if(targetModeType == Mode.Type.NORMAL)
                {
                    // t = camp
                    if(source.camp == null || target.camp == null || !source.camp.Equils(target.camp))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
                else if(targetModeType == Mode.Type.CLUB)
                {
                    // t = club
                    if(source.club == null || target.club == null || !source.club.Equils(target.club))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
                else if(targetModeType == Mode.Type.TEAM)
                {
                    // t = team
                    if(source.team == null || target.team == null || !source.team.Equils(target.team))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
                else if(targetModeType == Mode.Type.TRAVEL)
                {
                    // t = camp
                    if(source.camp == null || target.camp == null || !source.camp.Equils(target.camp))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
            }
            else
            {
                // monster and boss
                return Type.ENIMY;
            }
        }
        else if(Mode.Type.CLUB == sourceModeType)
        {
            // t = club
            if(source.club == null || target.club == null || !source.club.Equils(target.club))
                return Type.ENIMY;
            else if(target.actorType == ActorType.hero)
                return Type.FRIEND;
            else
                return Type.NORMAL;
        }
        else if(Mode.Type.TEAM == sourceModeType)
        {
            // t = team
            if(source.team == null || target.team == null || !source.team.Equils(target.team))
                return Type.ENIMY;
            else if(target.actorType == ActorType.hero)
                return Type.FRIEND;
            else
                return Type.NORMAL;
        }
        else if(Mode.Type.TRAVEL == sourceModeType)
        {

            if(ActorType.hero == target.actorType)
            {

                if(targetModeType == Mode.Type.NORMAL)
                {
                    // t = camp
                    if(source.camp == null || target.camp == null || !source.camp.Equils(target.camp))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
                else if(targetModeType == Mode.Type.CLUB)
                {
                    // t = club
                    if(source.club == null || target.club == null || !source.club.Equils(target.club))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
                else if(targetModeType == Mode.Type.TEAM)
                {
                    // t = team
                    if(source.team == null || target.team == null || !source.team.Equils(target.team))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
                else if(targetModeType == Mode.Type.TRAVEL)
                {
                    // t = camp
                    if(source.camp == null || target.camp == null || !source.camp.Equils(target.camp))
                        return Type.ENIMY;
                    else
                        return Type.FRIEND;
                }
            }
            else
            {
                // monster and boss
                return Type.NORMAL;
            }
        }

        return Type.NORMAL;
    }
}
}


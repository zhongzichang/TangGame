using System;
using UnityEngine;
using TangScene;
using TangUtils;

namespace TangGame.View
{
public class Position
{
    public const int SCALEX = 32;
    public const int SCALEY = -16;

    public bool updated = false;
    private Vector3 worldVector = Vector3.zero;
    private bool gamePointUpdated = false;


    public Vector3 WorldVector
    {
        get
        {
            return worldVector;
        }
        set
        {
            this.worldVector = value;
            this.updated = true;
            this.gamePointUpdated = false;
        }
    }

    private Point gamePoint;
    public Point GamePoint
    {
        get
        {
            if(!gamePointUpdated)
            {
                gamePoint = new Point((int)(worldVector.x/SCALEX), (int)(worldVector.z/SCALEY));
                gamePointUpdated = true;
            }
            return gamePoint;
        }
        set
        {
            this.gamePoint = value;
            this.gamePointUpdated = true;
            this.worldVector.x = value.x * SCALEX;
            this.worldVector.z = value.y * SCALEY;
            this.updated = true;
        }
    }


    public Position(Point gamePoint)
    {
        this.worldVector.x = gamePoint.x * SCALEX;
        this.worldVector.z = gamePoint.y * SCALEY;
        this.gamePoint = gamePoint;
        this.gamePointUpdated = true;
    }

    public Position(Vector3 worldVector)
    {
        this.worldVector = worldVector;
        this.gamePointUpdated = false; // game point need update.
    }
    public static float GetScaleXDividedByScaleY(){
    	return Math.Abs(SCALEX)/Math.Abs(SCALEY);
    }
    public static float GetScaleYDividedByScaleX(){
    	return Math.Abs(SCALEY)/Math.Abs(SCALEX);
    }
}
}


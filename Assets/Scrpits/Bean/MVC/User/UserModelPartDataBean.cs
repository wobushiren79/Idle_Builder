using UnityEditor;
using UnityEngine;
using System;

public class UserModelPartDataBean 
{
    public long partId;
    public long addPrice;
    public int level;

    public UserModelPartDataBean(long partId,long addPrice)
    {
        this.partId = partId;
        SetAddPrice(addPrice);
    }

    public void SetAddPrice(long addPrice)
    {
        this.addPrice = addPrice;
    }

    public int LevelUp(int addLevel)
    {
        level += addLevel;
        if (level <= 0)
        {
            level = 0;
        }
        return level;
    }
}
using UnityEditor;
using UnityEngine;
using System;

public class UserModelPartDataBean 
{
    public long partId;
    public long addPrice;
    public UserModelPartDataBean(long partId,long addPrice)
    {
        this.partId = partId;
        this.addPrice = addPrice;
    }

}
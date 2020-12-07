using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class UserModelDataBean 
{
    public long modelId;
    public List<UserModelPartDataBean> listUnlockPart;

    public UserModelDataBean(long modelId)
    {
        this.modelId = modelId;
    }

}
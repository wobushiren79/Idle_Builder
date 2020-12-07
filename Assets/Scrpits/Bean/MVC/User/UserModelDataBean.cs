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

    /// <summary>
    /// 增加已解锁模型
    /// </summary>
    /// <param name="modelId"></param>
    public bool AddUnLockPart(long partId)
    {
        if (listUnlockPart == null)
            listUnlockPart = new List<UserModelPartDataBean>();
        bool hasData = CheckHasPart(modelId, out UserModelPartDataBean partDataBean);
        if (hasData)
        {
            return false;
        }
        else
        {
            UserModelPartDataBean modelData = new UserModelPartDataBean(partId);
            listUnlockPart.Add(modelData);
            return true;
        }
    }

    /// <summary>
    /// 检测是否有模型
    /// </summary>
    /// <param name="modelId"></param>
    /// <returns></returns>
    public bool CheckHasPart(long partId, out UserModelPartDataBean partDataBean)
    {
        partDataBean = null;
        for (int i = 0; i < listUnlockPart.Count; i++)
        {
            UserModelPartDataBean itemPartData = listUnlockPart[i];
            if (partId == itemPartData.partId)
            {
                partDataBean = itemPartData;
                return true;
            }
        }
        return false;
    }
}
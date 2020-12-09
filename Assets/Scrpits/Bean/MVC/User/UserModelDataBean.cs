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
    /// 通过部件ID获取数据
    /// </summary>
    /// <param name="partId"></param>
    /// <returns></returns>
    public UserModelPartDataBean GetUserPartDataById(long partId)
    {
        if (listUnlockPart == null)
            return null;
        for (int i = 0; i < listUnlockPart.Count; i++)
        {
            UserModelPartDataBean itemPartData = listUnlockPart[i];
            if (partId == itemPartData.partId)
            {
                return itemPartData;
            }
        }
        return null;
    }

    /// <summary>
    /// 升级部件
    /// </summary>
    /// <param name="partId"></param>
    /// <param name="addLevel"></param>
    public void LevelUpPart(long partId,int addLevel)
    {
        if (listUnlockPart == null)
            return;
        for (int i = 0; i < listUnlockPart.Count; i++)
        {
            UserModelPartDataBean itemPartData = listUnlockPart[i];
            if (partId == itemPartData.partId)
            {
                itemPartData.LevelUp(addLevel);
                return;
            }
        }
    }

    /// <summary>
    /// 增加已解锁模型
    /// </summary>
    /// <param name="modelId"></param>
    public UserModelPartDataBean AddUnLockPart(long partId, long addPrice)
    {
        if (listUnlockPart == null)
            listUnlockPart = new List<UserModelPartDataBean>();
        bool hasData = CheckHasPart(partId, addPrice, out UserModelPartDataBean partDataBean);
        if (hasData)
        {
            return partDataBean;
        }
        else
        {
            UserModelPartDataBean modelData = new UserModelPartDataBean(partId, addPrice);
            listUnlockPart.Add(modelData);
            return modelData;
        }
    }

    /// <summary>
    /// 检测是否有模型
    /// </summary>
    /// <param name="modelId"></param>
    /// <returns></returns>
    public bool CheckHasPart(long partId, long addPrice, out UserModelPartDataBean partDataBean)
    {
        partDataBean = null;
        for (int i = 0; i < listUnlockPart.Count; i++)
        {
            UserModelPartDataBean itemPartData = listUnlockPart[i];
            if (partId == itemPartData.partId)
            {
                partDataBean = itemPartData;
                partDataBean.addPrice = addPrice;
                return true;
            }
        }
        return false;
    }
}
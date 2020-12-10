using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class ModelInfoBean : BaseBean
{
    public string model_name;
    public long unlock_money;
    public string name;
    public string content;

    public List<ModelPartInfoBean> listPartData;

    /// <summary>
    /// 检测是否有该部件
    /// </summary>
    /// <param name="partName"></param>
    /// <returns></returns>
    public ModelPartInfoBean CheckHasPart(string partName)
    {
        if (CheckUtil.ListIsNull(listPartData))
            return null;
        for (int i=0;i< listPartData.Count;i++)
        {
            ModelPartInfoBean itemPartInfo = listPartData[i];
            if (itemPartInfo.part_name.Equals(partName))
            {
                return itemPartInfo;
            }
        }
        return null;
    }
}
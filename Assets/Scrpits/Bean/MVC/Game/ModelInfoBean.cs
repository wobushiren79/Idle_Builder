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
}
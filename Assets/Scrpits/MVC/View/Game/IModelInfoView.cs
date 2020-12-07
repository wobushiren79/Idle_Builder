using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IModelInfoView
{
    void GetModelInfoSuccess(ModelInfoBean modelInfo,Action<ModelInfoBean> action);

    void GetModelInfoFail(string failMsg);
}
using System;
using UnityEditor;
using UnityEngine;

public class GameModelHandler : BaseHandler<GameModelManager>
{
    public void GetModelInfoById(long id, Action<ModelInfoBean> action)
    {
        manager.GetModelInfoById(id, action);
    }

}
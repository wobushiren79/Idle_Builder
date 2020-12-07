using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : BaseMonoBehaviour
{

    public GameModelHandler handler_GameModel;

    private void Awake()
    {
        AutoLinkHandler();
    }

    private void Start()
    {
        handler_GameModel.GetModelInfoById(1, (data) =>
        {
            LogUtil.Log(data.model_name);
        });
    }

}

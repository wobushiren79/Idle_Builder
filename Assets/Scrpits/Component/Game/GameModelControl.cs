﻿using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameModelControl : BaseMonoBehaviour
{
    private Touch oldTouch1;  //上次触摸点1(手指1)  
    private Touch oldTouch2;  //上次触摸点2(手指2)  

    protected float speedForRotate = 10;
    protected float speedForHorizontalMove = 1;
    protected float speedForScale = 0.1f;

    protected float minScaleSize = 0.3f;
    protected float maxScaleSize = 3f;
    void Update()
    {
        //没有触摸
        if (Input.touchCount <= 0)
            return;
        //HandleForHorizontalMove();
        HandleForRotation(false, true);
        HandleForScale();
    }

    public void HandleForScale()
    {
        //如果触碰到了UI
        if (Input.touchCount != 2
            || EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)
            || EventSystem.current.IsPointerOverGameObject(Input.GetTouch(1).fingerId))
            return;
        //多点触摸, 放大缩小  
        Touch newTouch1 = Input.GetTouch(0);
        Touch newTouch2 = Input.GetTouch(1);

        //第2点刚开始接触屏幕, 只记录，不做处理  
        if (newTouch2.phase == TouchPhase.Began)
        {
            oldTouch2 = newTouch2;
            oldTouch1 = newTouch1;
            return;
        }

        //计算老的两点距离和新的两点间距离，变大要放大模型，变小要缩放模型  
        float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
        float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

        //两个距离之差，为正表示放大手势， 为负表示缩小手势  
        float offset = newDistance - oldDistance;


        float scaleFactor = offset * speedForScale * Time.deltaTime;
        Vector3 localScale = transform.localScale;
        Vector3 scale = new Vector3(localScale.x + scaleFactor,
                                    localScale.y + scaleFactor,
                                    localScale.z + scaleFactor);

        if (scale.x > maxScaleSize || scale.y > maxScaleSize || scale.z > maxScaleSize)
        {
            transform.localScale = new Vector3(maxScaleSize, maxScaleSize, maxScaleSize);
        }
        else if (scale.x < minScaleSize || scale.y < minScaleSize || scale.z < minScaleSize)
        {
            transform.localScale = new Vector3(minScaleSize, minScaleSize, minScaleSize);
        }
        else
        {
            transform.localScale = scale;
        }

        //记住最新的触摸点，下次使用  
        oldTouch1 = newTouch1;
        oldTouch2 = newTouch2;
    }

    /// <summary>
    /// 移动处理
    /// </summary>
    /// <param name="isOpenVertical"></param>
    /// <param name="isOpenHorizontal"></param>
    public void HandleForMove(bool isOpenVertical, bool isOpenHorizontal)
    {
        //单点触摸， 水平移动
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //没有点到UI时
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                var deltaposition = Input.GetTouch(0).deltaPosition;
                float horizontal = 0;
                float vertical = 0;
                if (isOpenVertical)
                {
                    vertical = -deltaposition.y * speedForHorizontalMove * Time.deltaTime;
                }
                if (isOpenHorizontal)
                {
                    horizontal = -deltaposition.x * speedForHorizontalMove * Time.deltaTime;
                }
                transform.Translate(horizontal, 0f, vertical);
            }
        }
    }

    /// <summary>
    /// 旋转处理
    /// </summary>
    /// <param name="isOpenVertical"></param>
    /// <param name="isOpenHorizontal"></param>
    public void HandleForRotation(bool isOpenVertical, bool isOpenHorizontal)
    {
        //单点触摸， 上下旋转
        if (Input.touchCount == 1)
        {
            //没有点到UI时
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                var deltaposition = Input.GetTouch(0).deltaPosition;
                if (isOpenVertical)
                {
                    transform.Rotate(Vector3.right * deltaposition.y * Time.deltaTime * speedForRotate, Space.World);
                }
                if (isOpenHorizontal)
                {
                    transform.Rotate(Vector3.down * deltaposition.x * Time.deltaTime * speedForRotate, Space.World);
                }
            }
        }
    }


}
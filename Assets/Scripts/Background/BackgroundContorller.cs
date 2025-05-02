using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundContorller : MonoBehaviour
{
    private Camera mainCamera;
    //private PlayerMove playerMove;
    private float rollSpeed = 2.5f;//滚动速度
    private float verticalSpeed = 5f;
    // private float right; //右边界
    // private float left; //左边界
    // private float distance; //左右边界距离

    // Use this for initialization
    void Start()
    {
        //计算左右边界。Bounds是当图形的边界框
        Debug.Log("BG st");
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        // SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        // right = transform.position.x + sRender.bounds.extents.x / 3;
        // left = transform.position.x - sRender.bounds.extents.x / 3;
        //distance = right - left;//左右边界相减得到距离
        //playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("BG move");
        //使背景图片移动
        BackgroundMove();
    }

    private void BackgroundMove()
    {
        transform.localPosition += rollSpeed * Vector3.right * Time.deltaTime * (mainCamera.velocity.x / 12);
        transform.localPosition -= verticalSpeed * Vector3.down * Time.deltaTime * (mainCamera.velocity.y / 6);
        /*
        //判断是否到达右边界
        if (transform.position.x < left)
        {
            //如果到达，将背景图片的位置向后（x轴方向）调整一个背景图片长度的距离
            //transform.position += new Vector3(-distance, 0, 0);
        }
        //判断是否到达左边界
        if (transform.position.x > right)
        {
            //如果到达，将背景图片的位置向前（x轴方向）调整一个背景图片长度的距离
            //transform.position += new Vector3(distance, 0, 0);
        }
        */
    }
}

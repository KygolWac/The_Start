using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundContorller : MonoBehaviour
{
    private Camera mainCamera;
    //private PlayerMove playerMove;
    private float rollSpeed = 2.5f;//�����ٶ�
    private float verticalSpeed = 5f;
    // private float right; //�ұ߽�
    // private float left; //��߽�
    // private float distance; //���ұ߽����

    // Use this for initialization
    void Start()
    {
        //�������ұ߽硣Bounds�ǵ�ͼ�εı߽��
        Debug.Log("BG st");
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        // SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        // right = transform.position.x + sRender.bounds.extents.x / 3;
        // left = transform.position.x - sRender.bounds.extents.x / 3;
        //distance = right - left;//���ұ߽�����õ�����
        //playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("BG move");
        //ʹ����ͼƬ�ƶ�
        BackgroundMove();
    }

    private void BackgroundMove()
    {
        transform.localPosition += rollSpeed * Vector3.right * Time.deltaTime * (mainCamera.velocity.x / 12);
        transform.localPosition -= verticalSpeed * Vector3.down * Time.deltaTime * (mainCamera.velocity.y / 6);
        /*
        //�ж��Ƿ񵽴��ұ߽�
        if (transform.position.x < left)
        {
            //������������ͼƬ��λ�����x�᷽�򣩵���һ������ͼƬ���ȵľ���
            //transform.position += new Vector3(-distance, 0, 0);
        }
        //�ж��Ƿ񵽴���߽�
        if (transform.position.x > right)
        {
            //������������ͼƬ��λ����ǰ��x�᷽�򣩵���һ������ͼƬ���ȵľ���
            //transform.position += new Vector3(distance, 0, 0);
        }
        */
    }
}

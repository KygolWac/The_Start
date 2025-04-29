using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundContorller : MonoBehaviour
{
    //private PlayerMove playerMove;
    [SerializeField] private float rollSpeed = 2.5f;//�����ٶ�
    private float right; //�ұ߽�
    private float left; //��߽�
    private float distance; //���ұ߽����

    // Use this for initialization
    void Start()
    {
        //�������ұ߽硣Bounds�ǵ�ͼ�εı߽��
        SpriteRenderer sRender = GetComponent<SpriteRenderer>();
        right = transform.position.x + sRender.bounds.extents.x / 3;
        left = transform.position.x - sRender.bounds.extents.x / 3;

        distance = right - left;//���ұ߽�����õ�����
    }

    // Update is called once per frame
    void Update()
    {
        //ʹ����ͼƬ�����ƶ�
        transform.localPosition += rollSpeed * Vector3.right * Time.deltaTime * (PlayerMove.playerRb.velocity.x/12);

        //�ж��Ƿ񵽴��ұ߽�
        if (transform.position.x > right)
        {
            //������������ͼƬ��λ�����x�᷽�򣩵���һ������ͼƬ���ȵľ���
            transform.position -= new Vector3(distance, 0, 0);
        }
        //�ж��Ƿ񵽴���߽�
        if (transform.position.x > right)
        {
            //������������ͼƬ��λ����ǰ��x�᷽�򣩵���һ������ͼƬ���ȵľ���
            transform.position += new Vector3(distance, 0, 0);
        }
    }
}

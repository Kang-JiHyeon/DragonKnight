using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶� �÷��̾ �׻� �ٶ󺸰� �ʹ�.
// ���Ŀ� �÷��̾�� ���� ����� �ٶ󺸵��� ������ ��
public class JH_FollowCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}

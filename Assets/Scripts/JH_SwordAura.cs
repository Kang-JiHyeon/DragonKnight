using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� ���� �ִ� �������� �� ���� ������ ������ ������ �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�, ����
public class JH_SwordAura : MonoBehaviour
{
    public float swordSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // ������ ������ �ʹ�.
        transform.position += transform.forward * swordSpeed * Time.deltaTime;
    }


}

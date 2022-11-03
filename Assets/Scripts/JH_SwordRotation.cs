using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� Ű�� ������ �� ȸ������ ȸ����Ų��.
public class JH_SwordRotation : MonoBehaviour
{
    // ȸ����
    float rx, ry, rz;
    public float rotSpeed = 400f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        rx += rotSpeed * Time.deltaTime;
        ry += rotSpeed * Time.deltaTime;
        rz += rotSpeed * Time.deltaTime;

        ry = Mathf.Clamp(ry, -60, 60);
        rz = Mathf.Clamp(rz, 0, 30);

        //print(rz);
        //if (rz < 0 || rz > 90)
        //{
        //    ry *= -1;
        //    rz *= -1;
        //}
        transform.eulerAngles = new Vector3(0, -ry, 0);
        //// Z�� ȸ���Ѵ�.
        //transform.Rotate(0, 0, rz);

        print($"{rx}, {ry}, {rz}");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// light�� y�� �������� ��� ������ �ʹ�.
public class JH_EndingLightRotate : MonoBehaviour
{
    Light sun;
    //float lightSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float i = 1;
        sun.transform.Rotate(0, 15 * Time.deltaTime, 0);
        //sun.transform.rotation = Quaternion.Euler(0, 10 * i, 0);
        i++;
    }
}

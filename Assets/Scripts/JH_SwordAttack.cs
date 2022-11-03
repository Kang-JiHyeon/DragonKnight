using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� Ű�� ������ ���Ÿ� �� ������ ������.
// �ʿ� �Ӽ� : �� ����, �� ��ġ

public class JH_SwordAttack : MonoBehaviour
{
    public GameObject swordFactory;
    JH_Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("JH_Player").GetComponent<JH_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // ����Ű�� ������ ���Ÿ� �� ������ ������ �ʹ�.
        // 1. ����Ű�� ������ ��
        if (Input.GetKeyDown(KeyCode.C))
        {
            // 2. �� ������ �־�� �Ѵ�.
            GameObject sword = Instantiate(swordFactory);
            // 3. �� ������ ������ �ʹ�.
            sword.transform.position = transform.position;

        }
    }
}

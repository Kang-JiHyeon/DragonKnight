using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_DodgeRange : MonoBehaviour
{
    JH_Player player;
    bool isEnemyDodge = false;
    float slowTime = 0.2f;
    float currentTime = 0;
    GameObject dodgeBlur;

    private void Awake()
    {
        dodgeBlur = GameObject.Find("DodgeImage");
        player = GameObject.Find("Player").GetComponent<JH_Player>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
         dodgeBlur.SetActive(false);
    }

    // Update is called once per frame
    void Update() 
    {
        // ���� ȸ�� �߿� ���� �����Ǹ�
        if (isEnemyDodge)
        {
            // ���ο�
            SetTimeScale(0.2f);

            dodgeBlur.SetActive(true);

            // �ð��� �귯
            currentTime += Time.deltaTime;

            // ���� �ð��� ���ο� �ð����� Ŀ����
            if(currentTime > slowTime)
            {
                // ���� �ӵ��� ���ƿ´�.
                currentTime = 0f;
                isEnemyDodge = false;
                SetTimeScale(1.0f);
                dodgeBlur.SetActive(false);
            }
        }
    }
    // ���ο� 
    void SetTimeScale(float time)
    {
        // timeScale : ����Ƽ �󿡼� �ð��� �帣�� �ӵ��� ������� ��Ÿ��
        // ���� �ð� = 1.0f, ���� =0.5f, ���� = 0f 
        Time.timeScale = time;

        // ����Ƽ���� ���� ������ ����ϴ� FixedUpdate()�� �ʴ� 50ȸ(1��/50ȸ = 0.02f) ȣ����
        // timeScale�� �ٲ� �� fizedDeltaTime�� �ٲ���� ��
        Time.fixedDeltaTime = 0.02f * time;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ������ �������� ��
        if (other.gameObject.name.Contains("Magic") || other.gameObject.name.Contains("Fire") || other.gameObject.name.Contains("MeleeArea"))
        {
            // �÷��̾ ȸ�� ���¶��
            if (player.isDodge)
            {
                isEnemyDodge = true;
                print("isEnemyDodge ture");
            }
        }
    }

}

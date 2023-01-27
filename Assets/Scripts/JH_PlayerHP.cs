using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JH_PlayerHP : MonoBehaviour
{
    //�¾�� ü���� �ִ�ü������ �ϰ�ʹ�.
    //���� �÷��̾ ������ �� ü���� �����ϰ�ʹ�.
    //ü���� ����Ǹ� UI���� �ݿ��ϰ� �ʹ�.
    JH_Player player;
    GameObject childPlayer;
    public Slider sliderHP;
    public AudioSource BGM;
    public AudioSource DeathSound;

    public int maxHP = 5;
    public bool isDamage = false;
    int blinkCount = 8;

    

    private int hp;
    public int HP
    {
        get { return hp; }
        set
        {
            // ȸ�� ������ �ʰ�, ���� ������ ���� �ǰ� ó��
            if (!player.isDodge && !isDamage)
            {
                isDamage = true;
                hp = value;
                sliderHP.value = hp;
                player.anim.SetTrigger("doDamage");

                // �������� -> �����Ÿ�
                if (hp > 0)
                {
                    StopCoroutine(UnDamageTime());
                    StartCoroutine(UnDamageTime()); 
                }
            }
            // ������ �÷��̾� ����
            if (hp <= 0)
            {
                player.anim.SetTrigger("doDie");
                player.isDie = true;
                BGM.Stop();
                DeathSound.Play();
                JH_HitManager.instance.ShowGameOver();
            }
        }
    }

    // ��������
    // ������ �¾��� �� F02 ������Ʈ�� �����̰� �ʹ�.
    IEnumerator UnDamageTime()
    {
        bool isActive = true;
        int count = 10;

        while (count>0)
        {
            isActive = !isActive;
            childPlayer.SetActive(isActive);
            count--;
            yield return new WaitForSeconds(0.2f);
        }
        isDamage = false;
    }

    public static JH_PlayerHP Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        player = gameObject.GetComponent<JH_Player>();
        childPlayer = transform.GetChild(1).gameObject;
        sliderHP.maxValue = maxHP;
        sliderHP.value = maxHP;
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

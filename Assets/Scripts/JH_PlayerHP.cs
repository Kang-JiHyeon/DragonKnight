using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JH_PlayerHP : MonoBehaviour
{
    //태어날때 체력을 최대체력으로 하고싶다.
    //적이 플레이어를 공격할 때 체력을 감소하고싶다.
    //체력이 변경되면 UI에도 반영하고 싶다.
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
            // 회피 중이지 않고, 무적 상태일 때만 피격 처리
            if (!player.isDodge && !isDamage)
            {
                isDamage = true;
                hp = value;
                sliderHP.value = hp;
                player.anim.SetTrigger("doDamage");

                // 무적상태 -> 깜빡거림
                if (hp > 0)
                {
                    StopCoroutine(UnDamageTime());
                    StartCoroutine(UnDamageTime()); 
                }
            }
            // 죽으면 플레이어 제거
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

    // 무적상태
    // 적에게 맞았을 때 F02 오브젝트를 깜빡이고 싶다.
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JH_Player : MonoBehaviour
{
    public Animator anim;
    Rigidbody rigid;
    Transform sandPos;
    string sceneName;

    public Vector3 dir;
    public float speed = 10f;           // �̵� �ӵ�
    public float jumpForce = 15f;       // ���� ��
    public float forceGravity = 40f;    // �߷�
    public int jumpCount = 2;           // ���� ��

    float h, v;
    bool isGrounded = false;
    bool isJump = false;

    // ���� ���� ����
    public bool isDodge = false;
    public bool isAttack = false;
    public bool isDie = false;

    // ����
    public AudioSource jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        sandPos = transform.Find("Sand").gameObject.transform;
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDie)
        {
            Run();
            Turn();
            Jump();
            Dodge();
        }
    }

    private void FixedUpdate()
    {
        rigid.AddForce(Vector3.down * forceGravity);
    }

    float sandTime = 0.5f;
    float curTime = 0f;
    private void Run()
    { 
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // �յ� �¿� ������ �����.
        dir = Vector3.right * h + Vector3.forward * v;

        if (sceneName == "BattleScene")
        {
            // ī�޶� �ٶ󺸴� ������ �չ������� �ϰ�ʹ�.
            dir = Camera.main.transform.TransformDirection(dir);
        }

        // ����ȭ
        dir.Normalize();

        

        // ���� ���� ���� ���� �����δ�.
        if (!isAttack)
        {
            if (sceneName == "TutorialScene")
            {
                // �� �������� �̵��Ѵ�.
                transform.position += -dir * speed * Time.deltaTime;
            }
            else
            {
                // �� �������� �̵��Ѵ�.
                transform.position += dir * speed * Time.deltaTime;
            }

           
            // �����̰� ������ isRun = true
            anim.SetBool("isRun", dir != Vector3.zero);

            curTime += Time.deltaTime;

            // Ground���� Run�� ����
            if (!isJump && !isDodge && dir != Vector3.zero)
            {   // ���� ���� �ð��� �Ǹ�
                if (curTime > sandTime)
                {
                    StartCoroutine("IeSand");
                    curTime = 0;
                }

            }
        }
    }


    public GameObject sandFactory;
    // �÷��̾ �ٰ� ���� ��, 5�ʸ��� �� ����Ʈ ����
    IEnumerator IeSand()
    {
        GameObject sand = Instantiate(sandFactory);
        sand.transform.position = sandPos.position;
        yield return null;
    }

    private void Turn()
    {
        if (sceneName == "TutorialScene")
        {
            // �ٶ󺸰� �ִ� �������� �÷��̾� ȸ��
            transform.LookAt(transform.position - dir);
        }
        else
        {
            // �ٶ󺸰� �ִ� �������� �÷��̾� ȸ��
            transform.LookAt(transform.position + dir);
        }
    }

    
    private void Jump()
    {
        if (isGrounded)
        {
            if (jumpCount > 0)
            {
                // ����Ű�� ������
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    isJump = true;
                    anim.SetTrigger("doJump");
                    jumpSound.Play();
                    // �� �������� �� ����
                    rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    //������ �� ���� ����Ƚ�� ���� -> ���� ����
                    jumpCount--;
                }
            }
        }
    }


    // ȸ�� dodge
    // xŰ�� ������ �̵� ���� �������� 0.1�ʵ��� �⺻ �̵��ӵ��� 2�� �ӵ��� �̵��Ѵ�.
    // �̵� ���� �� �������� ���� �ʴ´�.
    public float dodgeSpeed = 15f;
    public GameObject dodgeParticleFactory1;
    public GameObject dodgeParticleFactory2;
    

    private void Dodge()
    {
        // ȸ�� ���� �� ���� Ű�� ���߸� �̵��� �����.
        // ���� ���� �ƴ϶��
        if (!isAttack)
        {
            // ȸ�� Ű�� ������ �̵� ���� �������� �뽬 �ӵ��� �̵��Ѵ�.
            if (Input.GetKey(KeyCode.X))
            {
                isDodge = true;

                if (sceneName == "TutorialScene")
                {
                    // �� �������� �̵��Ѵ�.
                    transform.position += -dir * dodgeSpeed * Time.deltaTime;
                }
                else
                {
                    // �� �������� �̵��Ѵ�.
                    transform.position += dir * dodgeSpeed * Time.deltaTime;
                }


                // ��ƼŬ�� �����Ѵ�.
                // �ʿ�Ӽ� : ��ƼŬ����, �����ð�, ����ð�, ��ġ
                GameObject dodgeParticle1 = Instantiate(dodgeParticleFactory1);
                GameObject dodgeParticle2 = Instantiate(dodgeParticleFactory2);
                dodgeParticle1.transform.position = transform.position;
                dodgeParticle2.transform.position = transform.position;


                // �÷��̾ ��Ȱ��ȭ �Ѵ�.
                transform.Find("F02").gameObject.SetActive(false);
            }
        }


        if (Input.GetKeyUp(KeyCode.X))
        {
            isDodge = false;

            if (sceneName == "TutorialScene")
            {
                // �� �������� �̵��Ѵ�.
                transform.position += -dir * speed * Time.deltaTime;
            }
            else
            {
                // �� �������� �̵��Ѵ�.
                transform.position += dir * speed * Time.deltaTime;
            }

            // �÷��̾ Ȱ��ȭ�Ѵ�.
            transform.Find("F02").gameObject.SetActive(true);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Ground") || collision.gameObject.layer == 10)
        {
            isJump = false;
            isGrounded = true;
            //Ground�� ������ ����Ƚ���� 2�� �ʱ�ȭ��
            jumpCount = 2;
        }

        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_IntroPlayerMove : MonoBehaviour
{
    public Animator anim;
    Rigidbody rigid;

    public Vector3 dir;
    public float speed = 10f;           // �̵� �ӵ�
    public float jumpForce = 15f;       // ���� ��
    public float forceGravity = 40f;    // �߷�
    public int jumpCount = 2;           // ���� ��

    float h, v;
    //bool isJumpDown = false;
    bool isGrounded = false;
    public bool isDie = false;

    // �ִϸ��̼� ���� ����
    public bool isDodge = false;
    public bool isAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Turn();
        Jump();
        Dodge();
        Attack();
    }

    private void FixedUpdate()
    {
        rigid.AddForce(Vector3.down * forceGravity);
    }


    private void Run()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // �յ� �¿� ������ �����.
        dir = Vector3.right * h + Vector3.forward * v;

        
        // ����ȭ
        dir.Normalize();


        // ���� ���� ���� ���� �����δ�.
        if (!isAttack)
        {
            // �� �������� �̵��Ѵ�.
            transform.position += -dir * speed * Time.deltaTime;
            // �����̰� ������ isRun = true
            anim.SetBool("isRun", dir != Vector3.zero);
        }
    }

    private void Turn()
    {
        transform.LookAt(transform.position + dir);
    }

    private void Jump()
    {
        if (isGrounded)
        //if (isGrounded)
        {
            // anim.SetBool("isJump", false);
            if (jumpCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Z)) // ����Ű�� ������
                {
                    anim.SetTrigger("doJump");
                    rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //���������� �ö󰡰���
                    jumpCount--;    //�����Ҷ� ���� ����Ƚ�� ����
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
                transform.position += -dir * dodgeSpeed * Time.deltaTime;

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
            transform.position += -dir * speed * Time.deltaTime;
            // �÷��̾ Ȱ��ȭ�Ѵ�.
            transform.Find("F02").gameObject.SetActive(true);
        }

    }

    private void Attack()
    {

        // �ִϸ��̼� ���� ������ ���� ��
        if (!(anim.GetCurrentAnimatorStateInfo(0).IsName("ATK0") || anim.GetCurrentAnimatorStateInfo(0).IsName("ATK2") || anim.GetCurrentAnimatorStateInfo(0).IsName("ATK3")))
        {
            isAttack = false;
        }

        // ���� ����Ű�� ������
        if (Input.GetKeyDown(KeyCode.C))
        {
            isAttack = true;

            //�޺� ������ �Ѵ�.
            anim.SetTrigger("doCombo");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 12)
        {
            isGrounded = true;
            //isDodge = false;
            jumpCount = 2;          //Ground�� ������ ����Ƚ���� 2�� �ʱ�ȭ��
            //anim.SetBool("isJump", false);
            // anim.SetBool("isDodge", false);
        }
    }
}

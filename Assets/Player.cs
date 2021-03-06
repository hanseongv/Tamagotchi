using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
목표
맥스 코인
순위 남기기

게임진행
코인 먹기
아이템사기 (치장, 장비)
레벨업
캐릭터 구입
성장하기
     */

    public int doubleJumpCount = 1;
    public int currentDoubleJumpCount = 0;
    public float speed = 1f;
    public float jumpPower = 6f;
    public float hitPower = 4f;
    private Animator animator;
    private Rigidbody rigid;
    private Vector3 moveVec;

    public enum StateType
    {
        Idle,
        Move,
        Jump,
        Hit,
    }

    public StateType stateType = StateType.Move;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveVec = Vector3.zero;

        GetInput();
        Move();
        RigidConstraints();
    }

    //public void Hit()
    //{
    //    animator.SetTrigger("Hit");
    //    rigid.AddForce(transform.forward * hitPower * -1, ForceMode.Impulse);
    //}
    public void Hit(Vector3 dis)
    {
        rigid.constraints = RigidbodyConstraints.FreezeRotation;
        stateType = StateType.Hit;
        animator.SetTrigger("Hit");
        rigid.AddForce(dis * hitPower, ForceMode.Impulse);

        Invoke("HitWait", 0.1f);
    }

    private void HitWait()
    {
        stateType = StateType.Jump;
    }

    private void Jump()
    {
        if (currentDoubleJumpCount < doubleJumpCount)
        {
            stateType = StateType.Jump;
            currentDoubleJumpCount++;

            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            //rigid.AddForce(new Vector3(0, 1.0f, 0f) * jumpPower);
            animator.SetBool("jump", true);
        }
    }

    private void RigidConstraints()
    {
    }

    public void HitJump()
    {
        rigid.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; ;
        stateType = StateType.Jump;

        rigid.AddForce(Vector3.up * (jumpPower - 3), ForceMode.Force);

        animator.SetBool("jump", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            currentDoubleJumpCount = 0;
            stateType = StateType.Idle;
            animator.SetBool("jump", false);

            rigid.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private void Move()
    {
        moveVec.Normalize();
        //transform.Translate(moveVec * speed * Time.deltaTime);
        transform.position += moveVec /** (wDown ? 0.2f : 1f) */* speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);

        if (!(stateType == StateType.Jump) && !(stateType == StateType.Hit))
        {
            if (moveVec != Vector3.zero)
            {
                stateType = StateType.Move;
                animator.SetBool("move", true);
            }
            else
            {
                stateType = StateType.Idle;
                animator.SetBool("move", false);
            }
        }
    }

    private void GetInput()
    {
        //8방향 이동
        if (Input.GetKey(KeyCode.UpArrow)) moveVec.z = 1;
        if (Input.GetKey(KeyCode.DownArrow)) moveVec.z = -1;
        if (Input.GetKey(KeyCode.RightArrow)) moveVec.x = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) moveVec.x = -1;

        //점프
        if (Input.GetKeyDown(KeyCode.LeftAlt)) Jump();
    }

    private void Anim()
    {
        if (stateType == StateType.Move)
        {
            animator.SetBool("move", true);
        }
    }
}
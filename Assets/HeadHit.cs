using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHit : MonoBehaviour
{
    public int hp = 10;
    public Player player;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        hp--;
    //        Debug.Log("머리에 맞음");
    //        Debug.Log("남은 HP" + hp);

    //        player.HitJump();
    //        animator.SetTrigger("Hit");
    //        //animator.Play("GetCoin");
    //        ////끄기
    //        //Invoke("SetActive", 0.5f);
    //        //파괴하기
    //        //Invoke("Destroy", 1f);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !(player.stateType == Player.StateType.Hit))
        {
            hp--;
            Debug.Log("머리에 맞음");
            //Debug.Log("남은 HP" + hp);

            player.HitJump();
            animator.SetTrigger("Hit");
        }
    }
}
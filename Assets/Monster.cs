using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Player player;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        player = FindObjectOfType(typeof(Player)) as Player;
    }

    private void Update()
    {
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        i = 0;
    //        //hp--;
    //        Debug.Log("몬스터에게 맞음");
    //        //Debug.Log("남은 HP" + hp);

    //        player.Hit();
    //        //animator.SetTrigger("Hit");
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 dis;
        if (collision.collider.CompareTag("Player"))
        {
            dis = this.transform.position - collision.transform.position;

            //hp--;
            Debug.Log("몬스터에게 맞음");
            //Debug.Log("남은 HP" + hp);

            player.Hit(dis * -1);
            //animator.SetTrigger("Hit");
        }
    }

    //int i = 0;
    //private void OnCollisionStay(Collision collision)
    //{
    //    i++;

    //    if (i > 100)
    //    {
    //    }
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        hp--;
    //        Debug.Log("몬스터에게 맞음");
    //        Debug.Log("남은 HP" + hp);

    //        player.Hit();
    //        animator.SetTrigger("Hit");
    //    }
    //}
}
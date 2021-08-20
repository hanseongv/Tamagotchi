using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadHit : MonoBehaviour
{
    public int hp = 10;
    public Player player;

    private void Start()
    {
        //GameObject.FindWithTag("Player").SendMessage("HitJump");
        //GameObject obj = GameObject.Find < "CharacterShee" > ().GetComponent<ScriptName>().MethodName();
        player = FindObjectOfType(typeof(Player)) as Player;

        //player.Invoke("HitJump", 4f);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        hp--;
    //        Debug.Log("머리에 맞음");
    //        Debug.Log("남은 HP" + hp);

    //        player.HitJump();
    //        //animator.Play("GetCoin");
    //        ////끄기
    //        //Invoke("SetActive", 0.5f);
    //        //파괴하기
    //        //Invoke("Destroy", 1f);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            hp--;
            Debug.Log("머리에 맞음");
            Debug.Log("남은 HP" + hp);

            player.HitJump();
            //animator.Play("GetCoin");
            ////끄기
            //Invoke("SetActive", 0.5f);
            //파괴하기
            //Invoke("Destroy", 1f);
        }
    }
}
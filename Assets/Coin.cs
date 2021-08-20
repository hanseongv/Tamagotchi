using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Animator animator;
    public new GameObject gameObject;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        //gameObject = GetComponent<GameObject>();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("닿음");
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        //Destroy(this);
    //        Debug.Log("플레이어 닿음");
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("트리거 플레이어 닿음");
            animator.Play("GetCoin");
            //끄기
            Invoke("SetActive", 0.5f);
            //파괴하기
            //Invoke("Destroy", 1f);
        }
    }

    private void SetActive()
    {
        gameObject.SetActive(false);
    }

    //private void Destroy()
    //{
    //    Destroy(gameObject);
    //}
}
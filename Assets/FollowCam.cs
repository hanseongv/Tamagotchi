using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject target;
    public float DelayTime = 1f;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");

        //GetComponent  //gameobject = GameObject.Find("SkillLine");
    }

    // Update is called once per frame
    private void Update()
    {
        //transform.position = target.transform.position;
        transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * DelayTime);
    }
}
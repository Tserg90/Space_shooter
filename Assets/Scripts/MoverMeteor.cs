using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MeteorSpeed
{
    public float minSpeed, maxSpeed;
}
public class MoverMeteor : MonoBehaviour
{
    public MeteorSpeed speed;
    public void Start()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.right * -Random.Range(speed.minSpeed, speed.maxSpeed);
    }
}

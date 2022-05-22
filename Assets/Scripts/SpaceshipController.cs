using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}
public class SpaceshipController : MonoBehaviour
{
    private float Speed = 10;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;

    private float fireRate = 0.5f;
    public float nextFire = 0.0f;
    
    public void Start() 
    {
        var allGameSettings = Resources.LoadAll<GameSettings>("");
        Speed = (allGameSettings[0].PlayerSpeed != 0) ? allGameSettings[0].PlayerSpeed : Speed;
        fireRate = (allGameSettings[0].ReloadGun != 0) ? allGameSettings[0].ReloadGun : fireRate;
    }
    public void Update() 
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, moveVertical, 0f) * Speed;
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }
}

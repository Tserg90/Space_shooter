using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int scoreValue;
    private GameController gameController;
    private Health health;
    private HealthMeteor healthMeteor;
    private Rigidbody rb;
    private void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            gameController = GameControllerObject.GetComponent<GameController>();
        }

        GameObject HealthBarObject = GameObject.FindWithTag( "Player" );
        if (HealthBarObject != null)
        {
            health = HealthBarObject.GetComponent<Health>();
        }

        GameObject HealthBarMeteor1Object = GameObject.FindWithTag( "Meteor1" );
        if (HealthBarMeteor1Object != null)
        {
            healthMeteor = HealthBarMeteor1Object.GetComponent<HealthMeteor>();
        }

        GameObject HealthBarMeteor2Object = GameObject.FindWithTag( "Meteor2" );
        if (HealthBarMeteor2Object != null)
        {
            healthMeteor = HealthBarMeteor2Object.GetComponent<HealthMeteor>();
        }
    }
    private void OnTriggerEnter(Collider other) {

        if(other.tag == "Player")
        {
            Destroy(gameObject);
            other.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0,0);
            other.GetComponent<Transform>().rotation = new Quaternion(0,0,0,0);
            health.ChangeHealth(-1);
        }

        if(other.tag == "Bolt")
        {
            if (healthMeteor.ChangeHealth(-1))
            {
                Destroy(gameObject);
                gameController.AddScore(scoreValue);
            }
            Destroy(other.gameObject);
        }
    }
}

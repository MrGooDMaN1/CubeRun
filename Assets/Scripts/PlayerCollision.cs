using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject completeLevelUI;
    public PlayerController movement;

    private float _timeLeft = 0.7f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall" || collision.collider.tag == "End")
        {
            Debug.Log(collision.collider.name);
            movement.enabled = false;
        }
    }

    private void Update()
    {
        if(!movement.enabled && !completeLevelUI)
        {
            _timeLeft -= Time.deltaTime;

           if (_timeLeft < 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }

    }
}

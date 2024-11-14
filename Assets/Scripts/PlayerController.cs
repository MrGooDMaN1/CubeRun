using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedForward;                               
    [SerializeField] private float _jumpHeight;                           
    [SerializeField] private GameObject _player;
    [SerializeField] private float _rayDistance;
    private bool _onHit;
    private float _timeLeft = 3.0f;

    private void Awake()
    {
        _rigidbody = _player.GetComponent<Rigidbody>();

        InputManager.OnOneFingerScreenTouched += (x) => Move(x);
        InputManager.OnTwoFingerScreenTouched += Jump;
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;

        RayOnHit();
        if (_rigidbody == null)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

        if (!_onHit)
        {
            _timeLeft -= Time.deltaTime;
            if (_timeLeft < 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }

        _rigidbody.AddForce(0, 0, _speedForward * Time.deltaTime);
    }

    private void RayOnHit()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        Debug.DrawRay(transform.position, -transform.up * _rayDistance, Color.blue);
        _onHit = Physics.Raycast(ray, _rayDistance);
    }

    private void Jump()
    {
        if (_onHit && _rigidbody != null)
            _rigidbody.AddForce(0, _jumpHeight * Time.deltaTime, 0, ForceMode.Impulse);
    }

    private void Move(float HorizontalMovement)
    {
        if (_onHit && _rigidbody != null)
        {
            int sign = Screen.width / 2 > HorizontalMovement ? -1 : 1;
            _rigidbody.MovePosition(_rigidbody.position + Vector3.right * sign * _speed * Time.fixedDeltaTime);
        }
    }
}
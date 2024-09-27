using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = _player.position + offset;
        //Камера перемещается вслед за игроком, сохраняя фиксированное смещение, заданное вектором offset
    }
}

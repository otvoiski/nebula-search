using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float Speed = 2f;
    public Transform _target;
    private Transform _player;

    internal void Setup(Func<Transform> Player)
    {
        _player = Player();
    }

    private void Update()
    {
        Moviment();
        //Rotation();
    }

    private void Rotation()
    {
        transform.LookAt(_target);
    }

    private void Moviment()
    {
        if (Input.GetKey(KeyCode.W)) _player.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
        if (Input.GetKey(KeyCode.S)) _player.Translate(new Vector3(0, 0, -(Speed * Time.deltaTime)));
        if (Input.GetKey(KeyCode.D)) _player.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.A)) _player.Translate(new Vector3(-(Speed * Time.deltaTime), 0, 0));
    }
}
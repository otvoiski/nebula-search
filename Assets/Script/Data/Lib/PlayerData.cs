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
    }
}
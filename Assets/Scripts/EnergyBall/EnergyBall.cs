using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public delegate void EnergyBallCollected();
    public static EnergyBallCollected OnEnergyBallCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        OnEnergyBallCollected?.Invoke();
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public delegate void EnergyBallCollected(GameObject obj);
    public static EnergyBallCollected OnEnergyBallCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer ("Player_1") || other.gameObject.layer == LayerMask.NameToLayer ("Player_2")){
            OnEnergyBallCollected?.Invoke(other.gameObject);
            Destroy(gameObject);
        }
    }
}

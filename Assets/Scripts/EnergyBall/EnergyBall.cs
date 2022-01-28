using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    [SerializeField]
    bool _isTop;
    public bool IsTop { get { return _isTop; } }
    public delegate void EnergyBallCollected(GameObject obj, bool IsTop);
    public static EnergyBallCollected OnEnergyBallCollected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer ("Player_1") || other.gameObject.layer == LayerMask.NameToLayer ("Player_2")){
            OnEnergyBallCollected?.Invoke(other.gameObject, IsTop);
            Destroy(gameObject);
        }
    }
}

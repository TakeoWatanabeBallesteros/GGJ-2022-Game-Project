using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    [SerializeField]
    bool _isTop;
    [SerializeField]
    float phisicInceaseFactor;
    public bool IsTop { get { return _isTop; } }
    public delegate void EnergyBallCollected(GameObject obj, bool IsTop, float incr);
    public static EnergyBallCollected OnEnergyBallCollected;
    SpriteRenderer _renderer;
    Collider2D _collider;

    ColorManager colorManager;

    private void OnEnable() {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
        GameObject CM = GameObject.FindWithTag("Color Manager");
        colorManager = CM.GetComponent<ColorManager>();
        ColorManager.OnColorSwitch += CheckBackgroundColorSwitch;
    }

    private void OnDisable() {
        ColorManager.OnColorSwitch -= CheckBackgroundColorSwitch;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer ("Player_1") || other.gameObject.layer == LayerMask.NameToLayer ("Player_2")){
            FindObjectOfType<AudioManager>().Play("Magnet");
            OnEnergyBallCollected?.Invoke(other.gameObject, IsTop, phisicInceaseFactor);
            Destroy(gameObject);
        }
    }

    void CheckBackgroundColorSwitch(){
        if(colorManager._SwitchColor){
            _renderer.enabled = false;
            _collider.enabled = false;
        }else{
            _renderer.enabled = true;
            _collider.enabled = true;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event1 : MonoBehaviour
{
    public static Action OnColorSwitch;

    private void OnEnable() {
        Event1.OnColorSwitch += Ap;
        Event1.OnColorSwitch += Ap2;
        Event1.OnColorSwitch += Ap3;
        Event1.OnColorSwitch += Ap4;
        Event1.OnColorSwitch += Ap5;
        Event1.OnColorSwitch += Ap6;
    }
    // Start is called before the first frame update
    void Start()
    {
        Event1.OnColorSwitch?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ap(){ print("Event1_1");}
      void Ap2(){ print("Event1_2");}
      void Ap3(){ print("Event1_3");}
      void Ap4(){ print("Event1_4");}
      void Ap5(){ print("Event1_5");}
      void Ap6(){ print("Event1_6");}
      void Ap7(){ print("Event1_4");}

}

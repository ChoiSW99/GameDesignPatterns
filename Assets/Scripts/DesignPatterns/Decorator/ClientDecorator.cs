using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClientDecorator : MonoBehaviour
{
    private BikeWeapon _bikeWeapon;
    private bool _isWeaponDecorated;

    void Start()
    {
        _bikeWeapon = FindObjectOfType<BikeWeapon>();
    }

    private void OnGUI()
    {
        if(!_isWeaponDecorated)
        {
            if(GUILayout.Button("Decorate Weapon"))
            {
                _bikeWeapon.Decorate();
                _isWeaponDecorated = true;
            }
        }
        else
        {
            if (GUILayout.Button("Reset Weapon"))
            {
                _bikeWeapon.ResetWeapon();
                _isWeaponDecorated = false;
            }
        }

        if(GUILayout.Button("Toggle Fire"))
            _bikeWeapon.ToggleFire();

    }
}

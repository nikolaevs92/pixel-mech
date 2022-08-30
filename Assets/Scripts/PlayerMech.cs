using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMech : Mech
{
    protected new void Start() {
        base.Start();
        UpdateModuleStats();
    }
    public TMP_Text hpTextCanvas;
    void FixedUpdate()
    {
        AddMoveForce(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));

        float rotate = 0;
        // TODO: Maybe some constant??
        if (Input.GetKey(KeyCode.Q)) {
            rotate += 1;
        }
        if (Input.GetKey(KeyCode.E)) {
            rotate -= 1;
        }

        AddAngularForce(rotate);
    }
    
    void UpdateModuleStats() {
        MechModule[] modules = GetComponentsInChildren<MechModule>();
        int sumBaseHP = 0;
        float sumHP = 0;
        float sumMaxHP = 0;
        foreach (MechModule module in modules) {
            if (module.IsBaseElement) sumBaseHP += module.CurrentHealthPoints;
            sumHP += module.CurrentHealthPoints;
            sumMaxHP += module.MaxHealthPoints;
        }
        hpTextCanvas.text = "HP: " + sumBaseHP + "\nModule condition: " + 100 * sumHP / sumMaxHP + "%";
    }
    public override void ChangeCall() {
        UpdateModuleStats();
    }
}

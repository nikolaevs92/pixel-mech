using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBot : Mech
{
    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        AddMoveForce(player.transform.position - transform.position);
        float angleToPlayer = Vector2.SignedAngle(Vector2.up, player.transform.position - transform.position) - transform.eulerAngles.z;
        if (angleToPlayer < -5f )
            AddAngularForce(-1);
        else if (angleToPlayer > 5f )
            AddAngularForce(1);
    }
    public override void ChangeCall() {
        // todo: may be do smth?
    }
}

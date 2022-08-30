using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{
    protected float accelerationForce = .3f;
    protected float accelerationTorque = 50.3f;
    private float maxVelocity = 1.0f;
    private float maxRotationVelocity = 30.0f;

    protected Rigidbody2D mechRB;

    // Start is called before the first frame update
    protected void Start()
    {
        mechRB = GetComponent<Rigidbody2D>();
    }

    protected void AddMoveForce(Vector3 move) {
        mechRB.AddForce(move.normalized * accelerationForce, ForceMode2D.Impulse);
        mechRB.velocity = mechRB.velocity.normalized * (mechRB.velocity.magnitude < maxVelocity ? mechRB.velocity.magnitude : maxVelocity);
    }

    protected void AddAngularForce(float rotate) {
        mechRB.AddTorque(rotate * Time.deltaTime * accelerationTorque, ForceMode2D.Force);
        mechRB.angularVelocity = mechRB.angularVelocity < maxRotationVelocity ?  mechRB.angularVelocity : maxRotationVelocity;
    }
    public virtual void ChangeCall() {
        // todo: may be do smth? or not virtual
    }


}

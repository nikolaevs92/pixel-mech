using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechModule : MonoBehaviour
{
    public float healthPoints;

    public float damageRespawn = 0.3f;
    [SerializeField] float damage;
    public Mech mech;
    
    // Start is called before the first frame update
    void Start()
    {
        damage = 0f;
        StartCoroutine(getDamage());
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0) {
            Destroy(gameObject);
        }
        
    }

    void UpdateHP(float differ) {
        healthPoints += differ;
        if (mech != null) {
            mech.ChangeCall(gameObject);
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("doDamage")) {
            damage += 1;
        }
    }

    IEnumerator getDamage() {
        while (true) {
            UpdateHP(-damage);
            damage = 0;
            yield return new WaitForSeconds(damageRespawn);
        }
    }
}

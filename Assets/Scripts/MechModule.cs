using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechModule : MonoBehaviour
{

    public int MaxHealthPoints;
    public GameObject damageDisplay;

    private int currentHealthPoints;
    public int CurrentHealthPoints {get {return this.currentHealthPoints;}}

    // Mech should have one base element
    public bool IsBaseElement;

    private const float damageRespawn = 0.1f;
    private int damage;
    public Mech mech;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealthPoints = MaxHealthPoints;
        damage = 0;
        StartCoroutine(getDamage());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealthPoints <= 0) {
            Destroy(gameObject);
        }
        
    }

    void UpdateHP(int differ) {
        if (differ == 0) return;
        currentHealthPoints += differ;
        if (mech != null) {
            mech.ChangeCall();
        } 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("doDamage")) {
            damage += 1;
        }
    }

    IEnumerator getDamage() {
        while (true) {
            if (damage != 0) {
                // TODO: unsafe, maybe lock damage var
                UpdateHP(-damage);
                GameObject ddInstance = Instantiate(damageDisplay, transform.position, new Quaternion(0,0,0,0));
                ddInstance.GetComponent<DamageEffects>().Run(1);
                damage = 0;
            }
            yield return new WaitForSeconds(damageRespawn);
        }
    }
}

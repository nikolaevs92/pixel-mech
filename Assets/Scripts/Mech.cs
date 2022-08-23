using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mech : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float rotationSpeed = 100.0f;

    public TMP_Text hpTextCanvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    void UpdateHP() {
        MechModule[] modules = GetComponentsInChildren<MechModule>();
        float sumHP = 0;
        foreach (MechModule module in modules) {
            sumHP += module.healthPoints;
        }
        hpTextCanvas.text = "HP: " + sumHP;
    }
    public void ChangeCall(GameObject gameObject) {
        UpdateHP();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        moveVector = moveVector.normalized * speed;
        transform.position += moveVector * Time.deltaTime * speed;

        float rotate = 0;
        if (Input.GetKey(KeyCode.Q)) {
            rotate -= 1;
        }
        if (Input.GetKey(KeyCode.E)) {
            rotate += 1;
        }
        transform.Rotate(new Vector3(0, 0, rotate * rotationSpeed * Time.deltaTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageEffects : MonoBehaviour
{
    public AudioSource hit;
    public TMP_Text childText;
    // Start is called before the first frame update

    IEnumerator StartDisappearance(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    public void Run(int damage) {
        hit.Play();
        
        childText.text = damage.ToString();
        if (damage > 100) {
            childText.GetComponent<TMPro.TextMeshProUGUI>().faceColor = Color.red;
            childText.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 32;
            StartCoroutine(StartDisappearance(2));
        } else if (damage > 10) {
            childText.GetComponent<TMPro.TextMeshProUGUI>().faceColor = Color.blue;
            childText.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 28;
            StartCoroutine(StartDisappearance(1));
        } else {
            childText.GetComponent<TMPro.TextMeshProUGUI>().faceColor = Color.white;
            childText.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 24;
            StartCoroutine(StartDisappearance(0.5f));
        }
    }
}

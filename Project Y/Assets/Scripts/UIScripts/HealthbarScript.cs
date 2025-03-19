using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    public Slider healthbar;
    public Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    private void Update()
    {
        healthbar.value = playerHealth.Player_health;
    }

}

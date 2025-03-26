using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolnessUI : MonoBehaviour
{
    public Slider coolnessBar;
    public Coolness coolness;

    // Start is called before the first frame update
    void Start()
    {
        coolness = GameObject.FindGameObjectWithTag("Player").GetComponent<Coolness>();
    }

    private void Update()
    {
        coolnessBar.value = coolness.coolness;
    }

}

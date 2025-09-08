using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchceilingdie : MonoBehaviour
{
    public GameObject gameoverui;
    // Start is called before the first frame update
    void Start()
    {
        gameoverui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            gameoverui.SetActive(true);
        }
    }
}

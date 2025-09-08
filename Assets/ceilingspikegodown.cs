using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceilingspikegodown : MonoBehaviour
{
    public Transform ceiling;
    public Transform spike;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoDown());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GoDown()
    {
        while (true)
        {
            Vector3 ceilingPos = ceiling.position;
            ceilingPos.y -= 0.01f;
            ceiling.position = ceilingPos;

            Vector3 spikePos = spike.position;
            spikePos.y -= 0.01f;
            spike.position = spikePos;

            yield return new WaitForSeconds(1.0f);
        }
    }
}

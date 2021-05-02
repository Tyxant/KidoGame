using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField]
    private GameObject gameoverObj;

    private void OnTriggerEnter(Collider other)
    {
        gameoverObj.SetActive(true);
        Destroy(other.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

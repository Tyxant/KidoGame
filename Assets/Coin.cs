using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed;
    [SerializeField]
    private AudioSource collect;

    private void OnTriggerEnter(Collider other)
    {
        Manager.score++;
        AudioSource.PlayClipAtPoint(collect.clip, transform.position);
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        collect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0));
    }
}

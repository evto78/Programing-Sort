using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public bool knockedOver;
    public List<GameObject> trash;

    void Update()
    {
        if (knockedOver)
        {
            transform.position = new Vector3(transform.position.x, 0.45f, transform.position.z);
            transform.localEulerAngles = new Vector3(0, 0, 90f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, 0.9f, transform.position.z);
            transform.localEulerAngles = Vector3.zero;
        }
    }

    public void KnockOver()
    {
        if (knockedOver) { return; }

        for(int i = 0; i < Random.Range(4, 8); i++)
        {
            int rand = Random.Range(0, 2);

            GameObject spawnedTrash = Instantiate(trash[rand]);
            spawnedTrash.transform.SetParent(null);
            spawnedTrash.transform.position = transform.position + Vector3.up * 2f;
            spawnedTrash.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
            spawnedTrash.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * 4f, ForceMode.Impulse);
        }
        

        knockedOver = true;
    }

    public void SetBackUp()
    {
        if (!knockedOver) { return; }
        knockedOver = false;
    }
}

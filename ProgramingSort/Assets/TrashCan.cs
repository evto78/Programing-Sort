using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public bool knockedOver;
    public List<GameObject> trash;

    public bool isGarbage;

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

        if (!isGarbage)
        {
            foreach (GameObject rec in GameObject.FindGameObjectsWithTag("Recycling"))
            {
                if (Vector3.Distance(rec.transform.position, transform.position) < 3f)
                {
                    Destroy(rec);
                }
            }
        }
        else
        {
            foreach (GameObject gar in GameObject.FindGameObjectsWithTag("Garbage"))
            {
                if (Vector3.Distance(gar.transform.position, transform.position) < 3f)
                {
                    Destroy(gar);
                }
            }
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

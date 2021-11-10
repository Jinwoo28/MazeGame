using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private GameObject HorizontalCube = null;
    [SerializeField] private GameObject VerticalCube = null;

    void Start()
    {
      for(int i = 0;i <= 70; i++)
        {
            int H = Random.Range(-35, 36);
            int V = Random.Range(-55, 56);
            int SH = Random.Range(1, 10);
            GameObject HCube = Instantiate(HorizontalCube, new Vector3(H, 0, V), Quaternion.identity);
            HCube.transform.localScale = new Vector3(SH, 1, 1);
        }

        for (int i = 0; i <= 70; i++)
        {
            int H = Random.Range(-35, 36);
            int V = Random.Range(-55, 56);
            int SH = Random.Range(1, 10);
            GameObject HCube = Instantiate(HorizontalCube, new Vector3(H, 0, V), Quaternion.identity);
            HCube.transform.localScale = new Vector3(1, 1, SH);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            other.GetComponent<HorizontalCube>().selfDestroy();
        }
    }

}

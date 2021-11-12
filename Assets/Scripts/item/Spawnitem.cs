using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawnitem : MonoBehaviour
{
    public Transform Cam;
    [SerializeField] RectTransform itemname = null;
    void Start()
    {
        Destroy(this.gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void SetForward()
    {
        itemname.forward = Cam.forward;
 

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("dddd");
            Eatitem(other.GetComponent<Player>());
            Destroy(this.gameObject);
        }
    }

    protected virtual void Eatitem(Player player) 
    { 
    
    }




}

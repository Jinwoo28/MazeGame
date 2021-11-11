using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnifier : Spawnitem
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetForward();
    }
    protected override void Eatitem(Player player)
    {
        player.magnifier();
    }
}

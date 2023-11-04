using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PortalSpawnScript : MonoBehaviour
{
   

    [SerializeField] int numberOfEscapePortalsLeft = 1;
    [SerializeField] float escapePortalSpawnTime = 1;

    [SerializeField] float currentTime;

    [SerializeField] Transform spawnLocationTransform;
    [SerializeField] GameObject escapePortal;

    private void Update()
    {
        if (numberOfEscapePortalsLeft > 0)
        {
            currentTime = Time.time;
            spawnEscapePortal();
        }
    }

    void spawnEscapePortal()
    {
        if(currentTime >= escapePortalSpawnTime && numberOfEscapePortalsLeft > 0) 
        {
            numberOfEscapePortalsLeft--;
            Instantiate(escapePortal, spawnLocationTransform.position, spawnLocationTransform.rotation);
          
        }
    }

   
}

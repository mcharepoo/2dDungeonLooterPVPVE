using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedEscapePortalScript : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> spriteRenderers;
    // Start is called before the first frame update
    public void disableAllPlayerSprites()
    {
        foreach (var renderer in spriteRenderers) 
        { 
            renderer.enabled = false; 
        }
    }
}

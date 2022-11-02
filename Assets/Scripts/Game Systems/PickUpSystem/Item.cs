using Inventory.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [field: SerializeField]
    public ItemSO InventoryItem { get; private set; }

    [field: SerializeField]
    public int Quantity { get; set; } = 1;
    //Quantity of the item we can pickup

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float duration = 0.3f;
    //duration of the animation of the object being picked up

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImage; 
    }
    /*We are setting that the sprite image is the same of the item*/

    public void DestroyItem()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AnimateItemPickup()); 
    }
     /*Call AnimateItemPickup so we disable the collider between the
       character and the item, play the animation and then
       destroy item in the overworld when the animation stop playing*/
    
    private IEnumerator AnimateItemPickup()
    {
        audioSource.Play();
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            transform.localScale = 
                Vector3.Lerp(startScale, endScale, currentTime / duration);
            yield return null;
        }
        Destroy(gameObject);
    }
    /*Scale the item down until its scale is 0 when our character
      picks up the item from the overworld and then, we destroy the
      item on the overworld. */
}

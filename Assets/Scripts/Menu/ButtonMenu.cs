//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.Events;
//using UnityEngine.EventSystems;

//public class ButtonMenu : MonoBehaviour
//{
//    //public Image image;
//    //public void OnPointerEnter(PointerEventData eventData)
//    //{
//    //    Debug.Log("hase");
//    //    image.sprite = GetComponent<Image>().sprite;
//    //}
//    public SpriteRenderer spriteRenderer;
//    public Sprite newSprite;

    
//    void Start()
//    {
//        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
//    }
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            ChangeSprite(newSprite);
//        }
//    }
//    void ChangeSprite()
//    {
//        spriteRenderer.sprite = newSprite;
//    }
//}
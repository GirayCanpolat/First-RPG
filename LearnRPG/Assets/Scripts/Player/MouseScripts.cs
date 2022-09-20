using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScripts : MonoBehaviour
{
    public Texture2D cursorTexture;

    private CursorMode mode = CursorMode.ForceSoftware;
    private Vector2 hotSpot = Vector2.zero;

    public GameObject mousePoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, mode);

        if (Input.GetMouseButtonUp(1))//ButtonUp; mouse tuþuna basmayý býraktýðýmýz anda çalýþtýrýr.
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//kameradan mous'un pozisyonuna doðru bir ýþýn oluþturuyoruz.
            RaycastHit hit; //Geri bilgi getirecek elemanýmýz.

            if (Physics.Raycast(ray, out hit)) //"Physics.Raycast" ile ýþýný gönder diyoruz ve parantez içinde "ray, out hit" diyerek de bunu hit olarak döndür düyoruz.
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) // Burada yere çarpan ýþýn "Ground" adlý layer mý onu kontrol ediyoruz.
                {
                    Vector3 LastPost = hit.point; // Burada "LastPost" adý altýnda mouse týkladýðý noktanýn pozisyonunu alýyorur,
                    LastPost.y = 0.35f; // Ve burada son pozisyon ne olursa olsun yerden yüksekliðini 0.35f olarak kabul ediyoruz.

                    Instantiate(mousePoint,LastPost,Quaternion.identity); //***** Verdiðimiz herhangi bir prefab i o an verdiðimiz konuma ýþýnlýyor (yoktan var ediyor), "Quaternion.identity" ile kendi rotasyonunda gelsin diyoruz  *****

                }
            }
        }
    }
}

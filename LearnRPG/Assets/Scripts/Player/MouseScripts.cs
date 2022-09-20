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

        if (Input.GetMouseButtonUp(1))//ButtonUp; mouse tu�una basmay� b�rakt���m�z anda �al��t�r�r.
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//kameradan mous'un pozisyonuna do�ru bir ���n olu�turuyoruz.
            RaycastHit hit; //Geri bilgi getirecek eleman�m�z.

            if (Physics.Raycast(ray, out hit)) //"Physics.Raycast" ile ���n� g�nder diyoruz ve parantez i�inde "ray, out hit" diyerek de bunu hit olarak d�nd�r d�yoruz.
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) // Burada yere �arpan ���n "Ground" adl� layer m� onu kontrol ediyoruz.
                {
                    Vector3 LastPost = hit.point; // Burada "LastPost" ad� alt�nda mouse t�klad��� noktan�n pozisyonunu al�yorur,
                    LastPost.y = 0.35f; // Ve burada son pozisyon ne olursa olsun yerden y�ksekli�ini 0.35f olarak kabul ediyoruz.

                    Instantiate(mousePoint,LastPost,Quaternion.identity); //***** Verdi�imiz herhangi bir prefab i o an verdi�imiz konuma ���nl�yor (yoktan var ediyor), "Quaternion.identity" ile kendi rotasyonunda gelsin diyoruz  *****

                }
            }
        }
    }
}

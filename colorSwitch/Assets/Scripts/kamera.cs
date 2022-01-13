using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public Transform topPozisyon; // topumuzun y ekseninde bir pozisyonu olduğunu belirttik

    void Update()
    {
        if (topPozisyon.position.y > transform.position.y) // eğer topum y pozisyonunda ilerlerse transform position yani
                                                           // kameranın(kamerada gözüktüğü için) y pozisyonu onu takip etsin
        {
            transform.position = new Vector3(transform.position.x, topPozisyon.position.y, transform.position.z);
            // kameramın x,y,z kısmını kontrol etmek için burayı yazdım. x,z kısmı değişmesin ama y kısmı kamerayı
            // takip etsin dedim.
        }

    }
}

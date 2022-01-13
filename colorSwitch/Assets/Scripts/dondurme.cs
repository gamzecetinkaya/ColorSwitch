using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dondurme : MonoBehaviour
{
    
       public static float donusHizi = 2; // objemiz döneceği için bir değişken yarattık

        void Update()
        {
            transform.Rotate(0f, 0f, donusHizi);  // transform.rotate nesneyi döndürmeye yarıyor. (x,y,'de döndürme, z de döndür)
                                                  // demiş olduk. 
        }
    }


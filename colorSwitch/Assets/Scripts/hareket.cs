using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class hareket : MonoBehaviour


{
    public Rigidbody2D top;
    public float ziplamaGücü;

    public Color pembeRenk, morRenk, maviRenk, sariRenk;
    public string mevcutRenk; // topun rengi
    public SpriteRenderer renkKomut; // topun sprite renderer da değiştiği rengi
    public Transform degistirici;
    public TextMeshProUGUI skorYazisi; // skrorumun gözükmesi 
    public int skor; // skorumun arttığı değişken
    public Transform kontrol1, kontrol2, kontrol3, cember, kare, double_cember;
    public AudioSource ziplamaSesi;
    
    

    void Start() // sadece oyun başlangıcında çalışıcak kodlar
    {
        dondurme.donusHizi = 2;
        RastgeleRenk();
    }

    void Update() //oyunda sürekli çalışacak kodlar yazılır
    {
        skorYazisi.text = "Skor : " + skor; // tutulan skorum skor yazısı kısmında güncellenicek
        if (Input.GetKeyDown(KeyCode.Space))  //Input ile kullanıcıdan giriş aldım. get key down ile tuşa bastığı an
                                              // top zıplayacak tuş seçeneği olarakta space i belirledim. 
        {
            top.velocity = Vector2.up * ziplamaGücü; // velocity ile topun hızını belirliyorum. Vector2, oyunun yerini belirler 
                                                     // ve up dersek yukarı doğru zıplamaya başlar. * ziplama gücü ise topun ne
                                                     // kadar zıplayacağını belirlediğimiz kısım.
            ziplamaSesi.Play(); //space e basıldığında zıplama sesimiz aktif olcak

        }


    }

    void OnTriggerEnter2D(Collider2D temas)
    {
        if (temas.tag != mevcutRenk && temas.tag != "RenkDegistirici" && temas.tag != "Kontrol1" && temas.tag != "Kontrol2" && temas.tag != "Kontrol3") // temasta olan renk mevcut rengimiz değilse ve temas ettiğimiz nesne renk değiştirici değilse
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // üzerinde çalıştığımız sahneyi yeniden başlat anlamına gelen bir kod. 
        }

        if (temas.tag == "RenkDegistirici") // eğer renk değiştiriciye temas edersek 
        {
            skor++;
            // Destroy(temas.gameObject); // ve renk değiştirici nesnesini yok et (yeni rengi aldığımız an kayboluyor)
            degistirici.position = new Vector3(degistirici.position.x, degistirici.position.y + 13f, degistirici.position.z);
            // değiştiricimin pozisyonu yeni bir boyutta x,z aynı kalsın ama y alanında +6.5 yükselsin.
            RastgeleRenk(); // oyuna devam et
            if(skor == 10)
            {
                dondurme.donusHizi += 0.2f;
            }

        }

        if(temas.tag == "Kontrol1")
        {
            kontrol1.position = new Vector3(kontrol1.position.x, kontrol1.position.y + 39f, kontrol1.position.z);
            cember.position = new Vector3(cember.position.x, cember.position.y + 39f, cember.position.z);

        }

        if (temas.tag == "Kontrol2")
        {
            kontrol2.position = new Vector3(kontrol2.position.x, kontrol2.position.y + 39f, kontrol2.position.z);
            kare.position = new Vector3(kare.position.x, kare.position.y + 39f, kare.position.z);

        }

        if (temas.tag == "Kontrol3")
        {
            kontrol3.position = new Vector3(kontrol3.position.x, kontrol3.position.y + 39f, kontrol3.position.z);
            double_cember.position = new Vector3(double_cember.position.x, double_cember.position.y + 39f, double_cember.position.z);

        }

    }


    void RastgeleRenk()
    {
        int rastgele = Random.Range(0, 4); // 0'la 3 arası (bizim 4 rengimiz olduğu için) değer vericek ve rastgele renk vermiş olcak

        switch (rastgele)
        {
            case 0:
                mevcutRenk = "Pembe";   //mevcut rengimi pembe seçtiğimde 
                renkKomut.color = pembeRenk;  // renk komutuyla sprite rendererda rengi pembeye boya
                break;
            case 1:
                mevcutRenk = "Mor";
                renkKomut.color = morRenk;
                break;
            case 2:
                mevcutRenk = "Mavi";
                renkKomut.color = maviRenk;
                break;
            case 3:
                mevcutRenk = "Sarı";
                renkKomut.color = sariRenk;
                break;


        }

    }
}



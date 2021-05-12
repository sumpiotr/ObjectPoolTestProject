using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public uint life;

    private AudioSource audioSource;

    [SerializeField]
    private Text lifeText;

    private bool fireButtonDown;
    private bool canShoot;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fireButtonDown = false;
        life = 3;
        canShoot = true;
    }


    void Update()
    {
        GetInput();
    }

    private void GetInput() 
    {

        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        pz.y = transform.position.y;
        gameObject.transform.position = pz;

        if (!canShoot) return;
        float fireInput = Input.GetAxisRaw("Fire1");
        if (Mathf.Abs(fireInput) > 0.1)
        {
            if (fireButtonDown) return;
            fireButtonDown = true;
            GameManager.gameManager.bulletPool.SpawnObject(new Vector2(transform.position.x, transform.position.y + 1f));
            audioSource.Play();
            canShoot = false;
            Invoke("SetCanShootTrue", 0.3f);
        }
        else 
        {
            fireButtonDown = false;
        }
    }

    private void SetCanShootTrue() 
    {
        canShoot = true;
    }

    public void TakeDamage() 
    {
        life--;
        lifeText.text = $"x{life}";
        if (life == 0) 
        {
            GameManager.gameManager.End();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public Text ammoLeftText;
    public Text ammoCapacityText;
    public float ammoLeftAmount;
    private float ammoCapacityAmount = 17f;
    [SerializeField] private PrototypeGun prototypeGunScript;

    private void Awake()
    {
        //Seeking the prototypegunscript within the active scene
        prototypeGunScript = FindObjectOfType<PrototypeGun>();
        //Setting the ammo capacity text to the guns ammo capactiy
        ammoCapacityText.text = ammoCapacityAmount.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Setting the float within this script to equal the bullet amount left in the prototype gun script
        ammoLeftAmount = prototypeGunScript.bulletsLeft;
        //Setting the ammoleftText to the text and so it can be updated every frame
        ammoLeftText.text = ammoLeftAmount.ToString();
    }
}

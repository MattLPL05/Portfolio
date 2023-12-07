using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunPlayerHandler : MonoBehaviour
{
	//define in-engine values and object
    [SerializeField]
    private GameObject SelfGun;
    [SerializeField]
    private GameObject AimingGun;
    [SerializeField]
    private Transform BulletGeneratorPoint;
    [SerializeField]
    private GameObject Thebullet;
    [SerializeField]
    private TextMeshProUGUI BulletUIAmount;
    [SerializeField]
    private int Cooldown = 4;
    [SerializeField]
    private int BulletAmout = 0;
    [SerializeField]
    private AudioClip FiringSound;
    [SerializeField]
    private AudioClip AfterSound;
    [SerializeField]
    private AudioClip BulletLackSound;
    [SerializeField]
    private bool IsAimingVersion;
    [SerializeField]
    private bool IsAllowedToFire;

    private GameObject clone; // private clone to spawn the bullets of the gun


    private void OnEnable() // function executes itself upon gameobject being enabled (equipped)
    {
       // StartCoroutine(NaturalBatteryDrainIE());
        //added to OnEnable function to update every time player collects bullets on any of the maps.
        BulletAmout = GameObject.Find("CurrentPlayerInventory").GetComponent<PlayerInventoryHandler>().GunRemainingBulletAmount;
        CheckforFiringPermission();
        BulletUIAmount.text = "Remaining Ammo: " + BulletAmout; // Update UI
    }

    public void UpdateBulletAmountInfo() // updates the amounts of bullets player has in their inventory
    {
        BulletAmout = GameObject.Find("CurrentPlayerInventory").GetComponent<PlayerInventoryHandler>().GunRemainingBulletAmount;
    }


    // Start is called before the first frame update
    void Start() // no longer used. left for debug purposes
    {
       // BulletUIAmount.text = "Remaining Ammo: " + BulletAmout;
    }

    private void CheckforFiringPermission() // checks if player is allowed to even shoot
    {
        if(BulletAmout  == 0)
        {
            IsAllowedToFire = false;
        }
        else
        {
            IsAllowedToFire = true;
        }
    }

    private void FirePrimary() // responsible for shooting
    {
        if(IsAllowedToFire == true) // does the spawning of the bullet
        {
            clone = Instantiate(Thebullet);
            clone.transform.position = BulletGeneratorPoint.transform.position;
            clone.transform.rotation = BulletGeneratorPoint.transform.rotation;
            //removing the bullet
            BulletAmout = BulletAmout - 1;
            BulletUIAmount.text = "Remaining Ammo: " + BulletAmout;
            GameObject.Find("CurrentPlayerInventory").GetComponent<PlayerInventoryHandler>().GunRemainingBulletAmount = BulletAmout;
            UpdateBulletAmountInfo();
            AudioSource.PlayClipAtPoint(FiringSound, BulletGeneratorPoint.transform.position);
            StartCoroutine(PlayAfterEffect());
            CheckforFiringPermission();
        }
        if(IsAllowedToFire == false)// plays a sound if no bullets are remaining
        {
            CheckforFiringPermission();
            AudioSource.PlayClipAtPoint(BulletLackSound, BulletGeneratorPoint.transform.position);
        }
       
       // StartCoroutine(SpawnTheThing());
    }

     private void CheckAiming() // check the current state of the gun
    {
       if(IsAimingVersion == false)
       {
            SelfGun.SetActive(false);
            AimingGun.SetActive(true);
       }
       if(IsAimingVersion == true)
       {
            SelfGun.SetActive(true);
            AimingGun.SetActive(false);
       }
    }

    // Update is called once per frame
    void Update() // waits for user's input
    {
        if(Input.GetButtonDown("Fire1"))
        {
            FirePrimary();
        }
         if(Input.GetButtonDown("Fire2"))
        {
            CheckAiming();
        }


    }

    void FixedUpdate() // no longer used, left for debug purposes
    {
        //Updates progressTracker to make sure it has the correct info
      //  GameObject.Find("GameProgressing").GetComponent<SpecialProgressTracker>().GunRemainingBulletAmount = BulletAmout;
    }

    private IEnumerator PlayAfterEffect() // plays an additiona sound effect exacly one second after the bullet is spawned.
    {
        yield return new WaitForSecondsRealtime(1);
        AudioSource.PlayClipAtPoint(AfterSound, BulletGeneratorPoint.transform.position);
       
    }
}

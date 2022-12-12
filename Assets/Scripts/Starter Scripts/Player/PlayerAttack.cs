using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player Weapons")]
    [Tooltip("This is the list of all the weapons that your player uses")]
    public List<Weapon> weaponList;
    [Tooltip("This is the current weapon that the player is using")]
    public Weapon weapon;
    private Vector3 lastKnownDirection;
    [Tooltip("The coolDown before you can attack again")]
    public float coolDown = 0.4f;

    private bool canAttack = true;
    public GameObject player;


    private void Start()
    {
        if (weapon == null && weaponList.Count > 0)
        {
            weapon = weaponList[0];
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))//Here is where you can hit the "1" key on your keyboard to activate this weapon
        {
            if (weaponList.Count > 0)
            {
                switchWeaponAtIndex(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))//Remove this if you don't have multiple weapons
        {
            if (weaponList.Count > 1)
            {
                switchWeaponAtIndex(1);
            }
        }
    }

    public bool Attack(Vector3 scale)
    {
        //This is where the weapon is rotated in the right direction that you are facing
        if (weapon && canAttack)
        {
            if (weapon.weaponType == Weapon.WeaponType.Melee)
            {
                weapon.WeaponStart();
            }

            else
            {
                float angle = -(Mathf.Atan2(scale.x, scale.y) * Mathf.Rad2Deg);
                GameObject projectile = Instantiate(weapon.projectile, weapon.shootPosition.position, Quaternion.AngleAxis(angle, Vector3.forward));
                projectile.transform.localScale = new Vector3((float)(1 + 0.8 * persistence.instance.level), (float)(1+0.5*persistence.instance.level), 1);
                projectile.GetComponent<Projectile>().SetValues(weapon.duration, weapon.alignmnent, weapon.damageValue);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
                rb.AddForce(scale * weapon.force);

            }
            
            StartCoroutine(CoolDown());
            return true;
        }
        return false;
    }

    public void StopAttack()
    {
        if (weapon)
        {
            weapon.WeaponFinished();
        }
    }

    public void switchWeaponAtIndex(int index)
    {
        //Makes sure that if the index exists, then a switch will occur
        if (index < weaponList.Count && weaponList[index])
        {
            //Deactivate current weapon
            weapon.gameObject.SetActive(false);

            //Switch weapon to index then activate
            weapon = weaponList[index];
            weapon.gameObject.SetActive(true);
        }

    }

    private IEnumerator CoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(coolDown - (float)(0.03 * persistence.instance.level));
        canAttack = true;
    }
}

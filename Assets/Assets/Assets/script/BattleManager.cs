using UnityEngine;

public class BattleManager : MonoBehaviour
{
    //Both player and enemy health  
    public float playerHealth = 100f;
    public float enemyHealth = 100f;

    //both player and enemy damage will deal
    public float playerDamage = 10f;
    public float enemyDamage = 20f;

    //shield effect
    public bool playerShieldActive = false;
    public bool enemyShieldActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void SwordAttack()
    {
        float damage = playerDamage * 1.5f;

        if (enemyShieldActive)
        {
            damage *= 0.5f;
            enemyShieldActive = false;
        }


        enemyHealth -= damage;

        Debug.Log("Sword attack did " + damage + "Damage.");
        Debug.Log("Enemy Health is now" + enemyHealth);
    }




    public void EnemyAttack()
    {
        float damage = enemyDamage * 1.5f;

        if(playerShieldActive)
        {
            damage *= 0.5f;
            playerShieldActive = false;
        }
        playerHealth -= damage;

        Debug.Log("Enemy dealt" + damage + "damage.");
        Debug.Log("player health is now" +  playerHealth);
    }



    public void playerShield()
    {
        playerShieldActive = true;
        Debug.Log("player shield Active!");
    }





    public void enemyShield()
    {
        enemyShieldActive = true;
        Debug.Log("Enemy shirld activated!");
            
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            SwordAttack();
        }

        if (Input.GetKeyDown(KeyCode.O))

        {
            playerShield();
        }

        if (Input.GetKeyDown(KeyCode.I))

        {
            EnemyAttack();
        }

        if (Input.GetKeyDown(KeyCode.U))

        {
            enemyShield();
        }
      


    }
}

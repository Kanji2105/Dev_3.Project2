using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    public Rigidbody rb;

    public float rollForce = 5f; //throws the dice upward 

    public float torqueForce = 10f;  // makes it spin 

    public Transform[] swordFaces;
    public Transform[] shieldFaces;

    public bool isRolling = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RollDice();
        }

        if (isRolling && rb.linearVelocity.magnitude < 0.1f && rb.angularVelocity.magnitude < 0.1f)
        {
            isRolling = false;
            CheckResult();
        }
    }

    void RollDice()
    {
        rb.AddForce(Vector3.up * rollForce, ForceMode.Impulse);

        isRolling =true;

        rb.AddTorque(
            Random.Range(-torqueForce, torqueForce),
            Random.Range(-torqueForce, torqueForce),
            Random.Range(-torqueForce, torqueForce),
            ForceMode.Impulse
        );
    }
    // it gives Ramdom so it not the same thing over and over again 

    void CheckResult()
    {
        Debug.Log("Sword faces: " + swordFaces.Length + " Shield faces: " + shieldFaces.Length);
        float highestY = float.MinValue;
        string result = "";

        foreach (Transform face in swordFaces)
        {
            if (face.position.y > highestY)
            {
                highestY = face.position.y;
                result = "Sword";
            }
        }

        foreach (Transform face in shieldFaces)
        {
            if (face.position.y > highestY)
            {
                highestY = face.position.y;
                result = "Shield";
            }
        }

        Debug.Log("Dice result: " + result);
    }
}
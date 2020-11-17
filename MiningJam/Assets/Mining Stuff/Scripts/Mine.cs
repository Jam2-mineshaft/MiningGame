using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Mine : MonoBehaviour
{
    [Header("Setup")]
    public int whatPlayerIsThis;
    public float mineReach;
    public MinableObjectsSO coalSettings;
    public MinableObjectsSO goldSettings;
    public int currentCoal;
    public int currentGold;
    //public Text coalText;
    public Text goldText;

    [Header("Audio Setup")]
    public GameObject audioManager;

    RaycastHit hit;
    RaycastHit[] hits;

    private void Update()
    {
        MineObject();
    }

    void MineObject()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * mineReach);

        if (whatPlayerIsThis == 0)
        {
            // Coal Functionality
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, mineReach) && hit.transform.tag == "Coal") // Casts a ray from the player and checks tag
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0)) // If player presses correct input then add value to coal, change UI text and destroy the coal block
                {
                    currentCoal += coalSettings.valueToGive;
                    //coalText.text = currentCoal.ToString();
                    Instantiate(coalSettings.destructionParticles, hit.transform.position, Quaternion.identity);
                    audioManager.GetComponent<PlayAudio>().PlayCoalAudio(); // Plays mining audio
                    Destroy(hit.transform.gameObject);
                }
            }

            // Gold Functionality
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, mineReach) && hit.transform.tag == "Gold") // Casts a ray from the player and checks tag
            {
                if (Input.GetKeyDown(KeyCode.Joystick1Button0)) // If player presses correct input then add value to coal, change UI text and destroy the coal block -- CHANGE SO IT FUNCTIONS WITH EACH PLAYER'S JOYSTICK
                {
                    currentGold += goldSettings.valueToGive;
                    goldText.text = currentGold.ToString();
                    Instantiate(goldSettings.destructionParticles, hit.transform.position, Quaternion.identity);
                    audioManager.GetComponent<PlayAudio>().PlayGoldAudio(); // Plays mining audio
                    Destroy(hit.transform.gameObject);
                }
            }
        }

        if (whatPlayerIsThis == 1)
        {
            // Coal Functionality
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, mineReach) && hit.transform.tag == "Coal") // Casts a ray from the player and checks tag
            {
                if (Input.GetKeyDown(KeyCode.Joystick2Button0)) // If player presses correct input then add value to coal, change UI text and destroy the coal block
                {
                    currentCoal += coalSettings.valueToGive;
                    //coalText.text = currentCoal.ToString();
                    Instantiate(coalSettings.destructionParticles, hit.transform.position, Quaternion.identity);
                    audioManager.GetComponent<PlayAudio>().PlayCoalAudio(); // Plays mining audio
                    Destroy(hit.transform.gameObject);
                }
            }

            // Gold Functionality
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, mineReach) && hit.transform.tag == "Gold") // Casts a ray from the player and checks tag
            {
                if (Input.GetKeyDown(KeyCode.Joystick2Button0)) // If player presses correct input then add value to coal, change UI text and destroy the coal block -- CHANGE SO IT FUNCTIONS WITH EACH PLAYER'S JOYSTICK
                {
                    currentGold += goldSettings.valueToGive;
                    goldText.text = currentGold.ToString();
                    Instantiate(goldSettings.destructionParticles, hit.transform.position, Quaternion.identity);
                    audioManager.GetComponent<PlayAudio>().PlayGoldAudio(); // Plays mining audio
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}

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

    public Text goldText;

    [Header("Audio Setup")]
    public GameObject audioManager;

    [Header("Ore Chunks")]
    public GameObject gold_chunk;
    public GameObject coal_chunk;

    Cart cart;

    private void Start()
    {
        cart = transform.parent.GetComponent<Cart>();
    }

    private Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    public void MineObject(GameObject go)
    {
        if (go.CompareTag("Gold_Ore"))
        {
            currentGold += goldSettings.valueToGive;
            goldText.text = currentGold.ToString();

            //Dispose of Ore
            Instantiate(goldSettings.destructionParticles, go.gameObject.transform.position, Quaternion.identity);
            audioManager.GetComponent<PlayAudio>().PlayGoldAudio(); // Plays mining audio

            //Spawn Chunk
            if (whatPlayerIsThis == 0)
            {
                Instantiate(gold_chunk, RandomPointInBounds(cart.side_A_area.bounds), Quaternion.identity);
            }

            else if (whatPlayerIsThis == 1)
            {
                Instantiate(gold_chunk, RandomPointInBounds(cart.side_B_area.bounds), Quaternion.identity);
            }
        }

        else if (go.CompareTag("Coal_Ore"))
        {
            //currentCoal += coalSettings.valueToGive;

            //Dispose of Ore
            Instantiate(coalSettings.destructionParticles, go.gameObject.transform.position, Quaternion.identity);
            audioManager.GetComponent<PlayAudio>().PlayCoalAudio(); // Plays mining audio

            //spawn Chunk
            if (whatPlayerIsThis == 0)
            {
                Instantiate(coal_chunk, RandomPointInBounds(cart.side_A_area.bounds), Quaternion.identity);
            }
            else if (whatPlayerIsThis == 1)
            {
                Instantiate(coal_chunk, RandomPointInBounds(cart.side_B_area.bounds), Quaternion.identity);
            }
        }

        Destroy(go);

        #region harry's code
        /*
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
                            //goldText.text = currentGold.ToString();
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
                            //goldText.text = currentGold.ToString();
                            Instantiate(goldSettings.destructionParticles, hit.transform.position, Quaternion.identity);
                            audioManager.GetComponent<PlayAudio>().PlayGoldAudio(); // Plays mining audio
                            Destroy(hit.transform.gameObject);
                        }
                    }
                }
                */
        #endregion
    }
}

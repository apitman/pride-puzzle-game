using UnityEngine;
using UnityEngine.UI;

public class VictoryTextDisplay : MonoBehaviour
{
    public GameObject player;
    public Transform goalTform;
    public Text winText;

    // Update is called once per frame
    void Update()
    {
        Transform playerTform = player.transform;
        if (Mathf.Abs(playerTform.position.x - goalTform.position.x) < 0.1 && Mathf.Abs(playerTform.position.y - goalTform.position.y) < 0.1)
        {
            // Turn the text on and disable the player's controls
            winText.enabled = true;
            player.GetComponent<playerMovement>().disableControls = true;
        }
    }
}

using UnityEngine;
using DialogueEditor;
public class lift_alert : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    [SerializeField] private NPCConversation mylift_alert;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ConversationManager.Instance.StartConversation(mylift_alert);
        }
    }

}




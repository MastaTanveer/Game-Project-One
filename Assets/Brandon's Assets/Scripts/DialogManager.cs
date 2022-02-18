using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    private GameObject Player;
    public Queue <string> sentences;
    public Animator anim;
    //public Animator faceAnim;
    void Start()
    {
        sentences = new Queue<string>();
        Player = GameObject.Find("Player");
    }

    public void StartDialog (Dialog dialog)
    {
        //faceAnim.SetTrigger("Talk");
        anim.SetBool("isOpen", true);
        nameText.text = dialog.name;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            Player.GetComponent<PlayerScript>().moveSpeed = 5;
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
        // faceAnim.SetTrigger("Talk");

    }
    void EndDialog()
    {
        Debug.Log("End of conversation");
        anim.SetBool("isOpen", false);
    }
    
    
}

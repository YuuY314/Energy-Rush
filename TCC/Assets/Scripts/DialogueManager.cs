using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Image profilePicture;
    public Text actorNameText;
    public Text dialogueText;

    public float typingSpeed;
    private string[] sentences;
    private int index;

    public static bool hasDialogue = true;

    public Player player;

    public void Dialogue(Sprite profile, string actorName, string[] txt)
    {
        dialogueBox.SetActive(true);
        profilePicture.sprite = profile;
        actorNameText.text = actorName;
        sentences = txt;
        StartCoroutine(TypeSentence());

        if(actorName == "Máquina de Vendas"){
            RandomVoiceLineVendingMachine();
        }
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if(dialogueText.text == sentences[index]){
            if(index < sentences.Length - 1){
                index++;
                dialogueText.text = "";
                StartCoroutine(TypeSentence());
                RandomVoiceLineVendingMachine();
            } else {
                dialogueText.text = "";
                index = 0;
                dialogueBox.SetActive(false);
                hasDialogue = false;
                player.enabled = true;
            }
        }
    }

    private void RandomVoiceLineVendingMachine()
    {
        int sort = Random.Range(1, 100);
        Debug.Log(sort);
        if(sort <= 50){
            GameLogic.instance.vendingMachineVoice1.Play();
        } else {
            GameLogic.instance.vendingMachineVoice2.Play();
        }
    }
}

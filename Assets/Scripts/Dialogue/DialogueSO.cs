using UnityEngine;
[CreateAssetMenu(fileName = "New Dialogue", menuName = "Data/Dialogue")]
public class DialogueSO : ScriptableObject
{
    [System.Serializable]
    public class Dialogue
    {
        public DialogueCharacter character;
        public string text;
    }
    public Dialogue[] dialogueList;
}

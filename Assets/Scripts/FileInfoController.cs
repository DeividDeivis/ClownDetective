using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileInfoController : MonoBehaviour
{
    [SerializeField] private Image npcFolder;
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI npcYears;
    [SerializeField] private TextMeshProUGUI npcJob;
    [SerializeField] private TextMeshProUGUI npcDescription;

    public void SetFileInfo(CharacterData data) 
    {
        npcFolder.sprite = data.npcFolder;
        npcName.text = data.Name;
        npcYears.text = $"Edad: {data.Age}";
        npcJob.text = $"Ocupación: {data.Occupation}";
        npcDescription.text = data.Description;
    }
}

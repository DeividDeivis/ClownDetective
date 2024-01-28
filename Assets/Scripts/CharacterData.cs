using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Personajes")]
public class CharacterData : ScriptableObject
{
    // 3 sprites de estado, nombre, edad, ocupacion, descripcion, tematica ganadora, genero ganador, lista de sustantivos, sustantivo correcto)
    public string Name;
    public string Age;
    public string Occupation;
    public List<string> Nouns;

    
    public Sprite Normal;
    public Sprite Smile;
    public Sprite Laugh;

    public JokeTheme CorrectJokeTheme;
    public JokeGenre CorrectJokeGenre;
    public string CorrectNoun;
       
}

[System.Serializable]
public enum JokeTheme
{
    Politics,
    Job,
    Health,
    Economy,
    Religion,
    PR,
}
[System.Serializable]
public enum JokeGenre
{
    Humor_negro,
    Humor_irreverente,
    Humor_inteligente,
    Humor_absurdo,
    Humor_fisico,
    Dad_joke
}

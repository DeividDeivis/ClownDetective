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
    [TextArea(3, 5)]public string Description;
    public List<string> Nouns;

    public Sprite Picture;

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
    Politica,
    Trabajo,
    Salud,
    Economia,
    Religion,
    Familia,
}
[System.Serializable]
public enum JokeGenre
{
    negro,
    irreverente,
    inteligente,
    absurdo,
    fisico,
    DadJoke
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    public int skinNr;

    public Skins[] skins;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(skinNr > skins.Length-1) skinNr = 0;
        else if(skinNr < 0) skinNr = skins.Length-1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SkinChoice();
    }

    void SkinChoice()
    {
        if(spriteRenderer.sprite.name.Contains("char1_walk_0"))
        {
            string spriteName = spriteRenderer.sprite.name;
            spriteName = spriteName.Replace("char1_walk_", "");
            int spriteNr = int.Parse(spriteName);

            spriteRenderer.sprite = skins[skinNr].sprites[spriteNr];
        }
    }
}

[System.Serializable]
public struct Skins
{
    public Sprite[] sprites;
}

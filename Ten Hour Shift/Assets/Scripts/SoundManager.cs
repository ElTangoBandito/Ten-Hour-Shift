using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource lobbyMusic;
    public AudioSource lobbyNoise;
    public AudioSource mabelRadio;
    public AudioSource michaelCough;
    public AudioSource michaelRadio;
    public AudioSource doloresCough;
    public AudioSource doloresRadio;
    public AudioSource doloresHeartBeat;
    private int currentRoom = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int roomNumber = Globals.roomNumber;
        if(currentRoom != roomNumber)
        {
            muteSounds();
        }
        currentRoom = roomNumber;
        // 1 Hallway
        // 2 Michael
        // 3 Mabel
        // 4 Dolores
        // 5 Breakroom
        // 6 Visiting room
        switch (roomNumber)
        {
            case 1:
                lobbyMusic.volume = 1;
                lobbyNoise.volume = 1;
                break;
            case 2:
                lobbyMusic.volume = 0.5f;
                lobbyNoise.volume = 0.5f;
                if (!Globals.randomSoundPlayed && Globals.randomSoundGenerator == 1)
                {
                    michaelCough.mute = false;
                    michaelCough.Play();
                    Globals.randomSoundPlayed = true;
                }
                else if (!Globals.randomSoundPlayed && Globals.randomSoundGenerator == 2)
                {
                    michaelRadio.mute = false;
                    michaelRadio.Play();
                    Globals.randomSoundPlayed = true;
                }
                break;
            case 3:
                lobbyMusic.volume = 0.5f;
                lobbyNoise.volume = 0.5f;
                if (!Globals.randomSoundPlayed && Globals.randomSoundGenerator == 1)
                {
                    mabelRadio.mute = false;
                    mabelRadio.Play();
                    Globals.randomSoundPlayed = true;
                }
                break;
            case 4:
                lobbyMusic.volume = 0.5f;
                lobbyNoise.volume = 0.5f;
                if (!Globals.randomSoundPlayed && Globals.randomSoundGenerator == 1)
                {
                    doloresCough.mute = false;
                    doloresCough.Play();
                    Globals.randomSoundPlayed = true;
                }
                else if (!Globals.randomSoundPlayed && Globals.randomSoundGenerator == 2)
                {
                    doloresHeartBeat.mute = false;
                    doloresHeartBeat.Play();
                    Globals.randomSoundPlayed = true;
                }
                else if (!Globals.randomSoundPlayed && Globals.randomSoundGenerator == 2)
                {
                    doloresRadio.mute = false;
                    doloresRadio.Play();
                    Globals.randomSoundPlayed = true;
                }
                break;
            case 5:
                lobbyMusic.volume = 0.5f;
                lobbyNoise.volume = 0;
                break;
            case 6:
                lobbyMusic.volume = 0.3f;
                lobbyNoise.volume = 0;
                break;
        }
    }

    void muteSounds()
    {
        mabelRadio.mute = true;
        michaelCough.mute = true;
        michaelRadio.mute = true;
        doloresCough.mute = true;
        doloresRadio.mute = true;
        doloresHeartBeat.mute = true;
}
}

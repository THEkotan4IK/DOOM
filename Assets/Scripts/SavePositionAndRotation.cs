using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavePositionAndRotation: MonoBehaviour
{
    void Start()
    {
        LoadTransform();
    }

    private void SavePlayerTransform()
    {
        PlayerData saveTransform = new PlayerData(transform.position, transform.rotation.eulerAngles);

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/savetransform.dat");

        bf.Serialize(file, saveTransform);
        file.Close();
    }

    private void LoadTransform()
    {
        if (File.Exists(Application.persistentDataPath + "/savetransform.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savetransform.dat", FileMode.Open);
            PlayerData saveTransform = (PlayerData)bf.Deserialize(file);
            transform.position = saveTransform.playerPosition.GetVector3();
            transform.rotation = Quaternion.Euler(saveTransform.playerRotation.GetVector3());
            file.Close();
        }
    }
    private void OnDestroy()
    {
        SavePlayerTransform();
    }
}

[Serializable]
public struct MyVector3
{
    public float x;
    public float y;
    public float z;

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3 GetVector3()
    {
        return new Vector3(x, y, z);
    }
}

[Serializable]
public class PlayerData
{
    public MyVector3 playerPosition;
    public MyVector3 playerRotation;

    public PlayerData(Vector3 pos, Vector3 rot)
    {
        this.playerPosition = new MyVector3(pos.x, pos.y, pos.z);
        this.playerRotation = new MyVector3(rot.x, rot.y, rot.z);
    }
}

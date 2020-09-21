using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolePool : MonoBehaviour
{

    [SerializeField]
    private MoleEnemy mole;

    private Queue<MoleEnemy> moleQueue = new Queue<MoleEnemy>();

    public static MolePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public MoleEnemy GetMole()
    {
        if (moleQueue.Count == 0)
        {
            AddMoles(1);
        }

        return moleQueue.Dequeue();
    }

    private void AddMoles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            MoleEnemy tempMole = Instantiate(mole);
            tempMole.gameObject.SetActive(false);
            moleQueue.Enqueue(tempMole);
        }
    }

    public void ReturnToPool(MoleEnemy moleEnemy)
    {
        moleEnemy.gameObject.SetActive(false);
        moleQueue.Enqueue(moleEnemy);
    }

}

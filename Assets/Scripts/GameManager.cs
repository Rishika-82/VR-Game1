using UnityEngine;

public class GameManager : MonoBehaviour
{
    //cube objects
    [SerializeField] private CubeInteractable[] cubes;

    private void Start()
    {
        //func to generate random cubes
        int randomIndex = Random.Range(0, cubes.Length);

        for (int i = 0; i < cubes.Length; i++)
        {
            //some random index given to a cube and that is correct
            cubes[i].isCorrectCube = (i == randomIndex);
        }
    }
}
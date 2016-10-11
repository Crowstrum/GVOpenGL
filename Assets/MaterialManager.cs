using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    public Cubemap[] gemMaterials;
    public Transform Head;
    public int headMetalIndex;
    public MeshRenderer Metal;
    public int metalMaterialIndex;
    public Cubemap[] metalMaterials;
    public MeshRenderer PrimaryGem;
    public int primaryGemIndex;
    public MeshRenderer SecondaryGem;
    public int secondaryGemIndex;
    public Cubemap startingGem;

	public Text PrimaryGemText;
	public Text SecondaryGemText;
	public Text PrimaryMetalText;
	public Text SecondaryMetalText;

	public Camera main;

	public void IncrementPrimaryGemIndex(){
		primaryGemIndex++;
	}
	public void DecrementPrimaryGemIndex(){
		primaryGemIndex--;
	}

	public void IncrementSecondaryGemIndex(){
		secondaryGemIndex++;
	}
	public void DecrementSecondaryGemIndex(){
		secondaryGemIndex--;
	}

	public void IncrementPrimaryMetalIndex(){
		metalMaterialIndex++;
	}
	public void DecrementPrimaryMetalIndex(){
		metalMaterialIndex--;
	}

	public void IncrementSecondaryMetalIndex(){
		headMetalIndex++;
	}
	public void DecrementSecondaryMetalIndex(){
		headMetalIndex--;
	}


    // Use this for initialization
    private void Start()
    {
        var startingGemMat = startingGem;
        PrimaryGem.material.SetTexture("_Cube", startingGemMat);
        SecondaryGem.material.SetTexture("_Cube", startingGemMat);
    }

    // Update is called once per frame
    private void Update()
    {
		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			main.orthographicSize--;
			if (main.orthographicSize < 11) {
				main.orthographicSize = 11;
			}
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			main.orthographicSize++;

		}
		
        if (Input.GetKeyDown(KeyCode.Q))
        {
            primaryGemIndex++;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            primaryGemIndex--;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            secondaryGemIndex++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            secondaryGemIndex--;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            metalMaterialIndex++;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            metalMaterialIndex--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            headMetalIndex++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            headMetalIndex--;
        }

        PrimaryGem.material.SetTexture("_Cube", GetCMapAtIndex(ref primaryGemIndex, gemMaterials));
        SecondaryGem.material.SetTexture("_Cube", GetCMapAtIndex(ref secondaryGemIndex, gemMaterials));
        Metal.materials.ToList()
            .ForEach(_ => _.SetTexture("_Cube", GetCMapAtIndex(ref metalMaterialIndex, metalMaterials)));


        foreach (Transform head in Head)
        {
            head.GetComponent<Renderer>()
                .materials.ToList()
                .ForEach(_ => _.SetTexture("_Cube", GetCMapAtIndex(ref headMetalIndex, metalMaterials)));
        }

		PrimaryGemText.text = gemMaterials [primaryGemIndex].name;
		SecondaryGemText.text = gemMaterials [secondaryGemIndex].name;
		PrimaryMetalText.text = metalMaterials [metalMaterialIndex].name;
		SecondaryMetalText.text = metalMaterials [headMetalIndex].name;
    }

    private Cubemap GetCMapAtIndex(ref int index, Cubemap[] collections)
    {
        if (index < 0)
        {
            index = collections.Length - 1;
        }
        if (index > collections.Length - 1)
        {
            index = 0;
        }
        return collections[index];
    }


}
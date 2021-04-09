using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class MapBuilder : MonoBehaviour
{
    public GameObject blockPrefab;
    public Text firstBlockTitle;
    private JSONNode _s;
    private float _blockSide;
    private List<MapBlock> _mapBlocks;
    public Camera cam;
    private Bounds _bounds;

    void Start()
    {
        _mapBlocks = new List<MapBlock>();
        BlockDataParser();
        MapGenerator();
        FindBounds(gameObject);
        cam.transform.position = new Vector3(_bounds.center.x, _bounds.center.y,
            cam.transform.position.z);
    }

    private List<string> GetParentKeys()
    {
        List<string> list = new List<string>();
        foreach (var er in _s)
            list.Add(er.Key);
        return list;
    }

    private void BlockDataParser()
    {
        TextAsset tileTypeStrings = Resources.Load<TextAsset>("normal_level");
        _s = JSON.Parse(tileTypeStrings.text);
        foreach (var arrayKey in GetParentKeys())
        {
            foreach (var we in _s[arrayKey])
            {
                var tileType = JsonUtility.FromJson<MapBlock>(we.Value.ToString());
                _mapBlocks.Add(tileType);
            }
        }
    }

    private Bounds FindBounds(GameObject theParent)
    {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        Renderer[] allChildren = theParent.GetComponentsInChildren<Renderer>();
        foreach (Renderer aChild in allChildren)
        {
            bounds.Encapsulate(aChild.bounds);
        }

        return _bounds = bounds;
    }

    public void FillTitle()
    {
        firstBlockTitle.text = _mapBlocks[0].Id;
    }

    private void MapGenerator()
    {
        GameObject refTile = Instantiate(blockPrefab);
        foreach (var block in _mapBlocks)
        {
            GameObject tile = Instantiate(blockPrefab, transform);
            tile.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/" + block.Id);
            tile.transform.position = new Vector2(block.X, block.Y);
            tile.transform.localScale = new Vector2(block.Width, block.Height);
            _blockSide = block.Width;
        }

        Destroy(refTile);
    }

    private void Update()
    {
        cam.transform.position =
            new Vector3(Mathf.Clamp(cam.transform.position.x, _bounds.min.x+_blockSide, _bounds.max.x-_blockSide),
                Mathf.Clamp(cam.transform.position.y, _bounds.min.y+_blockSide, _bounds.max.y-_blockSide), cam.transform.position.z);
    }
}
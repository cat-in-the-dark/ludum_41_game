using UnityEngine;

/**
 * It would be better to create a 4x4 Matrix is filled with 1.
 * Replace some of the 1 to the 0 due to the figure.
 * Do 4 rotations and apply offset or not. This will give us all combinations.
 *
 * But this code creates simple hardcoded combos.
 */
public class BoxFiller : MonoBehaviour
{
    public GameObject Container;
    public GameObject Filler;
    public GameObject LeftTopCorner;
    public GameObject RightBottomCorner;

    private BoxController _controller;

    private string _pattern = "L1"; // L, T, S, I
    private int _offset = 0;

    private readonly string[] _patterns = {"L1", "I1", "T1", "S1", "L2", "I2", "T2", "S2"};
    private GameObject[,] _cubes;

    private readonly int[,] _patternI1 = {{0, 0}, {0, 1}, {0, 2}, {0, 3}};
    private readonly int[,] _patternT1 = {{0, 0}, {0, 1}, {0, 2}, {1, 1}};
    private readonly int[,] _patternS1 = {{0, 0}, {0, 1}, {1, 1}, {1, 2}};
    private readonly int[,] _patternL1 = {{0, 0}, {0, 1}, {0, 2}, {1, 2}};

    private readonly int[,] _patternI2 = {{0, 0}, {1, 0}, {2, 0}, {3, 0}};
    private readonly int[,] _patternT2 = {{0, 0}, {1, 0}, {2, 0}, {1, 1}};
    private readonly int[,] _patternS2 = {{0, 0}, {1, 0}, {1, 1}, {2, 1}};
    private readonly int[,] _patternL2 = {{0, 0}, {1, 0}, {2, 0}, {2, 1}};

    // Use this for initialization
    void Start()
    {
        _controller = GetComponent<BoxController>();
        _pattern = _patterns[Random.Range(0, _patterns.Length)];
        _offset = Random.Range(0, 2);
        Fill();
        Remove();
        _controller.Type = _pattern.Substring(0, 1);
        ;
    }

    private int[,] ChosePattern()
    {
        switch (_pattern)
        {
            case "L1": return _patternL1;
            case "I1": return _patternI1;
            case "T1": return _patternT1;
            case "S1": return _patternS1;
            case "L2": return _patternL2;
            case "I2": return _patternI2;
            case "T2": return _patternT2;
            case "S2": return _patternS2;
            default: return null;
        }
    }

    private void Remove()
    {
        var pattern = ChosePattern();
        for (var i = 0; i < 4; i++)
        {
            Destroy(_cubes[pattern[i, 0] + _offset, pattern[i, 1] + _offset]);
            _cubes[pattern[i, 0], pattern[i, 1]] = null;
        }
    }


    public void RemoveAllCubes()
    {
        foreach (var cube in _cubes)
        {
            if (cube != null) Destroy(cube);
        }

        _cubes = null;
        Destroy(Container);
        Container = null;
    }

    private void Fill()
    {
        var size = CalcSize();

        var leftTopX = LeftTopCorner.transform.position.x;
        var leftTopY = LeftTopCorner.transform.position.y;

        var rightBottomX = RightBottomCorner.transform.position.x;
        var rightBottomY = RightBottomCorner.transform.position.y;

        var deltaY = leftTopY - rightBottomY;
        var deltaX = rightBottomX - leftTopX;

        var fitX = Mathf.FloorToInt(deltaX / size.x);
        var fitY = Mathf.FloorToInt(deltaY / size.y);
        _cubes = new GameObject[fitX, fitY];

        // We need to add some margin between objects
        // So calculate epsilone after Floor operation
        var epsiloneX = (deltaX - fitX * size.x) / (float) fitX;
        var epsiloneY = (deltaY - fitY * size.y) / (float) fitY;

        for (var i = 0; i < fitX; i++)
        {
            for (var j = 0; j < fitY; j++)
            {
                var x = leftTopX + (size.x + epsiloneX) * (i + 0.5f);
                var y = leftTopY - (size.y + epsiloneY) * (j + 0.5f);
                var pos = new Vector3(x, y, Container.transform.position.z);
                var child = Instantiate(Filler, pos, Container.transform.rotation);
                child.transform.parent = Container.transform;
                _cubes[i, j] = child;
            }
        }
    }

    private Vector3 CalcSize()
    {
        var tmp = Instantiate(Filler);
        var size = tmp.GetComponent<Renderer>().bounds.size;
        DestroyImmediate(tmp);
        return size;
    }
}
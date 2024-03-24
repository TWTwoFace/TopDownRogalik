using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private static int _countRoomRemaining = 3;

    [SerializeField] private int _maxCountRooms;
    [SerializeField] private GameObject _roomPrefab;
    [SerializeField] private RoomEdge _roomEdge;
    [SerializeField] private Vector2 _roomSize = new Vector2(30f, 20f);

    private Vector3 _nextRoomPosition;

    private enum RoomEdge
    {
        up,
        down,
        left,
        right,
    }

    private void Start()
    {   
        _nextRoomPosition = transform.position;
        Generate();
    }

    private void Generate()
    {
        DetermineNextRoomTransform();
        if (_countRoomRemaining > 0)
        {
            Instantiate(_roomPrefab, _nextRoomPosition, Quaternion.identity) ;
            _countRoomRemaining--;
        }
    }

    private void DetermineNextRoomTransform()
    {
        switch (_roomEdge)
        {
            case RoomEdge.up:
                _nextRoomPosition.z += _roomSize.y / 2;
                break;
            case RoomEdge.down:
                _nextRoomPosition.z -= _roomSize.y / 2;
                break;
            case RoomEdge.left:
                _nextRoomPosition.x -= _roomSize.x / 2;
                break;
            case RoomEdge.right:
                _nextRoomPosition.x += _roomSize.x / 2;
                break;
        }
    }
}

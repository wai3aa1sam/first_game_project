using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome( Packet _packet )
    {
        string _msg = _packet.ReadString();
        int _myid = _packet.ReadInt();

        Debug.Log( $"Message from server: {_msg}" );
        Client.instance.myId = _myid;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect( ( (IPEndPoint) Client.instance.tcp.socket.Client.LocalEndPoint ).Port );
    }

    public static void SpawnPlayer( Packet _packet )
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        OldScript.GameManager.instance.SpawnPlayer( _id, _username, _position, _rotation );

    }

    public static void PlayerPosition( Packet _packet )
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        if ( OldScript.GameManager.players.TryGetValue( _id, out PlayerManager _player ) )
        {
            _player.transform.position = _position;
        }
    }

    public static void PlayerRotation( Packet _packet )
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();
        
        if ( OldScript.GameManager.players.TryGetValue( _id, out PlayerManager _player ) )
        {
            _player.transform.rotation = _rotation;
        }
    }

    public static void PlayerDisconnected( Packet _packet )
    {
        int _id = _packet.ReadInt();
        Destroy( OldScript.GameManager.players[ _id ].gameObject );
        OldScript.GameManager.players.Remove( _id );
    }

    public static void PlayerHealth( Packet _packet )
    {
        int _id = _packet.ReadInt();
        float _health = _packet.ReadFloat();

        OldScript.GameManager.players[ _id ].SetHealth( _health );
    }

    public static void PlayerRespawned( Packet _packet )
    {
        int _id = _packet.ReadInt();

        OldScript.GameManager.players[ _id ].Respawn();
    }

    public static void CreateItemSpawner( Packet _packet )
    {
        int _spawnerId = _packet.ReadInt();
        Vector3 _spawnerPosition = _packet.ReadVector3();
        bool _hasItem = _packet.ReadBool();

        OldScript.GameManager.instance.CreateItemSpawner( _spawnerId, _spawnerPosition, _hasItem );
    }

    public static void ItemSpawned( Packet _packet )
    {
        int _spawnerId = _packet.ReadInt();

        OldScript.GameManager.itemSpawners[  _spawnerId ].ItemSpawned();
    }

    public static void ItemPickedUp( Packet _packet )
    {
        int _spawnerId = _packet.ReadInt();
        int _byPlayer = _packet.ReadInt();

        OldScript.GameManager.itemSpawners[  _spawnerId ].ItemPickedUp();
        OldScript.GameManager.players[ _byPlayer ].itemCount++;
    }

    public static void SpawnProjectile( Packet _packet )
    {
        int _projectileId = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        int _thrownByPlayer = _packet.ReadInt();

        OldScript.GameManager.instance.SpawnProjectile( _projectileId, _position );
        OldScript.GameManager.players[ _thrownByPlayer ].itemCount--;
    }
    
    public static void ProjectilePosition( Packet _packet )
    {
        int _projectileId = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        if ( OldScript.GameManager.projectiles.TryGetValue( _projectileId, out ProjectileManager _projectile ) )
        {
            _projectile.transform.position = _position;
        }
    }
    
    public static void ProjectileExploded( Packet _packet )
    {
        int _projectileId = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        OldScript.GameManager.projectiles[ _projectileId ].Explode( _position );
    }

    public static void SpawnEnemy( Packet _packet )
    {
        int _enemyId = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        
        OldScript.GameManager.instance.SpawnEnemy( _enemyId, _position );
    }
    
    public static void EnemyPosition( Packet _packet )
    {
        int _enemyId = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();

        if ( OldScript.GameManager.enemies.TryGetValue( _enemyId, out EnemyManager _enemy ) )
        {
            _enemy.transform.position = _position;
        }
    }
    
    public static void EnemyHealth( Packet _packet )
    {
        int _enemyId = _packet.ReadInt();
        float _health = _packet.ReadFloat();
        
        OldScript.GameManager.enemies[ _enemyId ].SetHealth( _health );
    }
}

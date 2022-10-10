[System.Serializable]
public class PlayerData
{
    public int level;
    public int playerCurrentHealth;
    public int playerMaxHealth;
    public float moveSpeed;
    public float jumpForce;
    public int coinCount;
    public float[] position;

    public PlayerData (Player player)
    {
        level = player.level;
        playerCurrentHealth = player.playerCurrentHealth;
        playerMaxHealth = player.playerMaxHealth;
        moveSpeed = player.moveSpeed;
        jumpForce = player.jumpForce;
        coinCount = player.coinCount;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}

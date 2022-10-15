public static class CurrentPlayerState
{
    public static Player player;

    public static int level;
    public static int playerCurrentHealth;
    public static int playerMaxHealth;
    public static float moveSpeed;
    public static float jumpForce;
    public static int coinCount;
    public static float[] position;

    public static void SetPlayerStateFromPlayerData (PlayerData playerData)
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

    public static Player GetPlayerSaveState()
    {
        return player;
    }
}
public static class Constants
{
    // TAGS
    public static string SPAWNER_TAG = "Spawner";
    public static string ENEMY_TAG = "Enemy";
    public static string PLAYER_TAG = "Player";
    public static string HEALTH_BONUS_TAG = "HealthBonus";

    // Animations
    public static string IS_HIT_ANIM = "isHit";

    // Player attributes
    public static float PLAYER_SPEED = 4f;
    public static int PLAYER_HEALTH = 100;
    public static float PLAYER_ROTATION_SPEED = 1f;

    // Enemies attributes
        // Default enemy
        public static float DEFAULT_ENEMY_SPEED = 2f;
        public static int DEFAULT_ENEMY_HEALTH = 100;
        public static int DEFAULT_ENEMY_HIT_DAMAGE = 20;
        public static int DEFAULT_ENEMY_SCORE = 10;

    // Weapons attributes
        // Default laser beam
        public static float DEFAULT_LASERBEAM_FORCE = 20f;
        public static int DEFAULT_LASERBEAM_DAMAGE = 50;

    // Bonus attributes
        // Health Bonus
        public static int HEALTH_BONUS_LIFETIME = 5;
        public static int HEALTH_POINT_BONUS = 20;

    // Spawner attributes
    public static int SPAWNER_ANGLE_SHIT = 40;
    public static int SPAWNER_MAX_TIME_TO_WAIT_ENEMY = 5;
    public static int SPAWNER_MAX_TIME_TO_WAIT_HEALTH_BONUS = 20;

    // UI attributes
}

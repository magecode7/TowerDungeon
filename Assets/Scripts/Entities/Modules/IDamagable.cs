interface IDamagable
{
    bool Alive { get; }
    float MaxHealth { get; set; }
    float Health { get; set; }

    void TakeDamage(float damage);

    void Die();
}

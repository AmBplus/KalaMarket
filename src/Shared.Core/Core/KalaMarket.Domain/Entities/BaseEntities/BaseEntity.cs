﻿namespace KalaMarket.Domain.Entities.BaseEntities;

public abstract class BaseEntity<TKey> : BaseEntityWithoutId
{
    public TKey Id { get; set; }
}
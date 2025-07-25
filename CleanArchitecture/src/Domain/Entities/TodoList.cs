﻿namespace CleanArchitecture.Domain.Entities;

public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; init; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}

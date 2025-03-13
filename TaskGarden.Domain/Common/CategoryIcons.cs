namespace TaskGarden.Domain.Common;

using System.Collections.Immutable;

public class CategoryIcon
{
    public int Id { get; }
    public string Tag { get; }
    public string Icon { get; } 

    public CategoryIcon(int id, string tag, string icon)
    {
        Id = id;
        Tag = tag;
        Icon = icon;
    }
}

public static class CategoryIcons
{
    public static readonly ImmutableArray<CategoryIcon> Icons = ImmutableArray.Create(
        new CategoryIcon(1, "shopping-bag", "shopping-bag-icon"),
        new CategoryIcon(2, "shopping-basket", "shopping-basket-icon"),
        new CategoryIcon(3, "shopping-cart", "shopping-cart-icon"),
        new CategoryIcon(4, "users", "users-icon"),
        new CategoryIcon(5, "messages-square", "messages-square-icon"),
        new CategoryIcon(6, "plane", "plane-icon"),
        new CategoryIcon(7, "map-pinned", "map-pinned-icon"),
        new CategoryIcon(8, "receipt", "receipt-icon"),
        new CategoryIcon(9, "banknote", "banknote-icon"),
        new CategoryIcon(10, "hand-coins", "hand-coins-icon"),
        new CategoryIcon(11, "dumbbell", "dumbbell-icon"),
        new CategoryIcon(12, "heart-pulse", "heart-pulse-icon"),
        new CategoryIcon(13, "roller-coaster", "roller-coaster-icon"),
        new CategoryIcon(14, "ferris-wheel", "ferris-wheel-icon"),
        new CategoryIcon(15, "drama", "drama-icon"),
        new CategoryIcon(16, "theater", "theater-icon"),
        new CategoryIcon(17, "film", "film-icon"),
        new CategoryIcon(18, "house", "house-icon"),
        new CategoryIcon(19, "spray-can", "spray-can-icon"),
        new CategoryIcon(20, "briefcase", "briefcase-icon"),
        new CategoryIcon(21, "building", "building-icon"),
        new CategoryIcon(22, "building-2", "building-2-icon"),
        new CategoryIcon(23, "university", "university-icon"),
        new CategoryIcon(24, "book", "book-icon"),
        new CategoryIcon(25, "square-library", "square-library-icon")
    );
}

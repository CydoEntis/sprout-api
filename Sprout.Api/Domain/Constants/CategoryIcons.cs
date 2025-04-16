namespace Sprout.Domain.Common;

using System.Collections.Immutable;
using System.Collections.Generic;

public class CategoryIcon
{
    public int Id { get; }
    public string Tag { get; }
    public string Icon { get; }

    private CategoryIcon(int id, string tag, string icon)
    {
        Id = id;
        Tag = tag;
        Icon = icon;
    }

    // Static Readonly Dictionary for Fast Lookup
    private static readonly Dictionary<string, CategoryIcon> IconDictionary;

    // Immutable List for Iteration
    public static readonly ImmutableArray<CategoryIcon> Icons;

    // Predefined Icons as Static Properties for Easy Access
    public static readonly CategoryIcon ShoppingBag = new(1, "shopping-bag", "shopping-bag-icon");
    public static readonly CategoryIcon ShoppingBasket = new(2, "shopping-basket", "shopping-basket-icon");
    public static readonly CategoryIcon ShoppingCart = new(3, "shopping-cart", "shopping-cart-icon");
    public static readonly CategoryIcon Users = new(4, "users", "users-icon");
    public static readonly CategoryIcon MessagesSquare = new(5, "messages-square", "messages-square-icon");
    public static readonly CategoryIcon Plane = new(6, "plane", "plane-icon");
    public static readonly CategoryIcon MapPinned = new(7, "map-pinned", "map-pinned-icon");
    public static readonly CategoryIcon Receipt = new(8, "receipt", "receipt-icon");
    public static readonly CategoryIcon Banknote = new(9, "banknote", "banknote-icon");
    public static readonly CategoryIcon HandCoins = new(10, "hand-coins", "hand-coins-icon");
    public static readonly CategoryIcon Dumbbell = new(11, "dumbbell", "dumbbell-icon");
    public static readonly CategoryIcon HeartPulse = new(12, "heart-pulse", "heart-pulse-icon");
    public static readonly CategoryIcon RollerCoaster = new(13, "roller-coaster", "roller-coaster-icon");
    public static readonly CategoryIcon FerrisWheel = new(14, "ferris-wheel", "ferris-wheel-icon");
    public static readonly CategoryIcon Drama = new(15, "drama", "drama-icon");
    public static readonly CategoryIcon Theater = new(16, "theater", "theater-icon");
    public static readonly CategoryIcon Film = new(17, "film", "film-icon");
    public static readonly CategoryIcon House = new(18, "house", "house-icon");
    public static readonly CategoryIcon SprayCan = new(19, "spray-can", "spray-can-icon");
    public static readonly CategoryIcon Briefcase = new(20, "briefcase", "briefcase-icon");
    public static readonly CategoryIcon Building = new(21, "building", "building-icon");
    public static readonly CategoryIcon Building2 = new(22, "building-2", "building-2-icon");
    public static readonly CategoryIcon University = new(23, "university", "university-icon");
    public static readonly CategoryIcon Book = new(24, "book", "book-icon");
    public static readonly CategoryIcon SquareLibrary = new(25, "square-library", "square-library-icon");

    // Static Constructor to Initialize Collection
    static CategoryIcon()
    {
        Icons = ImmutableArray.Create(
            ShoppingBag, ShoppingBasket, ShoppingCart, Users, MessagesSquare, Plane, MapPinned, Receipt,
            Banknote, HandCoins, Dumbbell, HeartPulse, RollerCoaster, FerrisWheel, Drama, Theater, Film,
            House, SprayCan, Briefcase, Building, Building2, University, Book, SquareLibrary
        );

        IconDictionary = Icons.ToDictionary(icon => icon.Tag, icon => icon);
    }

    // Method for Lookup by Tag
    public static CategoryIcon GetByTag(string tag) =>
        IconDictionary.TryGetValue(tag, out var icon) ? icon : throw new KeyNotFoundException($"No icon found for tag: {tag}");
}

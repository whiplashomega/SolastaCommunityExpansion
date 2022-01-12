using System;

namespace SolastaCommunityExpansion.Documentation
{
    // Initially target properties and classes.  Allow multiple?
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    internal class DocumentationAttribute : Attribute
    {
        private string externalDescription;

        // Author(s), Category(ies) and Description are mandatory
        public DocumentationAttribute(Author authors, Category categories, string description)
        {
            Authors = authors;
            Categories = categories;
            Description = description;
        }

        public Author Authors { get; }
        public Category Categories { get; }

        public bool IsHiddenInModUI { get; set; }

        // used on mod UI and Nexus credits - if null or empty will use Categories
        public string CreditTitle { get; set; }

        // to be used in building mod UI - not too long
        public string Description { get; }

        // for external web pages - e.g. Nexus.  Longer.
        // if not present then Descripton is used
        public string ExternalDescription
        {
            get => string.IsNullOrEmpty(externalDescription) ? Description : externalDescription;
            set => externalDescription = value;
        }
    }

    /// <summary>
    /// Enum mirroring Nexus web page
    /// </summary>
    [Flags]
    internal enum Category
    {
        Bestiary = 1,
        BugFix = 2,
        Character = 4,
        CharacterPool = 8,
        CraftableItem = 16,
        Encounter = 32,
        Feat = 64,
        FightingStyle = 128,
        GameplayRuleHouse = 256,
        GameplayRuleSRD = 512,
        ItemsAndMerchants = 1024,
        SubClasses = 2048,
        Tool = 4096,
        UIImprovement = 8192
    }

    [Flags]
    internal enum Author
    {
        ThyWoof = 1,
        ChrisJohn = 2,
        ImpPhil = 4,
        RealBazou = 8,
        Dreadmaker = 16,
        CEDSS = 32,
        SilverGriffon = 64,
        RedOrca = 128,
        Holic = 256,
        DubhHerder = 512,
    }

    internal static class AuthorExtensions
    {
        public static string ToDisplay(this Author value)
        {
            switch (value)
            {
                case Author.ThyWoof:
                    return "ThyWoof (Paul Monteiro)";
                case Author.ChrisJohn:
                    return "Chris John";
                case Author.ImpPhil:
                    return "ImpPhil (Phil Lee)";
                case Author.RealBazou:
                    return "RealBazou (?)";
                case Author.Dreadmaker:
                case Author.CEDSS:
                case Author.SilverGriffon:
                case Author.RedOrca:
                case Author.Holic:
                case Author.DubhHerder:
                    return value.ToString();
                default:
                    Main.Error($"AuthorExtensions.ToDisplay, unknown value {value}.");
                    return "Error: Unknown";
            }
        }
    }

    internal static class CategoryExtensions
    {
        public static string ToDisplay(this Category value)
        {
            switch (value)
            {
                case Category.Bestiary:
                    return "Bestiary";
                case Category.BugFix:
                    return "Bug fix";
                case Category.Character:
                    return "Character";
                case Category.CharacterPool:
                    return "Character pool";
                case Category.CraftableItem:
                    return "Craftable item";
                case Category.Encounter:
                    return "Encounter";
                case Category.Feat:
                    return "Feat";
                case Category.FightingStyle:
                    return "Fighting style";
                case Category.GameplayRuleHouse:
                    return "House gameplay rule";
                case Category.GameplayRuleSRD:
                    return "SRD gameplay rule";
                case Category.ItemsAndMerchants:
                    return "Items and merchants";
                case Category.SubClasses:
                    return "Sub-classes";
                case Category.Tool:
                    return "Tool";
                case Category.UIImprovement:
                    return "UI improvement";
                default:
                    Main.Error($"CategoryExtensions.ToDisplay, unknown value {value}.");
                    return "Error: Unknown";
            }
        }
    }
}

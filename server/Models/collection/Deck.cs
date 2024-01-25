namespace CardboardArchivistAPI.Models.Collection;

public class Deck
{
    public required string UUID { get; set; }
    public required Card[] Cards { get; set; }
}
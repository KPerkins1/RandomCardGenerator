using CardGenerator;
using Xunit;

namespace CardGenerator.Tests;

public class CardTests
{
    [Fact]
    public void ImageUrl_MapsAceOfHearts()
    {
        var card = new Card("Hearts", 1);

        Assert.Equal("https://deckofcardsapi.com/static/img/AH.png", card.ImageUrl);
    }

    [Fact]
    public void ImageUrl_MapsTenOfSpades()
    {
        var card = new Card("Spades", 10);

        Assert.Equal("https://deckofcardsapi.com/static/img/0S.png", card.ImageUrl);
    }

    [Fact]
    public void ImageUrl_MapsKingOfClubs()
    {
        var card = new Card("Clubs", 13);

        Assert.Equal("https://deckofcardsapi.com/static/img/KC.png", card.ImageUrl);
    }

    [Fact]
    public void ImageUrl_MapsNumberedCard()
    {
        var card = new Card("Diamonds", 7);

        Assert.Equal("https://deckofcardsapi.com/static/img/7D.png", card.ImageUrl);
    }

    [Fact]
    public void RandomCard_ReturnsSupportedSuitAndRank()
    {
        var card = Card.RandomCard();

        Assert.Contains(card.cardSuit, new[] { "Hearts", "Diamonds", "Clubs", "Spades" });
        Assert.InRange(card.cardRank, 1, 13);
    }
}
using RomanNumerals;
namespace RomanNumeralsTest;

public class RomanNumeralsGeneratorShould
{
    [Fact]
    public void DecimalToRomanNumeralsParserTest()
    {
        Assert.Equal("I", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(1));
        Assert.Equal("II", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(2));
        Assert.Equal("IV", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(4));
        Assert.Equal("V", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(5));
        Assert.Equal("VI", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(6));
        Assert.Equal("IX", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(9));
        Assert.Equal("X", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(10));
        Assert.Equal("XXIX", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(29));
        Assert.Equal("XL", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(40));
        Assert.Equal("XLIX", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(49));
        Assert.Equal("L", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(50));
        Assert.Equal("LXXXIX", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(89));
        Assert.Equal("XC", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(90));
        Assert.Equal("C", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(100));
        Assert.Equal("CD", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(400));
        Assert.Equal("D", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(500));
        Assert.Equal("CM", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(900));
        Assert.Equal("M", RomanNumeralsGenerator.DecimalToRomanNumeralsParser(1000));

    }
}
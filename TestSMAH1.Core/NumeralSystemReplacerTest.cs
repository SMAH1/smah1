using SMAH1.Character;
using SMAH1.ExtensionMethod;
using Xunit;

namespace TestSMAH1.Core
{
    public class NumeralSystemReplacerTest
    {
        [Fact]
        public void CheckLengthIs10()
        {
            foreach (var f in SMAH1.EnumInfoBase<NumeralSystemSign>.GetFields())
            {
                Assert.Equal(10, SMAH1.EnumInfoBase<NumeralSystemSign>.GetFieldDescription(f, 0).Length);
            }
        }

        [Theory]
        [InlineData("5629378401", "5629378401", NumeralSystemSign.Default, NumeralSystemSign.Default)]
        [InlineData("5629378401", "5629378401", NumeralSystemSign.Default, NumeralSystemSign.Persian)]
        [InlineData("5629378401", "5629378401", NumeralSystemSign.Default, NumeralSystemSign.Urdu, NumeralSystemSign.Arabic, NumeralSystemSign.ChineseSimple)]
        [InlineData("۵۶۲۹۳۷۸۴۰۱", "۵۶۲۹۳۷۸۴۰۱", NumeralSystemSign.Persian, NumeralSystemSign.Default)]
        [InlineData("۵۶۲۹۳۷۸۴۰۱", "۵۶۲۹۳۷۸۴۰۱", NumeralSystemSign.Persian, NumeralSystemSign.Mongolian, NumeralSystemSign.Arabic, NumeralSystemSign.ChineseSimple)]
        public void ReplacerNoChangeTest(string input, string output, NumeralSystemSign dist, params NumeralSystemSign[] sources)
        {
            Assert.Equal(output, input.NumeralSystemReplacer(dist, sources));
        }

        [Theory]
        [InlineData("6310824795", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Default)]
        [InlineData("٦٣١٠٨٢٤٧٩٥", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Arabic)]
        [InlineData("৬৩১০৮২৪৭৯৫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Bengali)]
        [InlineData("陸參壹零捌貳肆柒玖伍", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.ChineseComplex)]
        [InlineData("〦〣〡〇〨〢〤〧〩〥", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.ChineseHuaMa)]
        [InlineData("六三一〇八二四七九五", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.ChineseSimple)]
        [InlineData("६३१०८२४७९५", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Devanagari)]
        [InlineData("૬૩૧૦૮૨૪૭૯૫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Gujarati)]
        [InlineData("੬੩੧੦੮੨੪੭੯੫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Gurmukhi)]
        [InlineData("೬೩೧೦೮೨೪೭೯೫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Kannada)]
        [InlineData("៦៣១០៨២៤៧៩៥", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Khmer)]
        [InlineData("໖໓໑໐໘໒໔໗໙໕", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Lao)]
        [InlineData("൬൩൧൦൮൨൪൭൯൫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Malayalam)]
        [InlineData("᠖᠓᠑᠐᠘᠒᠔᠗᠙᠕", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Mongolian)]
        [InlineData("၆၃၁၀၈၂၄၇၉၅", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Myanmar)]
        [InlineData("୬୩୧୦୮୨୪୭୯୫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Odia)]
        [InlineData("۶۳۱۰۸۲۴۷۹۵", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Persian)]
        [InlineData("௬௩௧௦௮௨௪௭௯௫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Tamil)]
        [InlineData("౬౩౧౦౮౨౪౭౯౫", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Telugu)]
        [InlineData("๖๓๑๐๘๒๔๗๙๕", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Thai)]
        [InlineData("༦༣༡༠༨༢༤༧༩༥", "6310824795", NumeralSystemSign.Default, NumeralSystemSign.Tibetan)]

        [InlineData("6310824795", "٦٣١٠٨٢٤٧٩٥", NumeralSystemSign.Arabic, NumeralSystemSign.Default)]
        [InlineData("6310824795", "৬৩১০৮২৪৭৯৫", NumeralSystemSign.Bengali, NumeralSystemSign.Default)]
        [InlineData("6310824795", "陸參壹零捌貳肆柒玖伍", NumeralSystemSign.ChineseComplex, NumeralSystemSign.Default)]
        [InlineData("6310824795", "〦〣〡〇〨〢〤〧〩〥", NumeralSystemSign.ChineseHuaMa, NumeralSystemSign.Default)]
        [InlineData("6310824795", "六三一〇八二四七九五", NumeralSystemSign.ChineseSimple, NumeralSystemSign.Default)]
        [InlineData("6310824795", "६३१०८२४७९५", NumeralSystemSign.Devanagari, NumeralSystemSign.Default)]
        [InlineData("6310824795", "૬૩૧૦૮૨૪૭૯૫", NumeralSystemSign.Gujarati, NumeralSystemSign.Default)]
        [InlineData("6310824795", "੬੩੧੦੮੨੪੭੯੫", NumeralSystemSign.Gurmukhi, NumeralSystemSign.Default)]
        [InlineData("6310824795", "೬೩೧೦೮೨೪೭೯೫", NumeralSystemSign.Kannada, NumeralSystemSign.Default)]
        [InlineData("6310824795", "៦៣១០៨២៤៧៩៥", NumeralSystemSign.Khmer, NumeralSystemSign.Default)]
        [InlineData("6310824795", "໖໓໑໐໘໒໔໗໙໕", NumeralSystemSign.Lao, NumeralSystemSign.Default)]
        [InlineData("6310824795", "൬൩൧൦൮൨൪൭൯൫", NumeralSystemSign.Malayalam, NumeralSystemSign.Default)]
        [InlineData("6310824795", "᠖᠓᠑᠐᠘᠒᠔᠗᠙᠕", NumeralSystemSign.Mongolian, NumeralSystemSign.Default)]
        [InlineData("6310824795", "၆၃၁၀၈၂၄၇၉၅", NumeralSystemSign.Myanmar, NumeralSystemSign.Default)]
        [InlineData("6310824795", "୬୩୧୦୮୨୪୭୯୫", NumeralSystemSign.Odia, NumeralSystemSign.Default)]
        [InlineData("6310824795", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Default)]
        [InlineData("6310824795", "௬௩௧௦௮௨௪௭௯௫", NumeralSystemSign.Tamil, NumeralSystemSign.Default)]
        [InlineData("6310824795", "౬౩౧౦౮౨౪౭౯౫", NumeralSystemSign.Telugu, NumeralSystemSign.Default)]
        [InlineData("6310824795", "๖๓๑๐๘๒๔๗๙๕", NumeralSystemSign.Thai, NumeralSystemSign.Default)]
        [InlineData("6310824795", "༦༣༡༠༨༢༤༧༩༥", NumeralSystemSign.Tibetan, NumeralSystemSign.Default)]

        [InlineData("٦٣١٠٨٢٤٧٩٥", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Arabic)]
        [InlineData("৬৩১০৮২৪৭৯৫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Bengali)]
        [InlineData("陸參壹零捌貳肆柒玖伍", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.ChineseComplex)]
        [InlineData("〦〣〡〇〨〢〤〧〩〥", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.ChineseHuaMa)]
        [InlineData("六三一〇八二四七九五", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.ChineseSimple)]
        [InlineData("६३१०८२४७९५", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Devanagari)]
        [InlineData("૬૩૧૦૮૨૪૭૯૫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Gujarati)]
        [InlineData("੬੩੧੦੮੨੪੭੯੫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Gurmukhi)]
        [InlineData("೬೩೧೦೮೨೪೭೯೫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Kannada)]
        [InlineData("៦៣១០៨២៤៧៩៥", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Persian, NumeralSystemSign.Khmer)]
        [InlineData("໖໓໑໐໘໒໔໗໙໕", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Urdu, NumeralSystemSign.Lao)]
        [InlineData("൬൩൧൦൮൨൪൭൯൫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Urdu, NumeralSystemSign.Malayalam)]
        [InlineData("᠖᠓᠑᠐᠘᠒᠔᠗᠙᠕", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Urdu, NumeralSystemSign.Mongolian)]
        [InlineData("၆၃၁၀၈၂၄၇၉၅", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Urdu, NumeralSystemSign.Myanmar)]
        [InlineData("୬୩୧୦୮୨୪୭୯୫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Urdu, NumeralSystemSign.Odia)]
        [InlineData("۶۳۱۰۸۲۴۷۹۵", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Sindhi, NumeralSystemSign.Persian)]
        [InlineData("௬௩௧௦௮௨௪௭௯௫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Sindhi, NumeralSystemSign.Tamil)]
        [InlineData("౬౩౧౦౮౨౪౭౯౫", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Sindhi, NumeralSystemSign.Telugu)]
        [InlineData("๖๓๑๐๘๒๔๗๙๕", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Sindhi, NumeralSystemSign.Thai)]
        [InlineData("༦༣༡༠༨༢༤༧༩༥", "۶۳۱۰۸۲۴۷۹۵", NumeralSystemSign.Sindhi, NumeralSystemSign.Tibetan)]

        public void ReplacerOnetoOneTest(string input, string output, NumeralSystemSign dist, NumeralSystemSign source)
        {
            Assert.Equal(output, input.NumeralSystemReplacer(dist, source));
        }

        [Theory]
        [InlineData("四୯٨୧١二۴០៩৪୩1٤۲๐៧৯๖۹๔", "49811240943142079694", NumeralSystemSign.Default,
            NumeralSystemSign.ChineseSimple, NumeralSystemSign.Odia, NumeralSystemSign.Bengali, NumeralSystemSign.Khmer,
            NumeralSystemSign.Persian, NumeralSystemSign.Arabic, NumeralSystemSign.Thai)]
        public void ReplacerManytoOneTest(string input, string output, NumeralSystemSign dist, params NumeralSystemSign[] sources)
        {
            Assert.Equal(output, input.NumeralSystemReplacer(dist, sources));
        }
    }
}

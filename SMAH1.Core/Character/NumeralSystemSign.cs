using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMAH1.Character
{
    public enum NumeralSystemSign
    {
        [Description("0123456789")]
        Default = 0,

        [Description("٠١٢٣٤٥٦٧٨٩")]
        Arabic = 1,

        [Description("০১২৩৪৫৬৭৮৯")]
        Bengali = 2,

        [Description("零壹貳參肆伍陸柒捌玖")]
        ChineseComplex = 3,

        [Description("〇〡〢〣〤〥〦〧〨〩")]
        ChineseHuaMa = 4,

        [Description("〇一二三四五六七八九")]
        ChineseSimple = 5,

        [Description("०१२३४५६७८९")]
        Devanagari = 6,

        [Description("૦૧૨૩૪૫૬૭૮૯")]
        Gujarati = 7,

        [Description("੦੧੨੩੪੫੬੭੮੯")]
        Gurmukhi = 8,

        [Description("೦೧೨೩೪೫೬೭೮೯")]
        Kannada = 9,

        [Description("០១២៣៤៥៦៧៨៩")]
        Khmer = 10,

        [Description("໐໑໒໓໔໕໖໗໘໙")]
        Lao = 11,

        [Description("൦൧൨൩൪൫൬൭൮൯")]
        Malayalam = 12,

        [Description("᠐᠑᠒᠓᠔᠕᠖᠗᠘᠙")]
        Mongolian = 13,

        [Description("၀၁၂၃၄၅၆၇၈၉")]
        Myanmar = 14,

        [Description("୦୧୨୩୪୫୬୭୮୯")]
        Odia = 15,

        [Description("۰۱۲۳۴۵۶۷۸۹")]
        Persian = 16,

        [Description("௦௧௨௩௪௫௬௭௮௯")]
        Tamil = 17,

        [Description("౦౧౨౩౪౫౬౭౮౯")]
        Telugu = 18,

        [Description("๐๑๒๓๔๕๖๗๘๙")]
        Thai = 19,

        [Description("༠༡༢༣༤༥༦༧༨༩")]
        Tibetan = 20,

        [Description("۰۱۲۳۴۵۶۷۸۹")]
        Sindhi = 21,

        [Description("۰۱۲۳۴۵۶۷۸۹")]
        Urdu = 22,

        [Description("⓪①②③④⑤⑥⑦⑧⑨")]
        DefaultCircled = 101,

        [Description("⓿❶❷❸❹❺❻❼❽❾")]
        DefaultNegativeCircled = 102,

        [Description("⁰¹²³⁴⁵⁶⁷⁸⁹")]
        DefaultSuperscript = 103,

        [Description("₀₁₂₃₄₅₆₇₈₉")]
        DefaultSubscript = 104,
    }
}

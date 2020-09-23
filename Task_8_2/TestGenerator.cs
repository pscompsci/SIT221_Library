using System;

namespace CoinRepresentation
{
    class TestGenerator
    {
        static public int Count()
        {
            return 63;
        }
        public static long Generate(int k, out long arg)
        {
            long result = -1; arg = 0;
            switch (k)
            {
                case 0: arg = 1; result = 1; break;
                case 1: arg = 6; result = 3; break;
                case 2: arg = 47; result = 2; break;
                case 3: arg = 256; result = 9; break;
                case 4: arg = 8489289; result = 6853; break;
                case 5: arg = 1000000000; result = 73411; break;
                case 6: arg = 100; result = 19; break;
                case 7: arg = 128; result = 8; break;
                case 8: arg = 1073741824; result = 31; break;
                case 9: arg = 6370; result = 175; break;
                case 10: arg = 10; result = 5; break;
                case 11: arg = 2; result = 2; break;
                case 12: arg = 3; result = 1; break;
                case 13: arg = 4; result = 3; break;
                case 14: arg = 2000000000; result = 81034; break;
                case 15: arg = 999999999; result = 7623; break;
                case 16: arg = 1000000000000000000; result = 554817437; break;
                case 17: arg = 576460752303423488; result = 60; break;
                case 18: arg = 640; result = 23; break;
                case 19: arg = 785; result = 34; break;
                case 20: arg = 1022; result = 10; break;
                case 21: arg = 962; result = 38; break;
                case 22: arg = 640; result = 23; break;
                case 23: arg = 1099510542205; result = 17863; break;
                case 24: arg = 944875173846; result = 1243789; break;
                case 25: arg = 672031828383; result = 500073; break;
                case 26: arg = 893915235088; result = 243779; break;
                case 27: arg = 1088385987371; result = 4634234; break;
                case 28: arg = 347905064087584832; result = 5150282; break;
                case 29: arg = 309341003709448449; result = 19102955; break;
                case 30: arg = 263810380166378775; result = 4693345949; break;
                case 31: arg = 361431780114432130; result = 94727263; break;
                case 32: arg = 378311177695920400; result = 20702253; break;
                case 33: arg = 290553370434404484; result = 146293655; break;
                case 34: arg = 423901414250789313; result = 292614203; break;
                case 35: arg = 438190581230404958; result = 6012372582; break;
                case 36: arg = 293666568548731467; result = 3648043185; break;
                case 37: arg = 392393882169705920; result = 3341296806; break;
                case 38: arg = 376370659955075108; result = 3279511256; break;
                case 39: arg = 412658913555584867; result = 3498747798; break;
                case 40: arg = 999999999999999999; result = 29665503; break;
                case 41: arg = 410054521552536292; result = 26030230909; break;
                case 42: arg = 416860608518791589; result = 8015276820; break;
                case 43: arg = 393014244375683364; result = 16905456859; break;
                case 44: arg = 518010418436963490; result = 15340957057; break;
                case 45: arg = 576460730781662959; result = 794365; break;
                case 46: arg = 565764701561028461; result = 2186952; break;
                case 47: arg = 571954850028252927; result = 7287457; break;
                case 48: arg = 558161296277634687; result = 1416255; break;
                case 49: arg = 504314853196816127; result = 6183662; break;
                case 50: arg = 123456789; result = 51639; break;
                case 51: arg = 768614336404564650; result = 2504730781961; break;
                case 52: arg = 384307168202282325; result = 956722026041; break;
                case 53: arg = 384307168202282324; result = 1548008755920; break;
                case 54: arg = 192153584101141162; result = 956722026041; break;
                case 55: arg = 196657183728511722; result = 502131822759; break;
                case 56: arg = 193349852752161450; result = 484936992181; break;
                case 57: arg = 196731950519200426; result = 350312970581; break;
                case 58: arg = 192153584101141166; result = 644603021052; break;
                case 59: arg = 10000000000000000; result = 17165857; break;
                case 60: arg = 200; result = 26; break;
                case 61: arg = 93459834598323452; result = 317400926; break;
                case 62: arg = 1717161617181871; result = 69493195; break;
            }
            return result;

        }
    }
}
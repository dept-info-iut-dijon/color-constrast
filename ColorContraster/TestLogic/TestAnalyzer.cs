using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestAnalyzer
    {
        [Fact]
        public void TestBase()
        {
            Analyzer analyzer = new Analyzer();
            Assert.Null(analyzer.Foreground);
            Assert.Null(analyzer.Background);            
        }

        [Fact]
        public void TestRatio()
        {
            Analyzer test = new Analyzer();
            test.Foreground = new Color(0xFA, 0xC5, 0xB2);
            test.Background = new Color(0x21, 0xA7, 0x01);
            Assert.Equal(2.08, test.Ratio, 2);

            test.Foreground = new Color(0x01, 0x50, 0x32);
            test.Background = new Color(0xD1, 0x79, 0xF0);

            Assert.Equal(3.51, test.Ratio, 2);
        }        

        [Fact]
        public void TestWCAG()
        {
            Analyzer test = new Analyzer();
            test.Foreground = new Color(0x01, 0x50, 0x32);
            test.Background = new Color(0xD1, 0x79, 0xF0);
            Assert.False(test.SmallTextAA);
            Assert.False(test.SmallTextAAA);
            Assert.True(test.LargeTextAA);
            Assert.False(test.LargeTextAAA);

            test.Foreground = new Color();
            Assert.True(test.SmallTextAA);
            Assert.True(test.SmallTextAAA);
            Assert.True(test.LargeTextAA);
            Assert.True(test.LargeTextAAA);

            test.Background = new Color(0x11, 0x79, 0xF0);
            Assert.True(test.SmallTextAA);
            Assert.False(test.SmallTextAAA);
            Assert.True(test.LargeTextAA);
            Assert.True(test.LargeTextAAA);
        }
       

    }
}

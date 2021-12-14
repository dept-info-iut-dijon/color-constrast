using System;
using Xunit;
using Logic;
namespace TestLogic
{
    public class TestColor
    {
        [Fact]
        public void TestBase()
        {
            Color test = new Color();
            Assert.Equal(0, test.Red);
            Assert.Equal(0, test.Green);
            Assert.Equal(0, test.Blue);
            test.Red = 100;
            Assert.Equal(100, test.Red);
        }

        [Fact]
        public void TestHTMLColor()
        {
            Color test = new Color(255, 255, 255);
            Assert.Equal("#FFFFFF", test.HTMLCode);
            test = new Color(0x12, 0x03, 0xA4);
            Assert.Equal("#1203A4", test.HTMLCode);
        }

        [Fact]
        public void TestEquals()
        {
            Color test = new Color(140, 185, 65);
            Color test2 = new Color(test);
            Assert.Equal(test, test2);            
        }

        [Fact]
        public void TestLuminance()
        {
            Color test = new Color(0xFA,0x70,0x14);
            Assert.Equal(0.3196, test.Luminance, 4);
            test = new Color(255, 255, 255);
            Assert.Equal(1, test.Luminance, 4);
            test = new Color();
            Assert.Equal(0, test.Luminance, 4);
        }

        [Fact]
        public void TestStdColor()
        {
            Color test = new Color(0xFA, 0x70, 0x14);
            System.Drawing.Color c = test.StdColor;
            Assert.Equal(0xFA, c.R);
            Assert.Equal(0xFFFA7014, (UInt32)c.ToArgb());
        }
    }
}

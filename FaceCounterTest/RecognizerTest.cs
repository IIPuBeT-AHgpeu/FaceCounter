using FaceCounter;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace FaceCounterTest
{
    [TestClass]
    public class RecognizerTest
    {
        private readonly string _localeTestDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FaceCounerTests";
        private byte[]? test_0;
        private byte[]? test_1;
        private byte[]? test_3;
        Recognizer recognizer;

        public RecognizerTest() 
        {
            recognizer = new Recognizer();

            string testPath_0 = _localeTestDir + "\\0.png";
            string testPath_1 = _localeTestDir + "\\1.png";
            string testPath_3 = _localeTestDir + "\\3.png";

            if(!Directory.Exists(_localeTestDir))
            {
                test_0 = null;
                test_1 = null;
                test_3 = null;
            }
            else
            {
                if (!File.Exists(testPath_0)) test_0 = null;
                else test_0 = File.ReadAllBytes(testPath_0);
                if (!File.Exists(testPath_1)) test_1 = null;
                else test_1 = File.ReadAllBytes(testPath_1);
                if (!File.Exists(testPath_3)) test_3 = null;
                else test_3 = File.ReadAllBytes(testPath_3);
            }
        }

        [TestMethod]
        public void Test_0()
        {
            if (test_0 == null)
            {
                Assert.Fail("Отсутствует файл 0.png в тестовой директории.");
            }
            else
            {
                int result = recognizer.GetObjectsCount(test_0);

                Assert.AreEqual(0, result);
            }           
        }

        [TestMethod]
        public void Test_1()
        {
            if (test_1 == null)
            {
                Assert.Fail("Отсутствует файл 1.png в тестовой директории.");
            }
            else
            {
                int result = recognizer.GetObjectsCount(test_1);

                Assert.AreEqual(1, result);
            }
        }

        [TestMethod]
        public void Test_3()
        {
            if (test_3 == null)
            {
                Assert.Fail("Отсутствует файл 3.png в тестовой директории.");
            }
            else
            {
                int result = recognizer.GetObjectsCount(test_3);

                Assert.AreEqual(3, result);
            }
        }
    }
}

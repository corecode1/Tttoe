using System.Linq;
using System.Reflection;
using com.tttoe.runtime;
using NUnit.Framework;

namespace com.tttoe.tests
{
    public class TileOccupationTests
    {
        [Test]
        public void TestAllValuesHaveNames()
        {
            var fields = typeof(TileOccupation)
                .GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.FieldType == typeof(TileOccupation))
                {
                    var value = (TileOccupation)fieldInfo.GetValue(null);
                    Assert.IsNotNull(value.GetName());
                }
            }
        }

        [Test]
        public void TestEquality()
        {
            Assert.AreEqual(TileOccupation.X, TileOccupation.X);
        }
        
        [Test]
        public void TestInEquality()
        {
            Assert.AreNotEqual(TileOccupation.X, TileOccupation.O);
        }
    }
}
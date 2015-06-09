using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicTypesTests
{
    using DynamicTypes;

    using DynamicTypesTests.Fakes;

    [TestClass]
    public class TypeTree
    {
        [TestMethod]
        public void CreateAOneLevelTypeTree()
        {
            // prepare
            var definition = "Id,Name";
            var reference = new ReferenceType1();

            // execute
            var tree = new TypeTreeRootNode(reference, definition);

            // assert
            Assert.AreEqual("Id:Int32;Name:String", tree.ClassName);
        }

        [TestMethod]
        public void CreateAMultiLevelTypeTree()
        {
            // prepare
            var definition = "Id,Name,Car\\Model";
            var reference = new ReferenceType1();

            // execute
            var tree = new TypeTreeRootNode(reference, definition);

            // assert
            Assert.AreEqual("Id:Int32;Name:String;Car:(Model:String)", tree.ClassName);
        }
    }
}

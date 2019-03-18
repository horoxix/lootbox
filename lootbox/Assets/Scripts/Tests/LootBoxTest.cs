using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class LootBoxTest {

    [SetUp]
    public void SetUp()
    {
        User user = new User();
    }

    [Test]
    public void LootBoxOpenTest() {
        // Use the Assert class to test conditions.
        Open open = new Open();
        open.OpenBox();
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator LootBoxTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}

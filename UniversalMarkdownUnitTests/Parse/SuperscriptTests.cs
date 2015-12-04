﻿using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using UniversalMarkdown.Parse.Elements;
using UITestMethodAttribute = Microsoft.VisualStudio.TestPlatform.UnitTestFramework.AppContainer.UITestMethodAttribute;

namespace UniversalMarkdownUnitTests.Parse
{
    [TestClass]
    public class SuperscriptTests : ParseTestBase
    {
        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Superscript_Simple()
        {
            AssertEqual("Using the carot sign ^will create exponentials",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "Using the carot sign " },
                    new SuperscriptTextInline().AddChildren(
                        new TextRunInline { Text = "will" }),
                    new TextRunInline { Text = " create exponentials" }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Superscript_Nested()
        {
            AssertEqual("A^B^C",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "A" },
                    new SuperscriptTextInline().AddChildren(
                        new TextRunInline { Text = "B" },
                        new SuperscriptTextInline().AddChildren(
                            new TextRunInline { Text = "C" }))));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Superscript_WithParentheses()
        {
            // The text to superscript can be enclosed in brackets.
            AssertEqual("This is a sentence^(This is a note in superscript).",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "This is a sentence" },
                    new SuperscriptTextInline().AddChildren(
                        new TextRunInline { Text = "This is a note in superscript" }),
                    new TextRunInline { Text = "." }));
        }

        [UITestMethod]
        [TestCategory("Parse - inline")]
        public void Superscript_Negative()
        {
            AssertEqual("Using the carot sign ^ incorrectly",
                new ParagraphBlock().AddChildren(
                    new TextRunInline { Text = "Using the carot sign ^ incorrectly" }));
        }
    }
}

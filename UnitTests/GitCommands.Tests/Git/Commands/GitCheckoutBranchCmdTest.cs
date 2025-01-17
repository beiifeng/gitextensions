using GitCommands;
using GitCommands.Git.Commands;

namespace GitCommandsTests.Git.Commands
{
    [TestFixture]
    public sealed class GitCheckoutBranchCmdTest
    {
        [Test]
        public void TestConstructor()
        {
            GitCheckoutBranchCmd cmd = new("branchName", true);

            Assert.IsNotNull(cmd);
            Assert.AreEqual(cmd.BranchName, "branchName");
            Assert.IsTrue(cmd.Remote);
        }

        [Test]
        public void TestConstructorRemoteIsFalse()
        {
            GitCheckoutBranchCmd cmd = new("branchName", false);

            Assert.IsNotNull(cmd);
            Assert.AreEqual(cmd.BranchName, "branchName");
            Assert.IsFalse(cmd.Remote);
        }

        [Test]
        public void TestAccessesRemoteIsFalse()
        {
            GitCheckoutBranchCmd cmd = new("branchName", true);

            Assert.IsFalse(cmd.AccessesRemote);
        }

        [Test]
        public void TestCollectArgumentsMergeReset()
        {
            // Merge

            Assert.AreEqual(
                "checkout --merge \"branchName\"",
                new GitCheckoutBranchCmd("branchName", false, LocalChangesAction.Merge).Arguments);

            Assert.AreEqual(
                "checkout --merge -b \"newBranchName\" \"branchName\"",
                new GitCheckoutBranchCmd("branchName", true, LocalChangesAction.Merge, CheckoutNewBranchMode.Create, "newBranchName").Arguments);

            Assert.AreEqual(
                "checkout --merge -B \"newBranchName\" \"branchName\"",
                new GitCheckoutBranchCmd("branchName", true, LocalChangesAction.Merge, CheckoutNewBranchMode.Reset, "newBranchName").Arguments);

            // Reset

            Assert.AreEqual(
                "checkout --force \"branchName\"",
                new GitCheckoutBranchCmd("branchName", false, LocalChangesAction.Reset).Arguments);

            Assert.AreEqual(
                "checkout --force -b \"newBranchName\" \"branchName\"",
                new GitCheckoutBranchCmd("branchName", true, LocalChangesAction.Reset, CheckoutNewBranchMode.Create, "newBranchName").Arguments);

            Assert.AreEqual(
                "checkout --force -B \"newBranchName\" \"branchName\"",
                new GitCheckoutBranchCmd("branchName", true, LocalChangesAction.Reset, CheckoutNewBranchMode.Reset, "newBranchName").Arguments);
        }
    }
}

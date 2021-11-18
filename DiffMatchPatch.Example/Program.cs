using DiffMatchPatch;

// Hello World C#
// https://github.com/google/diff-match-patch/wiki/Language:-C%23

diff_match_patch dmp = new diff_match_patch();

List<Diff> diff = dmp.diff_main("Hello World.", "Goodbye World.");
// Result: [(-1, "Hell"), (1, "G"), (0, "o"), (1, "odbye"), (0, " World.")]

dmp.diff_cleanupSemantic(diff);
// Result: [(-1, "Hello"), (1, "Goodbye"), (0, " World.")]

for (int i = 0; i < diff.Count; i++)
{
    Console.WriteLine(diff[i]);
}
/*
 * Diff(DELETE,"Hello")
 * Diff(INSERT,"Goodbye")
 * Diff(EQUAL," World.")
 */

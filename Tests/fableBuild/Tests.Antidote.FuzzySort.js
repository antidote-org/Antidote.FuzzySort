import fuzzysort from "fuzzysort";
import { some } from "./fable_modules/fable-library.3.7.8/Option.js";
import { assertEqual } from "./fable_modules/fable-library.3.7.8/Util.js";

export const haystack = ["puzzle", "Super Awesome Thing (now with stuff!)", "FileName.js", "/feeding/the/catPic.jpg"];

export const needle = "feed cat";

describe("uFuzzy.search", () => {
    it("works with strings", () => {
        const result = fuzzysort.go(needle, haystack, some(null));
        assertEqual(result.total, 1);
    });
});


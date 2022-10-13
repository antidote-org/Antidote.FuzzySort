module Tests.Fuse

open Mocha
open Node
open Fable.Core
open Fable.Core.Testing
open Fable.Core.JsInterop
open Antidote.FuzzySort


let haystack = ResizeArray [|
    "puzzle"
    "Super Awesome Thing (now with stuff!)"
    "FileName.js"
    "/feeding/the/catPic.jpg"
|]

let needle = "feed cat"

describe """uFuzzy.search""" (fun () ->

    it "works with strings" (fun () ->

        let result = fuzzysort.go(needle, haystack, null)
        Assert.AreEqual(result.total , 1)
    )
)

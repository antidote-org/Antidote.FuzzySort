// ts2fable 0.8.0
module rec Antidote.FuzzySort

#nowarn "3390" // disable warnings for invalid XML comments

open System
open Fable.Core
open Fable.Core.JS

type Array<'T> = System.Collections.Generic.IList<'T>
type ReadonlyArray<'T> = System.Collections.Generic.IReadOnlyList<'T>

[<Import("default", "fuzzysort")>]
let fuzzysort: FuzzySort.FuzzySort = jsNative

module FuzzySort =
    type [<AllowNullLiteral>] Result =
        /// Higher is better
        /// 
        /// 0 is a perfect match; -1000 is a bad match
        abstract score: float
        /// Your original target string
        abstract target: string

    type [<AllowNullLiteral>] Results =
        inherit ReadonlyArray<Result>
        /// Total matches before limit
        abstract total: float

    type [<AllowNullLiteral>] KeyResult<'T> =
        inherit Result
        /// Your original object
        abstract obj: 'T

    type [<AllowNullLiteral>] KeysResult<'T> =
        inherit ReadonlyArray<Result>
        /// Higher is better
        /// 
        /// 0 is a perfect match; -1000 is a bad match
        abstract score: float
        /// Your original object
        abstract obj: 'T

    type [<AllowNullLiteral>] KeyResults<'T> =
        inherit ReadonlyArray<KeyResult<'T>>
        /// Total matches before limit
        abstract total: float

    type [<AllowNullLiteral>] KeysResults<'T> =
        inherit ReadonlyArray<KeysResult<'T>>
        /// Total matches before limit
        abstract total: float

    type [<AllowNullLiteral>] Prepared =
        /// Your original target string
        abstract target: string

    type [<AllowNullLiteral>] Options =
        /// Don't return matches worse than this (higher is faster)
        abstract threshold: float option with get, set
        /// Don't return more results than this (lower is faster)
        abstract limit: float option with get, set
        /// If true, returns all results for an empty search
        abstract all: bool option with get, set

    type [<AllowNullLiteral>] KeyOptions =
        inherit Options
        abstract key: U2<string, ReadonlyArray<string>> with get, set

    type [<AllowNullLiteral>] KeysOptions<'T> =
        inherit Options
        abstract keys: ReadonlyArray<U2<string, ReadonlyArray<string>>> with get, set
        abstract scoreFn: (ResizeArray<KeyResult<'T>> -> float) option with get, set

    type [<AllowNullLiteral>] HighlightCallback<'T> =
        [<Emit("$0($1...)")>] abstract Invoke: ``match``: string * index: float -> 'T

    type [<AllowNullLiteral>] FuzzySort =
        abstract single: search: string * target: U2<string, Prepared> -> Result option
        abstract go: search: string * targets: ResizeArray<string> * ?options: obj -> Results
        abstract go: search: string * targets: ResizeArray<U2<string, Prepared> option> * ?options: Options -> Results
        abstract go: search: string * targets: ResizeArray<'T option> * options: KeyOptions -> KeyResults<'T>
        abstract go: search: string * targets: ResizeArray<'T option> * options: KeysOptions<'T> -> KeysResults<'T>
        abstract highlight: ?result: Result * ?highlightOpen: string * ?highlightClose: string -> string option
        abstract highlight: result: Result * callback: HighlightCallback<'T> -> ResizeArray<U2<string, 'T>> option
        abstract indexes: result: Result -> ResizeArray<int>
        abstract cleanup: unit -> unit
        /// Help the algorithm go fast by providing prepared targets instead of raw strings
        abstract prepare: target: string -> Prepared
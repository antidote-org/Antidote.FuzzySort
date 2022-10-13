# Antidote.FuzzySort
Github Repo [link](https://github.com/antidote-org/Antidote.FuzzySort)

Binding for npm https://www.npmjs.com/package/fuzzysort package

## Installation

## using nuget

```
dotnet add package Antidote.FuzzySort
```

## or with paket

```
paket add Antidote.FuzzySort --project /path/to/project.fsproj
```

You also need to install `fuzzysort` package.

## using Femto

```
dotnet femto --resolve
```

## using NPM
```
npm i fuzzysort
```

## using yarn

```
yarn add fuzzysort
```

## Usage

Exemple 1:

```fs
open Antidote.FuzzySort
open Fable.Core

let haystack = ResizeArray [|
    "puzzle"
    "Super Awesome Thing (now with stuff!)"
    "FileName.js"
    "/feeding/the/catPic.jpg"
|]

let needle = "feed cat"

let result = fuzzysort.go(needle, haystack, null)
```

## To publish

*For maintainers only*

```ps1
cd Antidote.FuzzySort
dotnet pack -c Release
dotnet nuget push .\bin\Release\Antidote.FuzzySort.X.X.X.snupkg -s nuget.org -k <nuget_key>
dotnet nuget push .\bin\Release\Antidote.FuzzySort.X.X.X.nupkg -s nuget.org -k <nuget_key>
```
